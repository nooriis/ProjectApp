using AutoMapper;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using System.Diagnostics;

namespace ProjectApp.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;

        public AuctionSqlPersistence(AuctionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Auction> GetAll()
        {
            var auctionDbs = _dbContext.AuctionDbs.ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }
            return result;
        }
        /*public List<Auction> GetAllByUserName(string userName)
        {
            var auctionDbs = _dbContext.AuctionDbs
            .Where(a => a.AuctionOwner.Equals(userName)) // updated for Identity
            .ToList();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDb adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }
            return result;
        }*/

        public Auction GetById(int id)
        {
            var auctionDb = _dbContext.AuctionDbs
               .Include(a => a.BidDbs.OrderByDescending(b => b.Amount))
               .Where(a => a.Id == id)
               .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDb);
            foreach (BidDb bdb in auctionDb.BidDbs)
            {
                auction.AddBid(_mapper.Map<Bid>(bdb));
            }
            return auction;
        }

        public void Add(Auction auction)
        {
            AuctionDb adb = _mapper.Map<AuctionDb>(auction);
            _dbContext.Add(adb);
            _dbContext.SaveChanges();
        }

        public void AddBid(Auction auction, Bid bid)
        {
            AuctionDb adb = _mapper.Map<AuctionDb>(auction);
            BidDb bdb = _mapper.Map<BidDb>(bid);
            bdb.AuctionId = adb.Id;
            _dbContext.Add(bdb);
            _dbContext.SaveChanges();
        }

        public void EditAuctionDescription(int id, string newDescription)
        {
            var adb = _dbContext.AuctionDbs.Where(a => a.Id == id)
               .SingleOrDefault();
            adb.Description = newDescription;     
            _dbContext.SaveChanges();
        }
    }
}
