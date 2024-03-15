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
            ClubInfo.Add(new Club("Auburn Hills", "123 Ridgewood Rd",1));
            ClubInfo.Add(new Club("Troy", "123 Ridgewood Rd",2));
            ClubInfo.Add(new Club("Ann Arbor", "123 Ridgewood Rd",3));
            ClubInfo.Add(new Club("Clawson", "123 Ridgewood Rd",4));
            ClubInfo.Add(new Club("Detroit", "123 Ridgewood Rd",5));
        }

        public void DisplayClubLocations()
        {
            foreach (Club club in ClubInfo)
            {
                Console.WriteLine($"{club.ClubNumber}.) {club.Name}");
            }
        }

        public Club SelectClubLocation(int clubIndex)
        {
            Club selectedClub = new Club("","",0);
            foreach (Club club in ClubInfo)
            {
                if (clubIndex == club.ClubNumber )
                {
                    selectedClub = club;
                    break;
                }

            }
           
            return selectedClub;
        }

    }
}
