using System;
using System.Collections.Generic;

public class Club
{
    private int membershipId;

    public string Name { get; }
    public string Address { get; }

    public Club(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public Club(int membershipId)
    {
        this.membershipId = membershipId;
    }

    internal void CheckIn(string clubName)
    {
        throw new NotImplementedException();
    }
}