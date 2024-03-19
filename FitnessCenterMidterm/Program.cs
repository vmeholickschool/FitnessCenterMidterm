﻿using FitnessCenterMidterm;
using Umbraco.Core.Models;

public class Program


{
    static void Main(string[] args)
    {
        FitnessCenter fitnessCenter = new FitnessCenter();
        bool continueRunning = true;
        List<Member> members = new List<Member>();
        List<Club> clubs = new List<Club>();

        while (continueRunning)
        {
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Remove Member");
            Console.WriteLine("3. Display Member Information");
            Console.WriteLine("4. Check Member In");
            Console.WriteLine("5. Generate Bill of Fees");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();



            switch (choice)
            {
                case "1":
                    fitnessCenter.AddMember();
                    break;
                case "2":
                    fitnessCenter.RemoveMember();
                    break;
                case "3":
                    fitnessCenter.DisplayMemberInformation();
                    break;
                case "4":
                    fitnessCenter.CheckMemberIn();
                    break;
                case "5":
                    fitnessCenter.GenerateBill();
                    break;
                case "6":
                    continueRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }
        }

    }

}

internal class FitnessCenter
{
    private List<Member> members = new List<Member>();
    private List<Club> clubs = new List<Club>();
    private static int lastMembershipNumber = 0;



    public FitnessCenter()
    {
        // Add some clubs
        clubs.Add(new Club("Club A", "Address A"));
        clubs.Add(new Club("Club B", "Address B"));
        clubs.Add(new Club("Club C", "Address C"));
        clubs.Add(new Club("Club D", "Address D"));
    }
    public void AddMember()
    {
<<<<<<< Updated upstream
        Console.Write("Enter member name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Select membership type:");
        Console.WriteLine("1. Single Club Member");
        Console.WriteLine("2. Multi-Club Member");
        Console.Write("Enter membership type: ");
        string membershipTypeChoice = Console.ReadLine();


        Member newMember;
        switch (membershipTypeChoice)
=======
        multi.Name = name;
        MemberList multiClub = new MemberList();

        multiClubMembers=multiClub.AddMultiClubMember(multi);
        
       /* foreach (MultiClubMember multiClubMember in multiClubMembers)
>>>>>>> Stashed changes
        {
            case "1":
                Console.WriteLine("Select club:");
                for (int i = 0; i < clubs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clubs[i].Name}");
                }
                Console.Write("Enter club number: ");
                int clubIndex = int.Parse(Console.ReadLine()) - 1;
                string membershipNumber = GenerateMembershipNumber().ToString();// Generate membership number
                newMember = new SingleClubMember(name, clubs[clubIndex], membershipNumber.ToString);
                break;
            case "2":
                newMember = new MultiClubMember(name);
                break;
            default:
                Console.WriteLine("Invalid membership type.");
                return;
        }
        newMember.Id = members.Count + 1;

        members.Add(newMember);
        Console.WriteLine($"Member {name} added successfully. Membership Number: {newMember.MembershipNumber}");
    }
<<<<<<< Updated upstream

    internal int GenerateMembershipNumber()
    {
        return ++lastMembershipNumber; // Increment and return the last membership number
=======
    else
    {
        Console.WriteLine("Invalid member type");
>>>>>>> Stashed changes
    }

    internal int GenerateMemberId()
    {
        return members.Count + 1; // Generate and return a new member ID
    }



    public void GenerateBill()
    {
        Console.WriteLine("Generating bill of fees...");

        Console.Write("Enter membership number: ");
        string membershipNumber = Console.ReadLine();
        Member member = members.Find(m => m.MembershipNumber == membershipNumber);

        if (member != null)
        {
            double membershipFee = 0;
            int membershipPoints = 0;

            if (member is MultiClubMember multiClubMember)
            {
                // For MultiClubMember, use their specific membership points and fee calculation
                membershipFee = 100; // Example fee calculation for MultiClubMember
                membershipPoints = multiClubMember.MembershipPoints;
            }
            else if (member is SingleClubMember)
            {
                // For SingleClubMember, use a fixed fee and set membership points to 1
                membershipFee = 50; // Example fixed fee for SingleClubMember
                membershipPoints = 1;
            }

            Console.WriteLine($"Membership Fee: {membershipFee}");
            Console.WriteLine($"Membership Points: {membershipPoints}");

            // Create an instance of BillOfFees and print the bill
            BillOfFees bill = new BillOfFees(member, membershipFee, membershipPoints);
            bill.PrintBill();
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }



    public void RemoveMember()
    {
        Console.Write("Enter member id to remove: ");
        int memberId = int.Parse(Console.ReadLine());

        Member memberToRemove = default(Member);

        foreach (var member in members)
        {
            if (member.Id == memberId)
            {
                memberToRemove = member;
                break;
            }
        }

        if (memberToRemove != null)
        {
            object value = members.Remove(memberToRemove);
            Console.WriteLine("Member removed successfully.");
        }
        else
        {
<<<<<<< Updated upstream
            Console.WriteLine("Member not found.");
        }
=======
            Console.WriteLine("Invalid input, try again.");
        }   
>>>>>>> Stashed changes
    }

    public void DisplayMemberInformation()
    {
<<<<<<< Updated upstream
        Console.Write("Enter member id: ");
        int memberId = int.Parse(Console.ReadLine());
        Member member = members.Find(m => m.Id == memberId);
        if (member != null)
        {
            Console.WriteLine($"Member Name: {member.Name}");
            Console.WriteLine($"Member Type: {member.GetType().Name}");
            if (member is MultiClubMember multiClubMember)
            {
                Console.WriteLine($"Membership Points: {multiClubMember.MembershipPoints}");
            }
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }

    public void CheckMemberIn()
    {
        Console.Write("Enter member id: ");
        int memberId = int.Parse(Console.ReadLine());
        Member member = members.Find(m => m.Id == memberId);
        if (member != null)
        {
            if (member is SingleClubMember singleClubMember)
            {
                // Single club members can only check in to their assigned club
                Console.WriteLine($"Checking in member {member.Name} at {singleClubMember.Club.Name}");
            }
            else if (member is MultiClubMember)
            {
                // Multi club members can check in to any club
                Console.WriteLine("Select club to check-in:");
                for (int i = 0; i < clubs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clubs[i].Name}");
                }
                Console.Write("Enter club number: ");
                int clubIndex = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine($"Checking in member {member.Name} at {clubs[clubIndex].Name}");
            }
            else
            {
                Console.WriteLine("Invalid member type.");
            }
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }


}

=======
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
        Console.WriteLine($"The member you are checking in is {userInputName}. Membeship ID is {single.Id}. The membership type is Single Club Member.");
        Console.WriteLine("Select a club to check in");
        foreach (Club clubInfo in clubList.ClubInfo) { Console.WriteLine($"{counter}. {clubInfo.Name} - {clubInfo.Address}"); counter++; }
        int clubIndex = int.Parse(Console.ReadLine()) - 1;
        Club club = new Club(clubList.ClubInfo[clubIndex].Id,clubList.ClubInfo[clubIndex].Name, clubList.ClubInfo[clubIndex].Address);
        single.CheckIn(club);
    }
    else if (multiMemberFound != null)
    {
        int counter = 1;
        Console.WriteLine($"The member you are checking in is {userInputName}. Membeship ID is {single.Id}. The membership type is Multi Club Member.");
        Console.WriteLine("Select a club to check in");
        foreach (Club clubInfo in clubList.ClubInfo) { Console.WriteLine($"{counter}. {clubInfo.Name} - {clubInfo.Address}"); counter++; }
        int clubIndex = int.Parse(Console.ReadLine()) - 1;
        Club club = new Club(clubList.ClubInfo[clubIndex].Id, clubList.ClubInfo[clubIndex].Name, clubList.ClubInfo[clubIndex].Address);
        multi.CheckInMultiClub(userInputName,club);
    }
    else
    {
        Console.WriteLine("Member not found.");
    }
}
    
>>>>>>> Stashed changes


















