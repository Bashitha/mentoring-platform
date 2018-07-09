using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using Security.Infrastructure.Data;
using Security.API.Controllers;
using Security.Domain.Entities;
using Security.API.Models;
using Security.TestsHelper;

namespace Security.API.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        [Test]
        public void CreateUser_WhenNewUserAddedFromSecurityAdminScreen_NewUserShouldExistInSystem()
        {
            // Arrange
            var testContext = GetContextHelper.GetTestContext();
            var testUserRepository = new EfRepository<User>(testContext);
            var userController = new UserController(testUserRepository);
            var uniqueEmail = "unique321@test.com";

            var userViewModel = new UserViewModel() {
                FirstName = "TestName",
                LastName = "TestLastName",
                Email = uniqueEmail
            };

            // Act
            var newUserInSystem = userController.Post(userViewModel);

            // Assert
            Assert.IsNotNull(newUserInSystem);
            Assert.AreSame(uniqueEmail, newUserInSystem.Email);
        }

        [Test]
        public void GetUserById_WhenAuthenticatingExistingUser_ShouldReceiveCorrespondingUserFromId()
        {
            // Arrange
            var testContext = GetContextHelper.GetTestContextWithData();
            var testUserRepository = new EfRepository<User>(testContext);
            var userController = new UserController(testUserRepository);
            var userId = 1;

            // Act
            var user = userController.Get(userId);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreSame("Leshan", user.FirstName);
        }

        [Test]
        public void DefaultTestForEqualityCheck()
        {
            Assert.AreNotEqual(1, 2);
        }
    }
}
