using Fortune.Context.Model;
using System;

namespace Fortune.Models
{
    public class UserTokenObject
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }

    }
}
