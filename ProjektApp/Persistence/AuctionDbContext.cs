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
            modelBuilder.Entity<AuctionDb>().HasData(
                new AuctionDb
                {
                    Id = -1, // from seed data
                    Name = "Diamond Necklace",
                    Description = "Necklace from 1890",
                    StartingBid = 10000,
                    CreatedDate = DateTime.Now,
                    Status = Core.Status.IN_PROGRESS,
                    BidDbs = new List<BidDb>()
                });
            var bdb = new BidDb()
            {
                Id = -1,
                Amount = 11000,
                BidTime = DateTime.Now,
                AuctionId = -1
            };
            modelBuilder.Entity<BidDb>().HasData(bdb);
            var bdb2 = new BidDb()
            {
                Id = -2,
                Amount = 13000,
                BidTime = new DateTime(),
                AuctionId = -1
            };
            modelBuilder.Entity<BidDb>().HasData(bdb2);

        }
    }
}
