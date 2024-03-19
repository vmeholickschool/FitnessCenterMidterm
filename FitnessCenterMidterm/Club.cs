namespace FitnessCenterMidterm
{
    public class Club
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public Club(int id,string name, string address) 
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}