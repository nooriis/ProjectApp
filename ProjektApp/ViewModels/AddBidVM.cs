using ProjectApp.Persistence;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.ViewModels
{
    public class AddBidVM
    {

        [Required(ErrorMessage ="Amount is required")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than the highest bid.")]
        public int Amount { get; set; }

        

       
    }
}
