using System.Collections.Generic;

namespace vpkp.Models.Database
{
    public partial class City
    {
        public City()
        {
            Clubs = new HashSet<Club>();
        }

        public long CityId { get; set; }
        public string? Title { get; set; }
        public string? State { get; set; }
        public long? Population { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
    }
}
