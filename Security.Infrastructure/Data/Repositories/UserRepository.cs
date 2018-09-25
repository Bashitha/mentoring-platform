using Security.Domain.Entities;
using Security.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Security.Infrastructure.Data.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MentoringPlatformSecurityContext dbContext) : base(dbContext)
        {
        }
        public User GetByEmail(string email)
        {
            return _dbContext.Users
                   .Where(o => o.Email == email)
                   .FirstOrDefault();
        }
    }
}
