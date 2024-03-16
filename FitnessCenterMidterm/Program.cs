using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

// Represents a fitness center
class FitnessCenter
{
    private List<Member> members = new List<Member>();
    private List<Club> clubs = new List<Club>();
    private List<int> memberIds = new List<int>(); // List to store member IDs
    private const string MembersFileName = "members.txt";
    private const string ClubsFileName = "clubs.txt";

    // Constructor to initialize the fitness center
    public FitnessCenter()
    {
        // Load clubs from file or add them manually
        clubs.Add(new Club("Club A", "Address A"));
        clubs.Add(new Club("Club B", "Address B"));
        clubs.Add(new Club("Club C", "Address C"));
        clubs.Add(new Club("Club D", "Address D"));
    }

    // Save members to a file
    private void SaveMembers()
    {
        using (StreamWriter writer = new StreamWriter(MembersFileName))
        {
            foreach (Member member in members)
            {
                writer.WriteLine($"{member.Id},{member.Name},{member.GetType().Name},{(member is SingleClubMember singleClubMember ? singleClubMember.Club.Name : "")}");
            }
        }
    }

    // Load members from a file
    private void LoadMembers()
    {
        if (File.Exists(MembersFileName))
        {
            using (StreamReader reader = new StreamReader(MembersFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string type = parts[2];
                    string clubName = parts.Length > 3 ? parts[3] : null;

                    Member newMember;
                    switch (type)
                    {
                        case "SingleClubMember":
                            Club club = null;
                            if (!string.IsNullOrEmpty(clubName))
                                club = clubs.Find(c => c.Name == clubName);
                            if (club == null)
                                throw new InvalidOperationException($"Club '{clubName}' not found.");
                            newMember = new SingleClubMember(name, club) { Id = id };
                            break;
                        case "MultiClubMember":
                            newMember = new MultiClubMember(name) { Id = id };
                            break;
                        default:
                            throw new InvalidOperationException("Invalid member type found in file.");
                    }
                    members.Add(newMember);
                }
            }
        }
    }

    // Save clubs to a file
    private void SaveClubs()
    {
        using (StreamWriter writer = new StreamWriter(ClubsFileName))
        {
            foreach (Club club in clubs)
            {
                writer.WriteLine($"{club.Name},{club.Address}");
            }
        }
    }

    // Load clubs from a file
    private void LoadClubs()
    {
        if (File.Exists(ClubsFileName))
        {
            using (StreamReader reader = new StreamReader(ClubsFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    string address = parts[1];
                    clubs.Add(new Club(name, address));
                }
            }
        }
    }

    // Add a new member asks to enter name, select membership type, select club with list of clubs
    //displays Member added successfully with Membership Number
    //Should add membership type to the console write line
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
                if (clubIndex < 0 || clubIndex >= clubs.Count)
                {
                    Console.WriteLine("Invalid club number.");
                    return;
                }
                Club selectedClub = clubs[clubIndex];
                newMember = new SingleClubMember(name, selectedClub);
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
        SaveMembers(); // Save the new member to file
    }

   

// Remove a member
public void RemoveMember()
{
    Console.Write("Enter member id to remove: ");
    int memberId = int.Parse(Console.ReadLine());
    Member memberToRemove = members.FirstOrDefault(m => m.Id == memberId);
    if (memberToRemove != null)
    {
        members.Remove(memberToRemove);
        SaveMembers(); // Save the updated member list to file
        Console.WriteLine("Member removed successfully.");
    }
    else
    {
        Console.WriteLine("Member not found.");
    }
}

// Display information of a member
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

// Check a member into a club
//Check in asks for membership number, select the club to check into, if correct club, check in successful
public void CheckMemberIn()
{
    Console.Write("Enter membership number: ");
    string memberIdInput = Console.ReadLine();

    if (!int.TryParse(memberIdInput, out int memberId))
    {
        Console.WriteLine("Invalid membership number. Please enter a valid number.");
        return;
    }

    Member member = members.Find(m => m.Id == memberId);
    if (member != null)
    {
        Console.WriteLine("Select club to check-in:");
        for (int i = 0; i < clubs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {clubs[i].Name}");
        }

        Console.Write("Enter club number: ");
        if (!int.TryParse(Console.ReadLine(), out int clubIndex) || clubIndex < 1 || clubIndex > clubs.Count)
        {
            Console.WriteLine("Invalid club number.");
            return;
        }
        clubIndex--; // Adjusting for zero-based indexing

        Club selectedClub = clubs[clubIndex];

        if (member is SingleClubMember singleClubMember)
        {
            if (singleClubMember.Club != selectedClub)
            {
                Console.WriteLine("You are not allowed to check-in at this club.");
                return;
            }
        }

        try
        {
            member.CheckIn(selectedClub);
            Console.WriteLine("Check-in successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Invalid membership number. Please check your membership number and try again.");
    }
}


internal void GenerateBill()
{
    throw new NotImplementedException();
}
}
