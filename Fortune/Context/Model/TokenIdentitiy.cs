using System;
using System.ComponentModel.DataAnnotations;

namespace Fortune.Context.Model
{
    public class TokenIdentitiy
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Identity { get; set; }//UserId
        public string Token { get; set; }
        public DateTime Expire { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

    }

}
