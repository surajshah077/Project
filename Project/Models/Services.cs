using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }
     
        public string Topic {  get; set; }
        public string Description { get; set; }
        [ValidateNever]
        public string? Logo { get; set; }
    }
}
