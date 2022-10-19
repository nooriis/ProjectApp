using ProjectApp.Core;


namespace ProjectApp.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime BidTime { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                Id = bid.Id,
                Amount=bid.Amount,
                BidTime = bid.BidTime,
                
            }; 
        }
    }
}
