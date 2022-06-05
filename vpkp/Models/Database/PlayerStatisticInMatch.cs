namespace vpkp.Models.Database
{
    public partial class PlayerStatisticInMatch
    {
        public long Id { get; set; }
        public long? MatchId { get; set; }
        public long? PlayerId { get; set; }
        public long? GoalsNumber { get; set; }
        public long? ThrowsNumber { get; set; }
        public long? FoulsNumber { get; set; }

        public virtual Match? Match { get; set; }
        public virtual Player? Player { get; set; }
    }
}
