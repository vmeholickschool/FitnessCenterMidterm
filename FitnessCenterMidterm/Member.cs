
abstract class Member
{
    public int Id { get; set; }
    public string Name { get; }
    public string MembershipNumber { get; }
    private static int lastMembershipNumber = 0;

    public Member(string name)
    {
        Name = name;
        MembershipNumber = (++lastMembershipNumber).ToString(); // Increment and assign the next membership number
    }

    public void CheckIn(Club selectedClub)
    {
        // Method body goes here
    }
}

