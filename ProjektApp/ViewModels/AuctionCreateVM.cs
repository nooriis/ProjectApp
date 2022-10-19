
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.ViewModels
{
    public class AuctionCreateVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max length is 128 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "Max length is 128 characters")]
        public string Description { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public int StartingBid { get; set; }

    }
}
