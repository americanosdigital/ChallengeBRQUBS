using ChallengeBRQUBS.Domain.Interfaces;

namespace ChallengeBRQUBS.Domain.Rules
{
    public class LowRiskRule : ICategoryRule
    {
        public string Category => "LOWRISK";

        public bool IsMatch(ITrade trade)
        {
            return trade.Value < 1000000 && trade.ClientSector == "Public";
        }
    }
}
