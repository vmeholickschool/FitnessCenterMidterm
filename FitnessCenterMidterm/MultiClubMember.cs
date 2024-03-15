class MultiClubMember : Member
{
    public int MembershipPoints { get; private set; }

    public MultiClubMember(string name) : base(name)
    {
        MembershipPoints = 0;
    }

    public override string CheckIn(Club club)
    {
        MembershipPoints += 10; // Arbitrary increment for demonstration
        // Perform check-in actions
        return base.MembershipNumber;
    }
}

