using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using vpkp.Models.Database;

namespace vpkp.Models.StaticTabs
{
    public class CityTab : StaticTab
    {
        public CityTab(string h = "", DbSet<City>? dBS = null) : base(h)
        {   
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("CityId");
            DataColumns.Add("Title");
            DataColumns.Add("State");
            DataColumns.Add("Population");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<City>? DBS { get; set; }
    }
}
