namespace ProjectApp.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime BidTime { get; set; }
        public string? BidOwner { get; set; }
        public Bid(int id, int amount)
        {
            Id = id;
            Amount = amount;
            BidTime = DateTime.Now;
        }
        public Bid(int amount)
        {
            Amount = amount;
            BidTime = DateTime.Now;
        }
        public Bid()
        {
    
        }
        public override string ToString()
        {
            return $"{Id}: {Amount} - {BidTime}";
        }
    }
}
