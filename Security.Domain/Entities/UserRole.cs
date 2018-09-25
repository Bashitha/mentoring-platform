using System;
using System.Collections.Generic;
using System.Text;

namespace Security.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public string UserRoleName { get; set; }
        public string UserRoleDescription { get; set; }
        public string Status { get; set; }
        public List<User> Users { get; set; }
    }
}
