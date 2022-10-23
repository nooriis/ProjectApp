using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<BidDb> BidDbs { get; set; }
        public DbSet<AuctionDb> AuctionDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*AuctionDb adb = new AuctionDb
            {
                Id = -1, // from seed data
                Name = "Diamond Necklace",
                Description = "Necklace from 1890",
                StartingBid = 10000,
                CreatedDate = DateTime.Now,
                EndingDate = DateTime.Now,
                AuctionOwner = "zaedn@kth.se",
                Winner = "None",
                //Status = Core.Status.IN_PROGRESS,
                BidDbs = new List<BidDb>()
            };
            modelBuilder.Entity<AuctionDb>().HasData(adb);

            BidDb bdb = new BidDb()
            {
                Id = -1, // from seed data
                Amount = 10500,
                BidTime = DateTime.Now,
                BidOwner = "fendi",
                AuctionId = -1
            };
            modelBuilder.Entity<BidDb>().HasData(bdb);

            BidDb bdb2 = new BidDb()
            {
                Id = -2, // from seed data
                Amount = 13000,
                BidTime = DateTime.Now,
                BidOwner = "zaed",
                AuctionId = -1
            };
            modelBuilder.Entity<BidDb>().HasData(bdb2);*/
        }
    }
}
