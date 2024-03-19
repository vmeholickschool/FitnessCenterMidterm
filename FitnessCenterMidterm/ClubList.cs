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
            ClubInfo.Add(new Club(1,"Auburn Hills", "123 Ridgewood Rd"));
            ClubInfo.Add(new Club(2,"Troy", "123 Ridgewood Rd"));
            ClubInfo.Add(new Club(3,"Royal Oak", "123 Ridgewood Rd"));
            ClubInfo.Add(new Club(4,"Rochester", "123 Ridgewood Rd"));
            ClubInfo.Add(new Club(5,"Birmingham", "123 Ridgewood Rd"));
        }
    }
}
