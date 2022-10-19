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

            AuctionDb adb = new AuctionDb
            {
                Id = -1, // from seed data
                Name = "Diamond Necklace",
                Describtion = "Necklace from 1890",
                StartingBid = 10000,
                CreatedDate = DateTime.Now,
                UserName = "zaedn@kth.se",
                Status = Core.Status.IN_PROGRESS,
                BidDbs = new List<BidDb>()
            };
            modelBuilder.Entity<AuctionDb>().HasData(adb);

            BidDb bdb = new BidDb
            {
                Id = -1, // from seed data
                Amount = 10500,
                BidTime = DateTime.Now,
                AuctionId = -1
            };
            modelBuilder.Entity<BidDb>().HasData(bdb);
            /*modelBuilder.Entity<AuctionDb>().HasData(
                new AuctionDb
                {
                    Id = -1, // from seed data
                    Name = "Diamond Necklace",
                    Describtion = "Necklace from 1890",
                    StartingBid = 10000,
                    CreatedDate = DateTime.Now,
                    UserName = "zaedn@kth.se",
                    Status = Core.Status.IN_PROGRESS
                });

            modelBuilder.Entity<BidDb>().HasData(new BidDb
            {
                Id = -1, // from seed data
                Amount = 10500,
                BidTime = DateTime.Now,
                AuctionId = -1
            });*/
        }
    }
}
