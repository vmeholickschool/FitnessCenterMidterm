class BillOfFees
{
    public Member Member { get; }
    public double Fee { get; }
    public DateTime DateGenerated { get; }

    public BillOfFees(Member member, double fee)
    {
        Member = member;
        Fee = fee;
        DateGenerated = DateTime.Now;
    }

    public void PrintBill()
    {
        Console.WriteLine($"Bill for {Member.Name} generated on {DateGenerated}:");
        Console.WriteLine($"Membership Fee: ${Fee}");
    }
}