using System.Xml.Linq;
class MultiClubMember : Member
{
    public int MembershipPoints { get; private set; }

    public MultiClubMember(string name, int membershipNumber) : base(name)
    {
        MembershipPoints = 0;
    }

    public MultiClubMember(string name, string membershipNumber) : base(name)
    {
    }

    public MultiClubMember(string name) : base(name)
    {
     }

        public void CheckIn(Club selectedClub)
        {

        }
    }



