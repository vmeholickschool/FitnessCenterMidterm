class SingleClubMember : Member
{
    public Club Club { get; }

    public SingleClubMember(string name, Club club) : base(name)
    {
        Club = club;
    }

    public override string CheckIn(Club club)
    {
        if (club != Club)
        {
            throw new Exception("You are not allowed to check-in at this club.");
        }
        // Perform check-in actions
        return base.MembershipNumber;
    }
}