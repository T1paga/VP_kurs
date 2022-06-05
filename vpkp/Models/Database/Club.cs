using System.Collections.Generic;

namespace vpkp.Models.Database
{
    public partial class Club
    {
        public Club()
        {
            MatchClub1s = new HashSet<Match>();
            MatchClub2s = new HashSet<Match>();
            MatchStatistics = new HashSet<MatchStatistic>();
            Players = new HashSet<Player>();
        }

        public long ClubId { get; set; }
        public long? PlayersAmount { get; set; }
        public string? Division { get; set; }
        public string? Titile { get; set; }
        public long? CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Match> MatchClub1s { get; set; }
        public virtual ICollection<Match> MatchClub2s { get; set; }
        public virtual ICollection<MatchStatistic> MatchStatistics { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
