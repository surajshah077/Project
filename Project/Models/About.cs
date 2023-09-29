using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        //public string Description { get; set; }
        [ValidateNever]
        public string Image { get; set; }
      public DateTime JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Please enter the title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the TDescription")]
        public string TDescription { get; set; }

    }
}
