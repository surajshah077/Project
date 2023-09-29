using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class completedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abouts", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    contactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contactTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourPhone = table.Column<int>(type: "int", nullable: false),
                    YourMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactButtonText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.contactId);
                });

            migrationBuilder.CreateTable(
                name: "portfolio",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio", x => x.PortfolioId);
                });

            migrationBuilder.CreateTable(
                name: "register",
                columns: table => new
                {
                    RegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_register", x => x.RegisterId);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "staticData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstHeading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondHeading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buttonText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Portfolio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    portfolioTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teamTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teamDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactButtonText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staticData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degisnation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.TeamId);
                });

            migrationBuilder.InsertData(
                table: "staticData",
                columns: new[] { "Id", "About", "Contact", "HomeLogo", "Portfolio", "SecondHeading", "Services", "Team", "YourEmail", "YourMessage", "YourName", "YourPhone", "aboutTitle", "buttonText", "contactButtonText", "contactTitle", "firstHeading", "portfolioTitle", "serviceTitle", "teamDescription", "teamTitle" },
                values: new object[] { 1010, "ABOUT", "CONTACT US", "/images/startBootstrap.png", "PORTFOLIO", "IT'S NICE TO MEET YOU", "SERVICES", "OUR AMAZING TEAM", "suraj@gmail.com", "Wow!", "Suraj Shah", "9808300810", "Lorem ipsum dolor sit amet consectetur.", "TELL ME MORE", "Send Messsage", "Lorem ipsum dolor sit amet consectetur.", "Welcome To Our Studio!", "Lorem ipsum dolor sit amet consectetur.", "Lorem ipsum dolor sit amet consectetur.", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aut eaque, laboriosam veritatis, quos non quis ad perspiciatis, totam corporis ea, alias ut unde.", "Lorem ipsum dolor sit amet consectetur." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abouts");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "portfolio");

            migrationBuilder.DropTable(
                name: "register");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "staticData");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
