using ChallengeBRQUBS.Domain.Interfaces;

namespace ChallengeBRQUBS.Domain.Rules
{
    public class MediumRiskRule : ICategoryRule
    {
        public string Category => "MEDIUMRISK";

        public bool IsMatch(ITrade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Public";
        }
    }
}
