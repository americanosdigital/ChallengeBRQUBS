using ChallengeBRQUBS.Domain.Interfaces;

namespace ChallengeBRQUBS.Domain.Rules
{
    public class HighRiskRule : ICategoryRule
    {
        public string Category => "HighRisk";

        public bool IsMatch(ITrade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Private";
        }
    }
}
