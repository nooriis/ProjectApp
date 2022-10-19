﻿using Microsoft.AspNetCore.Components.Web;
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
                IsInProgress = auction.IsInProgress()
            };
        }
    }
}
