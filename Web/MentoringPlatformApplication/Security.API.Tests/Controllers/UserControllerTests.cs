using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using Security.Infrastructure.Data;
using Security.API.Controllers;
using Security.Domain.Entities;
using Security.API.Models;


namespace Security.API.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private MentoringPlatformSecurityContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder<MentoringPlatformSecurityContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            return new MentoringPlatformSecurityContext(options);
        }

        [Test]
        public void CreateUser_WhenNewUserAddedFromSecurityAdminScreen_NewUserShouldExistInSystem()
        {
            // Arrange
            var testContext = GetTestContext();
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
        public void DefaultTestForEqualityCheck()
        {
            Assert.AreNotEqual(1, 2);
        }
    }
}
