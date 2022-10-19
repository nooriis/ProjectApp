using System.ComponentModel.DataAnnotations;

namespace ProjectApp.ViewModels
{
    public class EditVM
    {
        
        [Required]
        [StringLength(255, ErrorMessage = "Max length is 255 characters")]
        public string Description { get; set; }
    
    }
}
