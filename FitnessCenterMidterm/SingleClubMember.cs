using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterMidterm
{
    class SingleClubMember : Member
    {  //Variable to assign to a club
        public required Club AssignedClub { get; set; }

        //Check in method throws an exception if not their club
        public SingleClubMember():base() 
        { 

        }
        public override void CheckIn(Club club)
        {
            if (club != AssignedClub)
            {
                throw new Exception("You are not assigned to this club.");
            }
            Console.WriteLine($"{Name} checked in at {club.Name}.");
        }
    }

}

