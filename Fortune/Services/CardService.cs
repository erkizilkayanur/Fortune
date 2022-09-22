using Fortune.Models;
using Fortune.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fortune.Services
{
    public interface ICardService
    {
        List<CardItem> GetTripleCard(string culture);
        List<string> GetCultureList();
    }

    public class CardService : ICardService
    {

        private readonly ICardRepository _cardRepository;
        private readonly ICultureRepository _cultureRepository;
        private Dictionary<int, Guid> cardDictionary;
        public CardService(ICardRepository cardRepository, ICultureRepository cultureRepository)
        {
            _cardRepository = cardRepository;
            _cultureRepository = cultureRepository;
        }



        public List<CardItem> GetTripleCard(string culture)
        {
            List<CardItem> result = new List<CardItem>();
            for (int i = 0; i < 3; i++)
            {
                Guid cardId = RandomCard();

                var cardItem = _cardRepository.Get(x => x.Id == cardId).Include(x => x.CardComments).Include(x => x.CardNames)
                    .Select(x => new CardItem
                    {
                        ImageUrl = x.ImageUrl,
                        Comment = x.CardComments.FirstOrDefault(x => x.Culture == culture).Comment,
                        Name = x.CardNames.FirstOrDefault(x => x.Culture == culture).Name
                    }).FirstOrDefault();
                result.Add(cardItem);


            }
            return result;

        }

        public List<string> GetCultureList()
        {
            var result = _cultureRepository.Get().Select(x => x.Name).ToList();

            return result;
        }




        private Guid RandomCard()
        {
            if (cardDictionary == null)
            {
                cardDictionary = new Dictionary<int, Guid>();
                int i = 0;
                var cardIds = _cardRepository.Get().Select(x => x.Id);
                foreach (var cardId in cardIds)
                {
                    cardDictionary.Add(i++, cardId);
                }
            }
            Random rnd = new Random();
            int rndCard = rnd.Next(1, 78);


            return cardDictionary[rndCard];
        }
    }
}
