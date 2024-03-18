using System.Xml.Linq;
//Second child with a variable to store membership points
// the check in method adds to the membership points
class MultiClubMember : Member
{
    public int MembershipPoints { get; private set; }

    public MultiClubMember(string name, int membershipNumber) : base(name)
    {
        MembershipPoints = 0;
    }

    public MultiClubMember(string name, string membershipNumber) : base(name)
    {
    }

    public MultiClubMember(string name) : base(name)
    {
    }

    public void CheckIn(Club selectedClub)
    {
        // Perform check-in actions here, if needed
        Console.WriteLine($"Check-in successful at {selectedClub.Name} for {Name}");

        // Update membership points
        MembershipPoints += 10;
    }
}



