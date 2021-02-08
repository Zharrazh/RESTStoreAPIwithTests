using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RESTStoreAPI.Services;
using RESTStoreAPI.Setup.Config.Models;
using System;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestFixture]
    public class PasswordServiceTests
    {
        private IHashService hashService;
        private string salt = "!SALLTT!";
        private IOptionsSnapshot<AuthConfigModel> optionsSnap;
        
        [SetUp]
        public void Setup()
        {
            var hashMock = new Mock<IHashService>();
            hashMock.Setup(x => x.Hash(It.IsAny<string>())).Returns<string>(data => $"hashed({data})");
            hashService = hashMock.Object;

            var optionsMock = new Mock<IOptionsSnapshot<AuthConfigModel>>();
            optionsMock.SetupGet(x => x.Value).Returns(new AuthConfigModel { PasswordSalt= salt });

            optionsSnap = optionsMock.Object;

        }

        [Test]
        public void SaltHash()
        {
            string saltHashedPassword = "myPSWD!!!";
            string exceptedResult = $"hashed({salt}{saltHashedPassword}{salt})";
            var passService = new PasswordService(hashService, optionsSnap);

            Assert.AreEqual(exceptedResult, passService.SaltHash(saltHashedPassword));
        }

        [Test]
        [TestCase("hashed(!SALLTT!paswd!SALLTT!)","paswd", true)]
        [TestCase("!SALLTT!paswd!SALLTT!", "paswd", false)]
        [TestCase("hashed(paswd)", "paswd", false)]
        public void VerifyPassword(string hashPaswd, string passwd, bool expectedResult)
        {
            var passService = new PasswordService(hashService, optionsSnap);

            Assert.AreEqual(expectedResult, passService.VerifyPassword(hashPaswd,passwd));
        }
    }
}