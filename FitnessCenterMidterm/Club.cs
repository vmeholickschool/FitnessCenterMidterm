namespace FitnessCenterMidterm
{
    public class Club
    {
        public string Address { get; set; }
        public string Name { get; set; }

        public int ClubNumber { get; set; }
        public Club(string name, string address,int clubNumber) 
        { 
            Name = name;
            Address = address;
            ClubNumber = clubNumber;
        }
    }
}