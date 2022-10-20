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
        public string? Description { get; set; }

        [Required]
        public int StartingBid { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndingDate { get; set; }

        [Required]
        [MaxLength(128)]
        public String? AuctionOwner { get; set; }

        [Required]
        [MaxLength(128)]
        public String? Winner { get; set; }

        /*[Required]
        public Status Status { get; set; }*/

        public IEnumerable<BidDb> BidDbs { get; set; } = new List<BidDb>();
    }
}
