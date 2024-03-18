using System;
using System.Collections.Generic;

public class Club
{
    public string Name { get; }
    public string Address { get; }

    public Club(string name, string address)
    {
        Name = name;
        Address = address;
    }
}