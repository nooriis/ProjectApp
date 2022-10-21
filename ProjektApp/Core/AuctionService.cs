using ProjectApp.Core.Interfaces;

namespace ProjectApp.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersistence;

        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }

        public List<Auction> GetAll()
        {
            return _auctionPersistence.GetAll();
        }

        public List<Auction> GetAllByUserName(string userName)
        {
            return _auctionPersistence.GetAllByUserName(userName);
        }

        public Auction GetById(int id)
        {
            return _auctionPersistence.GetById(id);
        }

        public void Add(Auction auction)
        {
            //assume no bid is new auction
            if (auction == null || auction.Id != 0)
            {
                throw new InvalidDataException();
            }
            auction.CreatedDate = DateTime.Now;
            auction.Winner = "None";
            _auctionPersistence.Add(auction);
        }

        public void AddBid(Auction auction, Bid bid)
        {
            if (auction == null || bid == null || bid.Amount < auction.StartingBid||DateTime.Now>auction.EndingDate)
            {
                throw new InvalidDataException();
            }
            foreach (var b in auction.Bids)
            {
                if (bid.Amount <= b.Amount) throw new InvalidCastException();
            }
        
            bid.BidTime = DateTime.Now;
           _auctionPersistence.AddBid(auction, bid);
        }

        public void EditAuctionDescription(int id, string newDescription)
        {
            if (String.IsNullOrEmpty(id.ToString()) || newDescription == null)
            {
                throw new InvalidDataException();
            }
            _auctionPersistence.EditAuctionDescription(id, newDescription);
        }
    }
}
