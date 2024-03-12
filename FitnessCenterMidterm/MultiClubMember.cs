using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FitnessCenterMidterm
{
    internal class MultiClubMember : Member

    {
        public int MembershipPoints {  get; set; }



        public override void CheckIn(Club club)
        {
            int membershipPoints = 0;
            membershipPoints++;
            MembershipPoints = membershipPoints;
        }

        
    }
}

