using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ChallengeBRQUBS.Application.DTOs;
using ChallengeBRQUBS.Services.Categories;
using ChallengeBRQUBS.Domain.Entities;
using ChallengeBRQUBS.Infrastructure.Repositories;

namespace ChallengeBRQUBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradesController : ControllerBase
    {
        private readonly TradeCategoryService _tradeCategoryService;
        private readonly InMemoryTradeRepository _tradeRepository;

        public TradesController(
            TradeCategoryService tradeCategoryService,
            InMemoryTradeRepository tradeRepository)
        {
            _tradeCategoryService = tradeCategoryService;
            _tradeRepository = tradeRepository;
        }

        [HttpPost("categorize")]
        public IActionResult CategorizeTrades([FromBody] List<TradeDto> tradeDtos)
        {
            var trades = tradeDtos.Select(dto => new Trade(dto.Value, dto.ClientSector)).ToList();
            var categories = _tradeCategoryService.CategorizeTrades(trades);
            return Ok(categories);
        }

        [HttpPost("add")]
        public IActionResult AddTrade([FromBody] TradeDto tradeDto)
        {
            var trade = new Trade(tradeDto.Value, tradeDto.ClientSector);
            _tradeRepository.AddTrade(trade);
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAllTrades()
        {
            var trades = _tradeRepository.GetAllTrades();
            return Ok(trades);
        }

    }
}
