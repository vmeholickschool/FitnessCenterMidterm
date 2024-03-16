//first child class with a variable to assign them to a club
//a checkin method that throws an exception if it is not their club
class SingleClubMember : Member
{
    private Club club;

    public Club Club { get; }

    public SingleClubMember(string name, Club club, int membershipNumber) : base(name)
    {
        Club = club;
    }

    public SingleClubMember(string name, Club club, string membershipNumber) : base(name)
    {
    }

    public SingleClubMember(string name, Club club) : base(name)
    {
    }

    public void CheckIn(Club selectedClub)
    {
        if (club == Club)
        {
            Console.WriteLine($"Check-in successful at {club.Name} for {Name}");
        }
        else
        {
            throw new Exception("You are not allowed to check-in at this club.");
        }
    }
}
