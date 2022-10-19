using ProjectApp.Core;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Persistence
{
    public class AuctionDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Describtion { get; set; }

        [Required]
        public int StartingBid { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(128)]
        public String? UserName { get; set; }

        [Required]
        public Status Status { get; set; }

        public IEnumerable<BidDb> BidDbs { get; set; } = new List<BidDb>();
    }
}
