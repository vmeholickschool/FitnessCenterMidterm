//first child class with a variable to assign them to a club
//a checkin method that throws an exception if it is not their club
class SingleClubMember : Member
{
    public Club Club { get; }

    public SingleClubMember(string name, Club club) : base(name)
    {
        Club = club;
    }

    public override void CheckIn(Club club)
    {
        if (club != Club)
        {
            throw new Exception("You are not allowed to check-in at this club.");
        }

        
        Console.WriteLine($"Check-in successful at {club.Name} for {Name}");
    }
}
