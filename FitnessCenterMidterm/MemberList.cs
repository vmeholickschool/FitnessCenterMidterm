using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FitnessCenterMidterm
{
    public class MemberList
    {
        public List<SingleClubMember> SingleClubMembers {  get; set; }
        public List<MultiClubMember> MultiClubMembers { get; set; }

        public MemberList() 
        {
            SingleClubMembers = new List<SingleClubMember>();
            MultiClubMembers = new List<MultiClubMember>(); 
        }
       
        public List<SingleClubMember> AddSingleClubMember(SingleClubMember singleClub)
        {
            SingleClubMembers.Add(singleClub);
            return SingleClubMembers;
        }
        public List<SingleClubMember> RemoveSingleClubMember(string name)
        {
            foreach (SingleClubMember singleClub in SingleClubMembers.Where(x => x.Name == name))
            {
                SingleClubMembers.Remove(singleClub);
            }
            
            return SingleClubMembers;
        }
         public List<MultiClubMember> AddMultiClubMember(MultiClubMember multiClub)
        {
            MultiClubMembers.Add(multiClub);
            return MultiClubMembers;
        }
        public List<MultiClubMember> RemoveMultiClubMember(string name)
        {
            foreach (MultiClubMember multiClub in MultiClubMembers.Where(x => x.Name == name))
            {
                MultiClubMembers.Remove(multiClub);
            }
            
            return MultiClubMembers;
        }
       /* public void CheckIn(string name)
        {
            MultiClubMember multiClubMemberCheckin = MultiClubMembers.Find(x => x.Name == name);
            if (multiClubMemberCheckin != null)
            {
                multiClubMemberCheckin.MembershipPoints += 10;
            }
            ClubList club = new ClubList();
            Console.WriteLine($"{multiClubMemberCheckin.Name} checked in at {club.}. Membership points: {multiClubMemberCheckin.MembershipPoints}");
        }*/
    }

}
