namespace vpkp.Models.Database
{
    public partial class MatchStatistic
    {
        public long Id { get; set; }
        public long? MatchId { get; set; }
        public long? ClubId { get; set; }
        public long? PointsNumber { get; set; }

        public virtual Club? Club { get; set; }
        public virtual Match? Match { get; set; }
    }
}
