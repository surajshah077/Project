using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        [ValidateNever]
        public string Image { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string Category { get; set; }
    }
}
