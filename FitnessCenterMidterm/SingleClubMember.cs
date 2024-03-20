using System;

class SingleClubMember : Member
{



    public Club AssignedLocation { get; }
    /*
    // Constructor to initialize a SingleClubMember with name, club, and membership number
    public SingleClubMember(string name, Club assignedLocation, int membershipNumber) : base(name)
    {

        AssignedLocation = assignedLocation;  // Assign the club passed as a parameter to the Club property
    }
    */
    // Constructor to initialize a SingleClubMember with name and club
    public SingleClubMember(string name, Club club, Func<string> toString) : base(name)
    {
        AssignedLocation = club;  // Assign the club passed as a parameter to the Club property
    }

    public override void CheckIn(Club club)
    {
        if (AssignedLocation.Name == club.Name)
        {
            Console.WriteLine("Member has been checked in!");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("This member is not assigned to this club.");
            Console.WriteLine();
        }

    }
}

