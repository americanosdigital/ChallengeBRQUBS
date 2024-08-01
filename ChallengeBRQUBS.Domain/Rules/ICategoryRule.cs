using ChallengeBRQUBS.Domain.Interfaces;

namespace ChallengeBRQUBS.Domain.Rules
{
    public interface ICategoryRule
    {
        string Category { get; }
        bool IsMatch(ITrade trade);
    }
}
