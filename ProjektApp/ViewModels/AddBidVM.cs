using System.ComponentModel.DataAnnotations;

namespace ProjectApp.ViewModels
{
    public class AddBidVM
    {
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public int Amount { get; set; }
    }
}
