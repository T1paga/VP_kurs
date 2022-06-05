using System.Collections.Generic;

namespace vpkp.Models.Database
{
    public partial class Match
    {
        public Match()
        {
            MatchStatistics = new HashSet<MatchStatistic>();
            PlayerStatisticInMatches = new HashSet<PlayerStatisticInMatch>();
        }

        public long MatchId { get; set; }
        public string? Date { get; set; }
        public string? Winner { get; set; }
        public long? Club1Id { get; set; }
        public long? Club2Id { get; set; }

        public virtual Club? Club1 { get; set; }
        public virtual Club? Club2 { get; set; }
        public virtual ICollection<MatchStatistic> MatchStatistics { get; set; }
        public virtual ICollection<PlayerStatisticInMatch> PlayerStatisticInMatches { get; set; }
    }
}
