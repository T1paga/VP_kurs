using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using vpkp.Models.Database;

namespace vpkp.Models.StaticTabs
{
    public class MatchTab : StaticTab
    {
        public MatchTab(string h = "", DbSet<Match>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("MatchId");
            DataColumns.Add("Date");
            DataColumns.Add("Winner");
            DataColumns.Add("Club1Id");
            DataColumns.Add("Club2Id");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Match>? DBS { get; set; }
    }
}
