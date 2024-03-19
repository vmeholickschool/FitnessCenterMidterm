class BillOfFees
{
    public Member Member { get; }
    public double Fee { get; }
    public int MembershipPoints { get; } // New property for membership points
    public DateTime DateGenerated { get; }

    public BillOfFees(Member member, double fee, int membershipPoints)
    {
        Member = member;
        Fee = fee;
        MembershipPoints = membershipPoints;
        DateGenerated = DateTime.Now;
    }

    public void PrintBill()
    {
        Console.WriteLine($"Bill for {Member.Name} generated on {DateGenerated}:");
        Console.WriteLine($"Membership Fee: ${Fee}");
        Console.WriteLine($"Membership Points: {MembershipPoints}");
    }
}