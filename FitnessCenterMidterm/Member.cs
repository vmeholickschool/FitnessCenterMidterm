abstract class Member
{
    private static int nextId = 1;

    public int Id { get; }
    public string Name { get; }
    public string MembershipNumber { get; }

    public Member(string name)
    {
        Id = nextId++;
        Name = name;
        MembershipNumber = GenerateMembershipNumber();
    }

    private string GenerateMembershipNumber()
    {
        // Generate a unique membership number based on some algorithm
        return Guid.NewGuid().ToString().Substring(0, 8); // For simplicity, using part of a GUID
    }

    public abstract string CheckIn(Club club);
}
