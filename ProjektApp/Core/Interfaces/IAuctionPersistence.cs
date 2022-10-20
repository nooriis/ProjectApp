namespace ProjectApp.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAll();
        //List<Auction> GetAllByUserName(string userName);
        Auction GetById(int id);
        void Add(Auction auction);

        void AddBid(Auction auction, Bid bid);
        void EditAuctionDescription(int id, string newDescription);
    }
}

