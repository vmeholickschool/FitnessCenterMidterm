using FitnessCenterMidterm;
using Umbraco.Core.Models;

public class Program


{
    static void Main(string[] args)
    {
        FitnessCenter fitnessCenter = new FitnessCenter();
        bool continueRunning = true;
        List<Member> members = new List<Member>();
        List<Club> clubs = new List<Club>();

        //welcome statement
        Console.WriteLine("Welcome to Fitness Forever's Member Information Tracker!");
        Console.WriteLine();
        
      

        while (continueRunning)
        {
            Console.WriteLine("Please select from the options below:");
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Remove Member");
            Console.WriteLine("3. Display Member Information");
            Console.WriteLine("4. Check Member In");
            Console.WriteLine("5. Generate Bill of Fees");
            Console.WriteLine("6. Exit");
            Console.Write("> Enter your choice(1-6): ");
            string choice = Console.ReadLine();
            Console.WriteLine();


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
                    Console.WriteLine();
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
        clubs.Add(new Club("Fitness Forever - Troy", "Address A"));
        clubs.Add(new Club("Fitness Forever - Saint Clair Shores", "Address B"));
        clubs.Add(new Club("Fitness Forever - Lake Orion", "Address C"));
        clubs.Add(new Club("Fitness Forever - Detroit", "Address D"));
    }
    public void AddMember()
    {
        Console.Write("> Type member name: ");
        string name = Console.ReadLine();
        Console.WriteLine();
        
        Console.WriteLine("Select membership type:");
        Console.WriteLine("1. Single Club Member");
        Console.WriteLine("2. Multi-Club Member");
        Console.Write("> Enter membership type: ");
        string membershipTypeChoice = Console.ReadLine();
        Console.WriteLine();


        Member newMember;
        switch (membershipTypeChoice)
        {
            case "1":
                Console.WriteLine($"Select club: ");
                for (int i = 0; i < clubs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clubs[i].Name}");
                }
                
                Console.Write($"> Enter club number(1-{clubs.Count}): ");
                int clubIndex = int.Parse(Console.ReadLine()) - 1;
                string membershipNumber = GenerateMembershipNumber().ToString();// Generate membership number
                
                newMember = new SingleClubMember(name, clubs[clubIndex], membershipNumber.ToString);
                newMember.Id = int.Parse(membershipNumber);
                break;
            case "2":
                newMember = new MultiClubMember(name);
                
                break;
            default:
                Console.WriteLine("Invalid membership type.");
                
                return;
        }
        

        members.Add(newMember);
        Console.WriteLine() ;
        Console.WriteLine($"Member {name} added successfully. Membership Number: {newMember.Id}");
        Console.WriteLine();
    }

    internal int GenerateMembershipNumber()
    {
        return ++lastMembershipNumber; // Increment and return the last membership number
    }
/*
   internal int GenerateMemberId()
    {
        return members.Count + 1; // Generate and return a new member ID
    }
 */



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
        Console.Write("> Enter Member Id to remove: ");
        int memberId = int.Parse(Console.ReadLine());
        Console.WriteLine();

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
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Member not found.");
            Console.WriteLine();
        }
    }

    public void DisplayMemberInformation()
    {
        Console.Write("> Enter member id: ");
        int memberId = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Member member = members.Find(m => m.Id == memberId);
        if (member != null)
        {
            Console.WriteLine($"Member Name: {member.Name}");
            Console.WriteLine($"Member Type: {member.GetType().Name}");
            
            
            
            Console.WriteLine();
            if (member is MultiClubMember multiClubMember)
            {
                Console.WriteLine($"Membership Points: {multiClubMember.MembershipPoints}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Member not found.");
            Console.WriteLine();
        }
    }

    public void CheckMemberIn()
    {
        Console.Write("> Enter member id: ");
        int memberId = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Member member = members.Find(m => m.Id == memberId);
        if (member != null)
        {
            if (member is SingleClubMember singleClubMember)
            {
                // single club members can check in to any club
                Console.WriteLine("Select club to check-in:");
                for (int i = 0; i < clubs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clubs[i].Name}");
                }
                Console.WriteLine();

                Console.Write("> Enter club number: ");
                int clubIndex = int.Parse(Console.ReadLine()) - 1;

                singleClubMember.CheckIn(clubs[clubIndex]);


            }
            else if (member is MultiClubMember multiClubMember)
            {
                // Multi club members can check in to any club
                Console.WriteLine("Select club to check-in:");
                for (int i = 0; i < clubs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clubs[i].Name}");
                }
               Console.WriteLine();

                Console.Write("> Enter club number: ");
                int clubIndex = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine();
                multiClubMember.CheckIn(clubs[clubIndex]);
            }
            else
            {
                Console.WriteLine("Invalid member type.");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Member not found.");
            Console.WriteLine();
        }
    }


}



















