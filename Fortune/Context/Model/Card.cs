using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fortune.Context.Model
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public CardType Type { get; set; }

        public virtual ICollection<CardName> CardNames { get; set; }

        public virtual ICollection<CardComment> CardComments { get; set; }



    }

    public enum CardType
    {
        BIGARCANA,//BüyükArkana
        WANCARD,//AsaKartları
        SWORDCARD,//KılıçKartları
        CUPCARD,//Kupa Kartları
        CHARMCARD//Tılsım Kartları
    }
}
