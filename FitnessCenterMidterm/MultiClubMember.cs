using System;

class MultiClubMember : Member
{
<<<<<<< Updated upstream
    public int MembershipPoints { get; private set; }
=======
    public class MultiClubMember : Member
    {   //variable to store membership points
        public int MembershipPoints { get; set; } = 0;
        public double MonthlyFees { get; set; } = 280;
        public MemberList MultiClub {  get; set; }
        public int ID { get; set; }
        //Check in method adds to their membership points
        public MultiClubMember(): base()
        {
            ID = Id;
        }
        public override void CheckIn(Club club)
        {
            /*if (Name ==) { MembershipPoints += 10; }
             // Example, you can adjust how many points to add
            Console.WriteLine($"{Name} checked in at {club.Name}. Membership points: {MembershipPoints}");*/
        }
        public void CheckInMultiClub(string name, Club club)
        {
            if (Name == name) { MembershipPoints += 10; }
            Console.WriteLine($"{Name} checked in at {club.Name}. Membership points: {MembershipPoints}");
        }
>>>>>>> Stashed changes

    // Constructor to initialize a MultiClubMember with name, membership number, and initial membership points
    public MultiClubMember(string name, int membershipNumber, int membershipPoints) : base(name)
    {
        MembershipPoints = membershipPoints;
    }

    // Constructor to initialize a MultiClubMember with name and membership number, membership points will be set to 0
    public MultiClubMember(string name, int membershipNumber) : base(name)
    {
        MembershipPoints = 0;
    }

    // Constructor to initialize a MultiClubMember with name, membership points will be set to 0
    public MultiClubMember(string name) : base(name)
    {
        MembershipPoints = 0;
    }

    // Method to set membership points
    public void SetMembershipPoints(int points)
    {
        MembershipPoints = points;
    }

    // Override the CheckIn method
    public override void CheckIn(Club selectedClub)
    {
        Console.WriteLine($"Check-in successful at {selectedClub.Name} for {Name}");
    }
}




