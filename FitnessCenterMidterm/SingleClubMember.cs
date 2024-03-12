using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterMidterm
{
    internal class SingleClubMember : Member
    {
        public Club AssignedClub { get; set; }
        public override void CheckIn(Club club)
        {
            throw new InvalidOperationException("You are only permitted to check into your assigned club");
        }
       
    }

}

