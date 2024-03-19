using System;

class SingleClubMember : Member
{
    public Club Club { get; }

    // Constructor to initialize a SingleClubMember with name, club, and membership number
    public SingleClubMember(string name, Club club, int membershipNumber) : base(name)
    {
        Club = club;  // Assign the club passed as a parameter to the Club property
    }

    // Constructor to initialize a SingleClubMember with name and club
    public SingleClubMember(string name, Club club, Func<string> toString) : base(name)
    {
        Club = club;  // Assign the club passed as a parameter to the Club property
    }

    public override void CheckIn(Club selectedClub)
    {
        if (selectedClub == Club)
        {
            Console.WriteLine($"Check-in successful at {selectedClub.Name} for {Name}");
        }
        else
        {
            throw new Exception("You are not allowed to check-in at this club.");
        }
    }
}



