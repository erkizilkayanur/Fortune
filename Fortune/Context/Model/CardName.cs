using System;
using System.ComponentModel.DataAnnotations;

namespace Fortune.Context.Model
{
    public class CardName
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }


        public Guid CardId { get; set; }
        public Card Card { get; set; }

    }
}
