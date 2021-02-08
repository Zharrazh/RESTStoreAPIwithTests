using NUnit.Framework;
using RESTStoreAPI.Services;
using System;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestFixture]
    public class RoleServiceTests
    {

        [Test]
        public void GetAllRoleKeys()
        {
            var roleService = new RoleService();
            CollectionAssert.AreEquivalent(new List<char> { 'a', 'u' }, roleService.GetAllRoleKeys());
        }

        [Test]
        public void GetAllRoleNames()
        {
            var roleService = new RoleService();
            CollectionAssert.AreEquivalent(new List<string> { "admin", "user" }, roleService.GetAllRoleNames());
        }

        [Test]
        [TestCase('u',true)]
        [TestCase('z',false)]
        public void IsCorrectRoleKey(char roleKey, bool expectedResult)
        {
            var roleService = new RoleService();
            Assert.AreEqual(expectedResult, roleService.IsCorrectRoleKey(roleKey));
        }

        [Test]
        [TestCase("user", true)]
        [TestCase("god", false)]
        public void IsCorrectRoleName(string roleName, bool expectedResult)
        {
            var roleService = new RoleService();
            Assert.AreEqual(expectedResult, roleService.IsCorrectRoleName(roleName));
        }


        [Test]
        [TestCase("admin", 'a')]
        [TestCase("user", 'u')]
        public void GetRoleKey(string roleName,char expectedResult)
        {
            var roleService = new RoleService();
            Assert.AreEqual(expectedResult, roleService.GetRoleKey(roleName));
        }

        [Test]
        public void GetRoleKey_MustThrowException()
        {
            string errorRoleName = "NotExistedRoleName";
            var roleService = new RoleService();

            Assert.Throws<ArgumentException>(() => roleService.GetRoleKey(errorRoleName));
        }

        [Test]
        public void GetRoleKeys()
        {
            List<string> roleNames = new List<string> { "admin", "user" };
            string expectedResult = "au";
            var roleService = new RoleService();

            Assert.AreEqual(expectedResult, roleService.GetRoleKeys(roleNames));
        }

        [Test]
        public void GetRoleKeys_MustThrowException()
        {
            List<string> roleNames = new List<string> { "admin", "user", "errorRoleName" };
            var roleService = new RoleService();

            Assert.Throws<ArgumentException>(() => roleService.GetRoleKeys(roleNames));
        }

        [Test]
        public void GetRoleName()
        {
            char roleKey = 'a';
            string expectedResult = "admin";
            var roleService = new RoleService();

            Assert.AreEqual(expectedResult, roleService.GetRoleName(roleKey));
        }

        [Test]
        public void GetRoleName_MustThrowException()
        {
            char roleKey = 'z';
            var roleService = new RoleService();

            Assert.Throws<ArgumentException>(()=> roleService.GetRoleName(roleKey));
        }

        [Test]
        public void GetRoleNames()
        {
            string roleKeys = "au" ;
            var expectedResult = new List<string> {"admin", "user" };
            var roleService = new RoleService();

            Assert.AreEqual(expectedResult, roleService.GetRoleNames(roleKeys));
        }

        [Test]
        public void GetRoleNames_MustThrowException()
        {
            string roleKeys = "auz";
            var roleService = new RoleService();

            Assert.Throws<ArgumentException>(() => roleService.GetRoleNames(roleKeys));
        }



    }
}