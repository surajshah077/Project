using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
   
      
        [ValidateNever]
        public string Image { get; set; }
        public string Name { get; set; }
        public string Degisnation { get; set; }
        [ValidateNever]
        public string Logo { get; set; }
      
    }
}
