using ProjectApp.Core;

namespace ProjectApp.ViewModels
{
    public class AuctionDetailsVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int StartingBid { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsInProgress { get; set; }
        public List<BidVM> BidVMs { get; set; } = new();

        public static AuctionDetailsVM FromAuction(Auction auction)
        {
            var detailsVM = new AuctionDetailsVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                StartingBid = auction.StartingBid,
                CreatedDate = auction.CreatedDate,
                IsInProgress = auction.IsInProgress(),

            };
            foreach (var bid in auction.Bids)
            {
                detailsVM.BidVMs.Add(BidVM.FromBid(bid));
            }
            return detailsVM;
        }
    }
}