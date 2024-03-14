using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterMidterm
{
    public class ClubList
    {
        public List<Club> ClubInfo { get; set; }
        public ClubList()
        {
            ClubInfo = new List<Club>();
            ClubInfo.Add(new Club("Auburn Hills", "123 Ridgewood Rd"));
            ClubInfo.Add(new Club("Auburn Hills", "123 Ridgewood Rd"));
            ClubInfo.Add(new Club("Auburn Hills", "123 Ridgewood Rd"));
            ClubInfo.Add(new Club("Auburn Hills", "123 Ridgewood Rd"));
            ClubInfo.Add(new Club("Auburn Hills", "123 Ridgewood Rd"));
        }
    }
}
