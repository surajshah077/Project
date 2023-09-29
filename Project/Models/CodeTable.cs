using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Project.Models
{
    public class CodeTable
    {
        [Key]
        public int Id { get; set; }
        public string HomeLogo { get; set; }
        public string firstHeading { get; set; }
        public string SecondHeading { get; set; }
        public string buttonText { get; set; }
        public string Services { get; set; }
        public string serviceTitle { get; set; }
        public string Portfolio { get; set; }
        public string portfolioTitle { get; set; }
        public string About { get; set; }
        public string aboutTitle { get; set; }
        public string Team { get; set; }
        public string teamTitle { get; set; }
        public string teamDescription { get; set; }
        public string Contact { get; set; }
        public string contactTitle { get; set; }
        public string YourName { get; set; }
        public string YourEmail { get; set; }
        public string YourPhone { get; set; }
        public string YourMessage { get; set; }
        public string contactButtonText { get; set; }
    }
}
