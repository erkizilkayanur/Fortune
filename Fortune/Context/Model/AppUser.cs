using System;
using System.ComponentModel.DataAnnotations;

namespace Fortune.Context.Model
{
    public class AppUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public UserType Type { get; set; }
        public bool IsActive { get; set; }

    }

    public enum UserType
    {
        User,
        Admin
    }
}
