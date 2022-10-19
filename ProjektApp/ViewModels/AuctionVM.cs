using Microsoft.AspNetCore.Components.Web;
using ProjectApp.Core;

namespace ProjectApp.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Describtion { get; set; }
        public int StartingBid { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? UserName { get; set; }
        public bool IsInProgress { get; set; }
        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Describtion = auction.Describtion,
                StartingBid = auction.StartingBid,
                CreatedDate = auction.CreatedDate,
                UserName = auction.UserName,
                IsInProgress = auction.IsInProgress()
            };
        }
    }
}
