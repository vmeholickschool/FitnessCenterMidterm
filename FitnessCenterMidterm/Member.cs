//Members class to hold member details that will have 2 child classes
//holds id, name and abstract method void check in at minimum 
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

    internal abstract void CheckIn(Club selectedClub);
}
public abstract void CheckIn(Club club);
