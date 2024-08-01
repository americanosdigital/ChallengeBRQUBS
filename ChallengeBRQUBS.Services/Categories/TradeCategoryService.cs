using System.Diagnostics;
using System.Collections.Generic;
using ChallengeBRQUBS.Domain.Entities;
using ChallengeBRQUBS.Domain.Interfaces;
using ChallengeBRQUBS.Domain.Rules;

namespace ChallengeBRQUBS.Services.Categories
{
    public class TradeCategoryService
    {
        private readonly IEnumerable<ICategoryRule> _categoryRules;

        public TradeCategoryService(IEnumerable<ICategoryRule> categoryRules)
        {
            _categoryRules = categoryRules;
        }

        public string CategorizeTrade(ITrade trade)
        {
            foreach (var rule in _categoryRules)
            {
                if (rule.IsMatch(trade))
                {
                    return rule.Category;
                }
            }
            return "UNKNOWN";
        }

        public List<string> CategorizeTrades(IEnumerable<ITrade> trades)
        {
            var tradeCategories = new List<string>();

            foreach (var trade in trades)
            {
                tradeCategories.Add(CategorizeTrade(trade));
            }

            return tradeCategories;
        }
    }
}
