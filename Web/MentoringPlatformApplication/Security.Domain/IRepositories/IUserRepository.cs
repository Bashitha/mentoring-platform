using Security.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Security.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>, IAsyncRepository<User>
    {
        User GetByEmail(string email);        
        
    }
}
