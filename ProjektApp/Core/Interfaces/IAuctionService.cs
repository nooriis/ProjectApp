namespace ProjectApp.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        List<Auction> GetAllByUserName(string userName);
        Auction GetById(int id);
        void Add(Auction auction);
        bool AddBid(Auction auction, Bid bid);
        void EditAuctionDescription(int id, string newDescription);
    }
}
