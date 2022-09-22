using System;
using System.ComponentModel.DataAnnotations;

namespace Fortune.Context.Model
{
    public class CardComment
    {
        [Key]
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public string Culture { get; set; }

        public Guid CardId { get; set; }
        public Card Card { get; set; }
    }
}
