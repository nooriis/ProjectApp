namespace ProjectApp.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public int Amount { get; }

        private DateTime _bidTime;
        public DateTime BidTime { get => _bidTime; }
        public Bid(int id, int amount)
        {
            Id = id;
            Amount = amount;
            _bidTime = DateTime.Now;
        }
        public Bid(int amount)
        {
            Amount = amount;
            _bidTime = DateTime.Now;
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
