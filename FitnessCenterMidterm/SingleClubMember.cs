using System;

class SingleClubMember : Member
{
    public Club Club { get; }

<<<<<<< Updated upstream
    // Constructor to initialize a SingleClubMember with name, club, and membership number
    public SingleClubMember(string name, Club club, int membershipNumber) : base(name)
    {
        Club = club;  // Assign the club passed as a parameter to the Club property
=======
        public int ID { get; set; }

        //Check in method throws an exception if not their club
        public SingleClubMember():base() 
        {
            ID = Id;
        }
        public override void CheckIn(Club club)
        {
            if (club.Id != AssignedClub.Id)
            {
                Console.WriteLine("The member is not assigned to this club."); ;
            }
            else
            {
                Console.WriteLine($"{Name} checked in at {club.Name}.");
            }
            
        }
>>>>>>> Stashed changes
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



