using System.Linq;
using BugsManager.Contexts;
using BugsManager.Models;

namespace BugsManager.Extensions
{

    public static class InitData
    {
        public static void Seed(this DatabaseContext dbContext)
        {
            if (!dbContext.Users.Any())
            {

                // Init with five Users
                dbContext.Users.Add(new User
                {
                    Name = "José",
                    Surname = "Pérez",
                    UserName = "pepe",
                    PassWord = "1234",
                });

                dbContext.Users.Add(new User
                {
                    Name = "Francisco",
                    Surname = "García",
                    UserName = "paco",
                    PassWord = "4321",
                });

                dbContext.Users.Add(new User
                {
                    Name = "Dolores",
                    Surname = "Martínez",
                    UserName = "lola",
                    PassWord = "4321",
                });

                dbContext.Users.Add(new User
                {
                    Name = "Sergio",
                    Surname = "Sánchez",
                    UserName = "checho",
                    PassWord = "4321",
                });

                dbContext.Users.Add(new User
                {
                    Name = "Beatriz",
                    Surname = "Fernández",
                    UserName = "bea",
                    PassWord = "4321",
                });

                // Init with five Projects

                dbContext.Project.Add(new Project
                {
                    Name = "Custom CRM",
                    Description = "Customize the Customer Relationship Management for the Hospitality Sector"
                });

                dbContext.Project.Add(new Project
                {
                    Name = "Stripe Billing",
                    Description = "Add Stripe online payment processing and commerce solution t accept payments."
                });

                dbContext.Project.Add(new Project
                {
                    Name = "Move to Cloud",
                    Description = "Upgrade all ñegacy systems to the AWS Cloud."
                });

                dbContext.Project.Add(new Project
                {
                    Name = "New portal",
                    Description = "Create a new interface portal using Single Page Application (SPA) React front-end JavaScript library."
                });

                dbContext.Project.Add(new Project
                {
                    Name = "Upgrade .Net",
                    Description = "Upgrade AWS .Net Lambdas to .Net core 6 runtime."
                });

                dbContext.SaveChanges();
            }
        }
    }
}
