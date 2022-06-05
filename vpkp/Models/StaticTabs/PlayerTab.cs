using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using vpkp.Models.Database;

namespace vpkp.Models.StaticTabs
{
    public class PlayerTab : StaticTab
    {
        public PlayerTab(string h = "", DbSet<Player>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("PlayerId");
            DataColumns.Add("Name");
            DataColumns.Add("Weight");
            DataColumns.Add("Age");
            DataColumns.Add("Number");
            DataColumns.Add("ClubId");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Player>? DBS { get; set; }
    }
}
