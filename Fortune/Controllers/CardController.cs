using Fortune.Infrastructure.Filters;
using Fortune.Models;
using Fortune.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fortune.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }


        /// <summary>
        /// Geçmiş, şimdi ve gelecek için 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTripleCard/{culture}")]
        [Produces("application/json", Type = typeof(CardModel))]
        [Authorization]
        public IActionResult GetTripleCard(string culture)
        {
            var data = _cardService.GetTripleCard(culture);

            return Ok(data);
        }

        /// <summary>
        /// Culture Listesi
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCultureList")]
        [Produces("application/json", Type = typeof(List<string>))]
        [Authorization]
        public IActionResult GetCultureList()
        {
            var data = _cardService.GetCultureList();

            return Ok(data);
        }
    }
}
