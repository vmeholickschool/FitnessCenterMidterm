using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterMidterm
{
    public abstract class Member
    { //Id and name needed
        public int Id { get; set; } = 100;
        public string Name { get; set; }

        public Member()
        {
            Id++;
        }
        // Abstract method for checking in
        public abstract void CheckIn(Club club);
    }
}
