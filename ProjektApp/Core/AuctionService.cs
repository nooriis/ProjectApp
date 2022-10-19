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

        public List<Auction> GetAllByUserName(string userName)
        {
            return _auctionPersistence.GetAllByUserName(userName);
        }
    }
}
