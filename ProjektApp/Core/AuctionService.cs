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

        public Auction GetById(int id)
        {
            return _auctionPersistence.GetById(id);
        }

        public void Add(Auction auction)
        {
            //assume no bid is new auction
            if(auction == null|| auction.Id != 0)
            {
                throw new InvalidDataException();
            }
            auction.CreatedDate = DateTime.Now;
            _auctionPersistence.Add(auction);
        }
    }
}
