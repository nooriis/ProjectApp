using Microsoft.AspNetCore.Components.Web;
using ProjectApp.Core;

namespace ProjectApp.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int StartingBid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string? AuctionOwner { get; set; }
        public string? Winner { get; set; }
        public bool IsInProgress { get; set; }
        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                StartingBid = auction.StartingBid,
                CreatedDate = auction.CreatedDate,
                EndingDate = auction.EndingDate,
                AuctionOwner = auction.AuctionOwner,
                Winner = auction.Winner,
                IsInProgress = auction.IsInProgress()
            };
        }
    }
}
