using System.Threading.Tasks;

namespace ProjectApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int StartingBid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string? AuctionOwner { get; set; }
        public string? Winner { get; set; }

        private List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;
        public Auction(int id, string name, string description, DateTime endingDate, int startingBid)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedDate = DateTime.Now;
            EndingDate = endingDate;
            StartingBid = startingBid;
        }
        public Auction(string name)
        {
            Name = name;
            CreatedDate = DateTime.Now;
        }
        public Auction()
        {

        }
        public void AddBid(Bid newBid)
        {
            _bids.Add(newBid);
        }

        public bool IsInProgress()
        {
            if (DateTime.Now < EndingDate) return true;
            return false;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - Description: {Description}";
        }
    }
}
