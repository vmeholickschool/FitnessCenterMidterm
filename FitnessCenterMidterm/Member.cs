
abstract class Member
{
    public int Id { get; set; }
    public string Name { get; }
  
    public string MembershipNumber { get; }
    private static int lastMembershipNumber = 0;

    public Member(string name)
    {
        Name = name;
       // MembershipNumber = (++lastMembershipNumber).ToString(); 
    }

    public abstract void CheckIn(Club club); // Abstract method to be implemented by subclasses
}


