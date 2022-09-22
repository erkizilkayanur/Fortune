using System;
using System.ComponentModel.DataAnnotations;

namespace Fortune.Context.Model
{
    public class Culture
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
