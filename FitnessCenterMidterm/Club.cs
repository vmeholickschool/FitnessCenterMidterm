using System;
using System.Collections.Generic;

public class Club
{
    public string Name { get; }
    public string Address { get; }

    public Club(string name, string address)
    {
<<<<<<< HEAD
        public string Address { get; set; }
        public string Name { get; set; }

        public int ClubNumber { get; set; }
        public Club(string name, string address,int clubNumber) 
        { 
            Name = name;
            Address = address;
            ClubNumber = clubNumber;
        }
=======
        Name = name;
        Address = address;
>>>>>>> af0aa292f2777ea256081f606d5e5f134f3fbb85
    }
}