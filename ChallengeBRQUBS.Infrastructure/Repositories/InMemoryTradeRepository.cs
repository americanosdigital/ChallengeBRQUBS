using System.Collections.Generic;
using System.Linq;
using ChallengeBRQUBS.Domain.Entities;
using ChallengeBRQUBS.Domain.Interfaces;


namespace ChallengeBRQUBS.Infrastructure.Repositories
{
    public class InMemoryTradeRepository
    {
        private readonly List<ITrade> _trades = new List<ITrade>();

        public void AddTrade(ITrade trade)
        {
            _trades.Add(trade);
        }

        public IEnumerable<ITrade> GetAllTrades()
        {
            return _trades;
        }
    }
}
