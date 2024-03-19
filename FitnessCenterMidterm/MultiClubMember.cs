using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FitnessCenterMidterm
{
    public class MultiClubMember : Member
    {   //variable to store membership points
        public int MembershipPoints { get; set; } = 0;
        public double MonthlyFees { get; set; } = 280;
        //Check in method adds to their membership points
        public MultiClubMember(): base()
        {
            
        }
        public override void CheckIn(Club club)
        {
            if () { MembershipPoints += 10; }
             // Example, you can adjust how many points to add
            Console.WriteLine($"{Name} checked in at {club.Name}. Membership points: {MembershipPoints}");
        }


    }
}

