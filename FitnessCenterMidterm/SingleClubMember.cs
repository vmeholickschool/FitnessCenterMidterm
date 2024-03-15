using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterMidterm
{
    public class SingleClubMember : Member
    {  //Variable to assign to a club
        public Club AssignedClub { get; set; }
        public double MonthlyFees { get; set; } = 200;

        //Check in method throws an exception if not their club
        public SingleClubMember():base() 
        { 

        }
        public override void CheckIn(Club club)
        {
            if (club.Name != AssignedClub.Name)
            {
                throw new Exception("You are not assigned to this club.");
            }
            Console.WriteLine($"{Name} checked in at {club.Name}.");
        }
    }

}

