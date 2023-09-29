using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Contact
    {
        [Key]
        public int contactId { get; set; }
        public string contactTitle { get; set; }
        public string YourName { get; set; }
        public string YourEmail { get; set; }
        public int YourPhone { get; set; }
        public string YourMessage { get; set; }
        public string contactButtonText { get; set; }
    }
}
