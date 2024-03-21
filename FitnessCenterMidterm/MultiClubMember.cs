using System;

class MultiClubMember : Member
{
    public int MembershipPoints { get; private set; }
    

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
    public override void CheckIn(Club club)
    {
       MembershipPoints = MembershipPoints + 10;
        Console.WriteLine($"Member {Name}, has been checked in!");

    }
}




