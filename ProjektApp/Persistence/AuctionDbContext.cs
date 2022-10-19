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
                    Describtion = "Necklace from 1890",
                    StartingBid = 10000,
                    CreatedDate = DateTime.Now,
                    Status = Core.Status.IN_PROGRESS
                }); 
        }
    }
}
