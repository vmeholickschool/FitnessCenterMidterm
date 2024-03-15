
using FitnessCenterMidterm;
using System.ComponentModel;


ClubList clubList = new ClubList();
SingleClubMember single = new SingleClubMember();
MultiClubMember multi = new MultiClubMember();
List<SingleClubMember> singleClubMembers = new List<SingleClubMember>();


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
    int counter = 1;

    if (memberType == 1)
    {
        single.Name = name;
        Console.WriteLine("Select club:");
        foreach (Club club in clubList.ClubInfo) { Console.WriteLine($"{counter}. {club.Name} - {club.Address}"); }
        int clubIndex = int.Parse(Console.ReadLine()) - 1;
        single.AssignedClub = clubList.ClubInfo[clubIndex];
        MemberList singleClub = new MemberList();
        List<SingleClubMember> singleClubMembers = singleClub.AddSingleClubMember(single);
        foreach (SingleClubMember singleClubMember in singleClubMembers)
        {
            Console.WriteLine(singleClubMember);
        }
        Console.WriteLine("Member added successfully.");
    }
    else if (memberType == 2)
    {
        multi.Name = name;
        MemberList multiClub = new MemberList();
        List<MultiClubMember> multiClubMembers = multiClub.AddMultiClubMember(multi);
        foreach (MultiClubMember multiClubMember in multiClubMembers)
        {
            Console.WriteLine(multiClubMember);
        }
        Console.WriteLine("Member added successfully.");
    }
    else
    {
        Console.WriteLine("Invalid member type");

    }
}




// Method to remove a member
void RemoveMember()
{
    Console.WriteLine("Enter member name:");
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
    Console.WriteLine("Enter member name:");
    singleClubMembers = singleClubMembers.Find(x => x.Name == Console.ReadLine().Trim());
    if(memberName != null)
    {
        int counter = 1;
        Console.WriteLine("What is the member type? Enter 1 for Single Club Member, 2 for Multi-Club Member:");
        Console.WriteLine("Select a club to check in");
        foreach (Club clubInfo in clubList.ClubInfo) { Console.WriteLine($"{counter}. {clubInfo.Name} - {clubInfo.Address}"); }
        int clubIndex = int.Parse(Console.ReadLine()) - 1;
        var memberType = int.Parse(Console.ReadLine());
        Club club = new Club(clubList.ClubInfo[clubIndex].Name, clubList.ClubInfo[clubIndex].Address);
        if (memberType == 1)
        {
            
            single.CheckIn(club);

        }
        else if (memberType == 2)
        {
            multi.CheckIn(club);
        }
        

    }

    Member member = members.Find(m => m.Id == int.Parse(Console.ReadLine()));
    if (member != null)
    {
        Console.WriteLine("Select club to check in:");
        for (int i = 0; i < clubs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {clubs[i].Name}");
        }
        var clubIndex = int.Parse(Console.ReadLine()) - 1;
        Club club = clubs[clubIndex];
        try
        {
            member.CheckIn(club);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
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