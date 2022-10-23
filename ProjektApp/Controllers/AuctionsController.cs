using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.ViewModels;

namespace ProjectApp.Controllers
{
    [Authorize]
    public class AuctionsController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: AuctionsController/Auctions
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAll();
            List<Auction> auctionsInProgress = new List<Auction>();
            
            foreach (Auction auction in auctions)
            {
                if (auction.IsInProgress()) auctionsInProgress.Add(auction);
            }
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctionsInProgress)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/Auctions/UserAuctions
        public ActionResult UserAuctions()
        {
            string? userName = User.Identity.Name; // should be unique
            List<Auction> auctions = _auctionService.GetAllByUserName(userName);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                if (!auction.IsInProgress())
                {
                    int bid2 = 0;
                    foreach (var bid in auction.Bids)
                    {
                        if (bid.Amount > bid2)
                        {
                            auction.Winner = bid.BidOwner;
                        }
                        bid2 = bid.Amount;
                    }
                }
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/Auctions/WonAuctions
        public ActionResult WonAuctions()
        {
            string? userName = User.Identity.Name; // should be unique
            List<Auction> auctions = _auctionService.GetAll();
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                if (!auction.IsInProgress())
                {
                    int bid2 = 0;
                    foreach (var bid in auction.Bids)
                    {
                        if (bid.Amount > bid2)
                        {
                            auction.Winner = bid.BidOwner;
                        }
                        bid2 = bid.Amount;
                    }
                }
                if (auction.Winner == userName) auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/Auctions/YourBidAuctions
        public ActionResult YourBidAuctions()
        {
            string? userName = User.Identity.Name; // should be unique

            List<Auction> auctions = _auctionService.GetAll();
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                if (auction.IsInProgress())
                {
                    foreach (var bid in auction.Bids)
                    {
                        if (bid.BidOwner == userName)
                        {
                            auctionVMs.Add(AuctionVM.FromAuction(auction));
                            break;
                        }
                    }
                }
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/Auctions/Details/id
        public ActionResult Details(int id)
        {
            Auction auction = _auctionService.GetById(id);
            if (auction == null) return NotFound();
            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return View(detailsVM);
        }

        // GET: AuctionsController/Auctions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionsController/Auctions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuctionCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                Auction auction = new Auction()
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    StartingBid = vm.StartingBid,
                    EndingDate = vm.EndingDate,
                    AuctionOwner = User.Identity.Name,
                };
                _auctionService.Add(auction);
                return RedirectToAction("Index");

            }
            return View(vm);
        }

        // GET: AuctionsController/Auctions/AddBid/5
        public ActionResult AddBid()
        {
            return View();
        }

        // GET: AuctionsController/Auctions/AddBid/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBid(int id, AddBidVM vm)
        {
            if (ModelState.IsValid)
            {
                if (!IsUser(id)) return BadRequest();
                Auction auction = _auctionService.GetById(id);
                Bid bid = new Bid()
                {
                    Amount = vm.Amount,
                    BidOwner = User.Identity.Name,
                };
                auction.Winner = User.Identity.Name;
                bool checkBid = _auctionService.AddBid(auction, bid);
                if (!checkBid)
                {
                    TempData["Status"] = "Bid must be higher than the earlier bids/startingbid!";
                    return RedirectToAction("AddBid");
                } else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }

        // GET: AuctionsController/Auctions/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: AuctionsController/Auctions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditVM vm)
        {
            if (ModelState.IsValid)
            {
                if (IsUser(id)) return BadRequest();
                _auctionService.EditAuctionDescription(id, vm.Description);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        private Boolean IsUser(int id)
        {
            Auction auction = _auctionService.GetById(id);
            if (!auction.AuctionOwner.Equals(User.Identity.Name)) return true;
            return false;
        }
    }
}
