namespace Project.Models.ViewModels
{
    public class HomeVM
    {
        public List<Services> services { get; set; }
        public List<Portfolio> portfolio { get; set; }
        public List<About> about { get; set; }
        public List<Team> teams { get; set; }
        public CodeTable code { get; set; }
    }
}
