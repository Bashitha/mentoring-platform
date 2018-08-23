using System;
using System.Collections.Generic;
using System.Text;
namespace Security.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public User() { }
        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
