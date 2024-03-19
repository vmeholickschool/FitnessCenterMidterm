
using FitnessCenterMidterm;
using System.ComponentModel;


ClubList clubList = new ClubList();
SingleClubMember single = new SingleClubMember();
MultiClubMember multi = new MultiClubMember();
MemberList singleClubList= new MemberList();
MemberList multiClubList= new MemberList();
List<SingleClubMember> singleClubMembers = new List<SingleClubMember>();
List<MultiClubMember> multiClubMembers = new List<MultiClubMember>();



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
        /*case 4:
            GenerateBill();*/
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
        foreach (Club club in clubList.ClubInfo) { Console.WriteLine($"{counter}. {club.Name} - {club.Address}"); counter++; }
        int clubIndex = int.Parse(Console.ReadLine()) - 1;
        
        single.AssignedClub = clubList.ClubInfo[clubIndex];
        MemberList singleClub = new MemberList();
        singleClubMembers = singleClub.AddSingleClubMember(single);
        /*foreach (SingleClubMember singleClubMember in singleClubMembers)
        {
            Console.WriteLine(singleClubMember);
        }*/
        Console.WriteLine("Member added successfully.");
    }
    else if (memberType == 2)
    {
        multi.Name = name;
        MemberList multiClub = new MemberList();
        multiClubMembers = multiClub.AddMultiClubMember(multi);
       /* foreach (MultiClubMember multiClubMember in multiClubMembers)
        {
            Console.WriteLine(multiClubMember);
        }*/
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
    Console.WriteLine("Enter member name to be removed:");
    string userInputName = Console.ReadLine().Trim();
    SingleClubMember singleMemberFound = singleClubMembers.Find(x => x.Name == userInputName);
    MultiClubMember multiMemberFound = multiClubMembers.Find(x => x.Name == userInputName);
    if (singleMemberFound != null)
    {
        Console.WriteLine($"Are you sure you want to remove member: {userInputName}, Single Club Member? Y/N");
        if (Console.ReadLine() == "y")
        {
            singleClubList.RemoveSingleClubMember(userInputName);
            Console.WriteLine($"Member {userInputName} has been removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid input, try again.");
        }    
    }
    else if (multiMemberFound != null)
    {
        Console.WriteLine($"Are you sure you want to remove member: {userInputName}, Multi Club Member? Y/N");
        if (Console.ReadLine() == "y")
        {
            multiClubList.RemoveMultiClubMember(userInputName);
            Console.WriteLine($"Member {userInputName} has been removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid input, try again.");
        }
     
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
    string userInputName = Console.ReadLine().Trim();
    SingleClubMember singleMemberFound = singleClubMembers.Find(x => x.Name == userInputName);
    MultiClubMember multiMemberFound = multiClubMembers.Find(x => x.Name == userInputName);
    if (singleMemberFound != null)
    {
        int counter = 1;
        Console.WriteLine($"The member you are checking in is {userInputName}. The membership type is Single Club Member.");
        Console.WriteLine("Select a club to check in");
        foreach (Club clubInfo in clubList.ClubInfo) { Console.WriteLine($"{counter}. {clubInfo.Name} - {clubInfo.Address}"); counter++; }
        int clubIndex = int.Parse(Console.ReadLine()) - 1;
        Club club = new Club(clubList.ClubInfo[clubIndex].Id,clubList.ClubInfo[clubIndex].Name, clubList.ClubInfo[clubIndex].Address);
        single.CheckIn(club);
    }
    else if (multiMemberFound != null)
    {
        int counter = 1;
        Console.WriteLine($"The member you are checking in is {userInputName}. The membership type is Multi Club Member.");
        Console.WriteLine("Select a club to check in");
        foreach (Club clubInfo in clubList.ClubInfo) { Console.WriteLine($"{counter}. {clubInfo.Name} - {clubInfo.Address}"); counter++; }
        int clubIndex = int.Parse(Console.ReadLine()) - 1;
        Club club = new Club(clubList.ClubInfo[clubIndex].Id, clubList.ClubInfo[clubIndex].Name, clubList.ClubInfo[clubIndex].Address);
        multi.CheckIn(club);
    }
    else
    {
        Console.WriteLine("Member not found.");
    }
}
    

// Method to generate bill of fees
/*void GenerateBill()
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
}*/