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
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/Auctions/
        public ActionResult UserAuctions()
        {
            string? userName = User.Identity.Name; // should be unique
            List<Auction> auctions = _auctionService.GetAllByUserName(userName);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }
        
        // GET: AuctionsController/Details/id
        public ActionResult Details(int id)
        {
            Auction auction = _auctionService.GetById(id);
            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return View(detailsVM);
        }

        // GET: AuctionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionsController/Create
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
                    UserName = User.Identity.Name,
                    Status = Status.IN_PROGRESS
                };
                _auctionService.Add(auction);
                return RedirectToAction("Index");

            }
            return View(vm);
        }
        
        // GET: AuctionsController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: AuctionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditVM vm)
        {
            if (ModelState.IsValid)
            {
                _auctionService.EditAuctionDescription(id, vm.Description);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        /*
        // GET: AuctionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
