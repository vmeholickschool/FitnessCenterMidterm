using System;
using System.Collections.Generic;
//Club class that holds name and address at a minimum
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