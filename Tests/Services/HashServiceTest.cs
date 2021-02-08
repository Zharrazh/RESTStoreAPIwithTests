using NUnit.Framework;
using RESTStoreAPI.Services;
using System;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestFixture]
    public class HashServiceTests
    {

        [Test]
        public void Hash()
        {
            var hashData = "rm_0x*UO+ljh" + "12345" + "rm_0x*UO+ljh";
            var hashService = new HashService();
            Assert.AreEqual("NP7lTFN6Oq8aF5tlwP1qHbu7hr+o7AviwoUDxM7Uo9FMjy8BLn9+GttMm5iOz1cAql5S8SGIEEtjcW78uEYopg==", hashService.Hash(hashData));
        }
    }
}