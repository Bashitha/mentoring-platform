using Microsoft.EntityFrameworkCore;
using Security.Domain.Entities;
using Security.Infrastructure.Data;
using System;

namespace Security.TestsHelper
{
    public class GetContextHelper
    {
        public static MentoringPlatformSecurityContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder<MentoringPlatformSecurityContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            return new MentoringPlatformSecurityContext(options);
        }

        public static MentoringPlatformSecurityContext GetTestContextWithData()
        {
            var options = new DbContextOptionsBuilder<MentoringPlatformSecurityContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            var dbContext = new MentoringPlatformSecurityContext(options);
            dbContext.Users.Add(new User { Id = 1, FirstName = "Leshan", LastName = "Wijegunawardana", Email = "lbw@tiqri.com", Password = "123", Designation = "Software Engineer", UserRoleId = 1 });
            dbContext.Users.Add(new User { Id = 2, FirstName = "Dhanika", LastName = "Munasinghe", Email = "dtm@tiqri.com", Password = "123", Designation = "Software Engineer", UserRoleId = 1 });
            dbContext.Users.Add(new User { Id = 3, FirstName = "Thusitha", LastName = "Wijerathne", Email = "tij@tiqri.com", Password = "123", Designation = "Software Engineer", UserRoleId = 1 });
            dbContext.Users.Add(new User { Id = 4, FirstName = "Mark", LastName = "Sinnathambi", Email = "mvs@tiqri.com", Password = "123", Designation = "Tech Lead", UserRoleId = 2});
            dbContext.UserRoles.Add(new UserRole { Id = 1, UserRoleName = "mentee"});
            dbContext.UserRoles.Add(new UserRole { Id = 2, UserRoleName = "mentor" });

            return dbContext;
        }
    }
}
