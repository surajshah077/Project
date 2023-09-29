using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Services> services { get; set; }
        public DbSet<Portfolio> portfolio { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<CodeTable> staticData { get; set; }
        public DbSet<Register> register { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeTable>().HasData(
                new CodeTable
                {
                    Id = 1010,
                    HomeLogo = "/images/startBootstrap.png",
                    firstHeading = "Welcome To Our Studio!",
                    SecondHeading = "IT'S NICE TO MEET YOU",
                    buttonText = "TELL ME MORE",
                    Services = "SERVICES",
                    serviceTitle = "Lorem ipsum dolor sit amet consectetur.",
                    Portfolio = "PORTFOLIO",
                    portfolioTitle = "Lorem ipsum dolor sit amet consectetur.",
                    About = "ABOUT",
                    aboutTitle = "Lorem ipsum dolor sit amet consectetur.",
                    Team = "OUR AMAZING TEAM",
                    teamTitle = "Lorem ipsum dolor sit amet consectetur.",
                    teamDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aut eaque, laboriosam veritatis, quos non quis ad perspiciatis, totam corporis ea, alias ut unde.",
                    Contact = "CONTACT US",
                    contactTitle = "Lorem ipsum dolor sit amet consectetur.",
                    YourName = "Suraj Shah",
                    YourEmail = "suraj@gmail.com",
                    YourPhone = "9808300810",
                    YourMessage = "Wow!",
                    contactButtonText = "Send Messsage"
                }
                );
        }
    }
}
