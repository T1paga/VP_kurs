using System.Collections.Generic;

namespace vpkp.Models.Database
{
    public partial class Player
    {
        public Player()
        {
            PlayerStatisticInMatches = new HashSet<PlayerStatisticInMatch>();
        }

        public long PlayerId { get; set; }
        public string? Name { get; set; }
        public long? Weight { get; set; }
        public long? Age { get; set; }
        public long? Number { get; set; }
        public long? ClubId { get; set; }

        public virtual Club? Club { get; set; }
        public virtual ICollection<PlayerStatisticInMatch> PlayerStatisticInMatches { get; set; }
    }
}
