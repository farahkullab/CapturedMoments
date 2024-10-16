namespace CapturedMoments.Models
{
    public class Session 
    {
        public int SessionId { get; set; }
        public string ClientFisrtName { get; set; }
        public string ClientLastName { get; set; }
        public decimal Price { get; set; }
        public DateOnly Date { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
    }
}
