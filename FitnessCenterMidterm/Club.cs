namespace FitnessCenterMidterm
{
    public class Club
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public Club(string name, string address) 
        { 
            Name = name;
            Address = address;
        }
    }
}