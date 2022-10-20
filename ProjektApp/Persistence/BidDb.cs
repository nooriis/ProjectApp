using ProjectApp.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApp.Persistence
{
    public class BidDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BidTime { get; set; }

        [Required]
        [MaxLength(128)]
        public String? BidOwner { get; set; }

        // FK and navigation property 
        [ForeignKey("AuctionId")]
        public AuctionDb AuctionDb { get; set; }

        public int AuctionId { get; set; }


    }
}
