using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using vpkp.Models.Database;

namespace vpkp.Models.StaticTabs
{
    public class PlayerStatisticInMatchTab : StaticTab
    {
        public PlayerStatisticInMatchTab(string h = "", DbSet<PlayerStatisticInMatch>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Id");
            DataColumns.Add("MatchId");
            DataColumns.Add("PlayerId");
            DataColumns.Add("GoalsNumber");
            DataColumns.Add("ThrowsNumber");
            DataColumns.Add("FoulsNumber");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<PlayerStatisticInMatch>? DBS { get; set; }
    }
}
