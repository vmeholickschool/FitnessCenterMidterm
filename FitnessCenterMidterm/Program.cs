using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        FitnessCenter fitnessCenter = new FitnessCenter();
        bool continueRunning = true;

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

class FitnessCenter
{
    private List<Member> members = new List<Member>();
    private List<Club> clubs = new List<Club>();

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
        Console.Write("Enter member name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Select membership type:");
        Console.WriteLine("1. Single Club Member");
        Console.WriteLine("2. Multi-Club Member");
        Console.Write("Enter membership type: ");
        string membershipTypeChoice = Console.ReadLine();

        Member newMember;
        switch (membershipTypeChoice)
        {
            case "1":
                Console.WriteLine("Select club:");
                for (int i = 0; i < clubs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clubs[i].Name}");
                }
                Console.Write("Enter club number: ");
                int clubIndex = int.Parse(Console.ReadLine()) - 1;
                newMember = new SingleClubMember(name, clubs[clubIndex]);
                break;
            case "2":
                newMember = new MultiClubMember(name);
                break;
            default:
                Console.WriteLine("Invalid membership type.");
                return;
        }

        members.Add(newMember);
        Console.WriteLine($"Member added successfully. Membership Number: {newMember.MembershipNumber}");
    }

    public void RemoveMember()
    {
        Console.Write("Enter member id to remove: ");
        int memberId = int.Parse(Console.ReadLine());
        Member memberToRemove = members.Find(m => m.Id == memberId);
        if (memberToRemove != null)
        {
            members.Remove(memberToRemove);
            Console.WriteLine("Member removed successfully.");
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }

    public void DisplayMemberInformation()
    {
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
            Console.WriteLine("Select club to check-in:");
            for (int i = 0; i < clubs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clubs[i].Name}");
            }
            Console.Write("Enter club number: ");
            int clubIndex = int.Parse(Console.ReadLine()) - 1;
            try
            {
                string membershipNumber = member.CheckIn(clubs[clubIndex]);
                Console.WriteLine($"Check-in successful. Membership Number: {membershipNumber}");
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

    public void GenerateBill()
    {
        Console.Write("Enter member id: ");
        var memberId = int.Parse(Console.ReadLine());
        Member member = members.Find(m => m.Id == memberId);
        if (member != null)
        {
            double fee = 50; // Assuming a fixed fee for all members
            int membershipPoints = 0;
            if (member is MultiClubMember)
            {
                membershipPoints = ((MultiClubMember)member).MembershipPoints;
                fee += membershipPoints * 0.1; // Arbitrary calculation for demonstration
            }
            Console.WriteLine($"Bill for member {member.Name}:");
            Console.WriteLine($"Membership Fee: ${fee}");
            Console.WriteLine($"Membership Points: {membershipPoints}");
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }
}