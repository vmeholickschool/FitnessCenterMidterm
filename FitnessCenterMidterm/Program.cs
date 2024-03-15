
using FitnessCenterMidterm;

List<Member> members = new List<Member>();

ClubList clubList = new ClubList();


// Main menu
while (true)
{
    Console.WriteLine("1. Add member\n2. Remove member\n3. Check member in\n4. Generate bill of fees\n5. Exit");

    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            AddMember();
            break;
        case 2:
            RemoveMember();
            break;
        case 3:
            CheckMemberIn();
            break;
        case 4:
            GenerateBill();
            break;
        case 5:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}



// Method to add a member
void AddMember()
{
    Console.WriteLine("Enter member name:");
    var name = Console.ReadLine();
    Console.WriteLine("Enter 1 for Single Club Member, 2 for Multi-Club Member:");
    var memberType = int.Parse(Console.ReadLine());

    Member member;
    if (memberType == 1)
    {
        Console.WriteLine("Select club:");
        clubList.DisplayClubLocations();
        
        int clubIndex = int.Parse(Console.ReadLine());
        member = new SingleClubMember { Id = members.Count + 1, Name = name, AssignedClub = clubList.SelectClubLocation(clubIndex) };
        
    }
    else if (memberType == 2)
    {
        member = new MultiClubMember { Id = members.Count + 1, Name = name, MembershipPoints = 0 };
    }
    else
    {
        Console.WriteLine("Invalid member type.");
        return;
    }

    //members.Add(member);
    Console.WriteLine("Member added successfully.");
}

// Method to remove a member
void RemoveMember()
{
    Console.WriteLine("Enter member id to remove:");
    var member = members.Find(m => m.Id == int.Parse(Console.ReadLine()));
    if (member != null)
    {
        members.Remove(member);
        Console.WriteLine("Member removed successfully.");
    }
    else
    {
        Console.WriteLine("Member not found.");
    }
}

// Method to check a member in
void CheckMemberIn()
{
    Console.WriteLine("Enter member id:");
    Member member = members.Find(m => m.Id == int.Parse(Console.ReadLine()));
    if (member != null)
    {
        Console.WriteLine("Select club to check in:");
        clubList.DisplayClubLocations();
        var clubIndex = int.Parse(Console.ReadLine()) - 1;
        /*
        try
        {
            member.CheckIn(club);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        */
    }
    else
    {
        Console.WriteLine("Member not found.");
    }
}

// Method to generate bill of fees
void GenerateBill()
{
    Console.WriteLine("Enter member id to generate bill:");
    var id = int.Parse(Console.ReadLine());
    Member member = members.Find(m => m.Id == id);
    if (member != null)
    {
        // Generate bill based on member type

        Console.WriteLine("Bill generated successfully.");
    }
    else
    {
        Console.WriteLine("Member not found.");
    }
}

static Member NewMethod(List<Member> members, List<Club> clubs, string? name, int clubIndex)
{
    return new SingleClubMember { Id = members.Count + 1, Name = name, AssignedClub = clubs[clubIndex] };
}




