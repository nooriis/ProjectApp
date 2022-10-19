using System.Threading.Tasks;

namespace ProjectApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Describtion { get; set; }

        public int StartingBid { get; set; }
        public DateTime CreatedDate { get; }

        private Status _status;
        public Status Status
        {
            get => _status;
            set
            {
                if (_status == Status.DONE) throw new InvalidOperationException("Auction is over");
                _status = value;
                //_bidTime = DateTime.Now;
            }
        }

        private List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;
        public Auction(int id, string name, string description, int startingBid, Status status = Status.IN_PROGRESS)
        {
            Id = id;
            Name = name;
            Describtion = description;
            CreatedDate = DateTime.Now;
            StartingBid = startingBid;
            _status = status;
        }
        public Auction(string name, Status status = Status.IN_PROGRESS)
        {
            Name = name;
            CreatedDate = DateTime.Now;
            _status = status;
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
            if (Status == Status.IN_PROGRESS) return true;
            return false;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - Description: {Describtion}";
        }
    }
}
