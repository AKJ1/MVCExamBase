namespace MVCExam.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using MVCExam.Models;
    using MVCExam.Web;
    class ExamDbMigrationsConfiguration : DbMigrationsConfiguration<ExamDbContext>
    {
        #region Constructor
        public ExamDbMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }
        #endregion

        #region Seed method
        protected override void Seed(ExamDbContext context)
        {
            base.Seed(context);
            if (!context.Roles.Any())
            {
                CreateUserRoles(context);
            }
            if (!context.Users.Any())
            {
                CreateUsers(context);
            }
            if (!context.Teams.Any())
            {
                CreateTeams(context);
            }
            if (!context.Matches.Any())
            {
                CreateMatches(context);
            }
            if (!context.Players.Any())
            {
                CreatePlayers(context);
            }
            if (!context.Bets.Any())
            {
                CreateBets(context);
            }
            if (!context.Votes.Any())
            {
                CreateVotes(context);
            }
            context.SaveChanges();
        }
        #endregion

        #region Seed-Related Methods
        public void CreateUsers(ExamDbContext context)
        {
            UserStore<User> userStore = new UserStore<User>(context);
            ApplicationUserManager userManager = new ApplicationUserManager(userStore);

                var users = new List<User>()
                {
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "alex@usa.net",
                        UserName = "alex@usa.net",
                        PasswordHash = "12qw!@QW"
                        
                    },
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "tanya@gmail.com",
                        UserName = "tanya@gmail.com",
                        PasswordHash = "P@ssW0RD!123"
                        
                    }
                };

                foreach (var user in users)
                {
                    context.Users.Add(user);
                    var result = userManager.Create(user,user.PasswordHash);
                    context.SaveChanges();
                    userManager.AddToRole(user.Id, "User");
                }
            
        }

        private void CreateUserRoles(ExamDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Roles.Any())
            {
                var adminRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Administrator"};
                var userRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User" };

                context.Roles.Add(adminRole);
                context.Roles.Add(userRole);

                context.SaveChanges();
            }
        }

        private void CreateTeams(ExamDbContext context)
        {
            var teams = new List<Team>
            {
                new Team()
                {
                    Name = "Manchester United F.C.",
                    Website = "http://www.manutd.com",
                    DateFounded = DateTime.Parse("1-Jun-1878"),
                    Nickname = "The Red Devils",
                    Players = new List<Player>()
                },
                new Team()
                {
                    Name = "Real Madrid",
                    Website = "http://www.realmadrid.com",
                    DateFounded = DateTime.Parse("6-Mar-1902"),
                    Nickname = "The Whites",
                    Players = new List<Player>()
                },
                new Team()
                {
                    Name = "FC Barcelona",
                    Website = "http://www.fcbarcelona.com",
                    DateFounded = DateTime.Parse("12-Nov-1899"),
                    Nickname = "Barca",
                    Players = new List<Player>()
                },
                new Team()
                {
                    Name = "Bayern Munich",
                    Website = "http://www.fcbayern.de",
                    DateFounded = DateTime.Parse("13-Feb-1900"),
                    Nickname = "The Bavarians",
                    Players = new List<Player>()
                },
                new Team()
                {
                    Name = "Manchester City",
                    Website = "http://www.mcfc.com",
                    DateFounded = DateTime.Parse("1-May-1880"),
                    Nickname = "The Citizens",
                    Players = new List<Player>()
                },
                new Team()
                {
                    Name = "Chelsea",
                    Website = "https://www.chelseafc.com",
                    DateFounded = DateTime.Parse("10-Mar-1905"),
                    Nickname = "The Pensioners",
                    Players = new List<Player>()
                },
                new Team()
                {
                    Name = "Arsenal",
                    Website = "http://www.arsenal.com",
                    DateFounded = DateTime.Parse("1-Sep-1886"),
                    Nickname = "The Gunners",
                    Players = new List<Player>()
                }

            };
            foreach (var team in teams)
            {
                context.Teams.Add(team);
                context.SaveChanges();
            }

        }

        private void CreateMatches(ExamDbContext context)
        {
            var Matches = new List<Match>
            {
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Real Madrid"),
                    AwayTeam = context.Teams.First(t => t.Name == "Manchester United F.C."),
                    Date = DateTime.Parse("2015-Jun-13")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Bayern Munich"),
                    AwayTeam = context.Teams.First(t => t.Name == "Manchester United F.C."),
                    Date = DateTime.Parse("2015-Jun-14")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "FC Barcelona"),
                    AwayTeam = context.Teams.First(t => t.Name == "Manchester City"),
                    Date = DateTime.Parse("2015-Jun-15")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Chelsea"),
                    AwayTeam = context.Teams.First(t => t.Name == "FC Barcelona"),
                    Date = DateTime.Parse("2015-Jun-16")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Real Madrid"),
                    AwayTeam = context.Teams.First(t => t.Name == "Manchester City"),
                    Date = DateTime.Parse("2015-Jun-17")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Manchester United F.C."),
                    AwayTeam = context.Teams.First(t => t.Name == "Chelsea"),
                    Date = DateTime.Parse("2015-Jun-18")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Arsenal"),
                    AwayTeam = context.Teams.First(t => t.Name == "Bayern Munich"),
                    Date = DateTime.Parse("2015-Jun-12")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Chelsea"),
                    AwayTeam = context.Teams.First(t => t.Name == "Real Madrid"),
                    Date = DateTime.Parse("2015-Jun-11")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Chelsea"),
                    AwayTeam = context.Teams.First(t => t.Name == "Manchester City"),
                    Date = DateTime.Parse("2015-Jun-10")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Chelsea"),
                    AwayTeam = context.Teams.First(t => t.Name == "Arsenal"),
                    Date = DateTime.Parse("2015-Jun-19")
                },
                new Match()
                {
                    HomeTeam = context.Teams.First(t => t.Name == "Arsenal"),
                    AwayTeam = context.Teams.First(t => t.Name == "FC Barcelona"),
                    Date = DateTime.Parse("2015-Jun-20")
                }
            };

            foreach (var match in Matches)
            {
                context.Matches.Add(match);
                context.SaveChanges();
            }
            context.SaveChanges();
        }

        private void CreatePlayers(ExamDbContext context)
        {
            var Players = new List<Player>
            {
                new Player()
                {
                    Name = "Alexis Sanchez",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65,
                    Team = context.Teams.First(t => t.Name == "FC Barcelona")
                },
                new Player()
                {
                    Name = "Arjen Robben",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65,
                    Team = context.Teams.First(t => t.Name == "Real Madrid")
                },
                new Player()
                {
                    Name = "Franck Ribery",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65,
                    Team = context.Teams.First(t => t.Name == "Manchester United F.C.")
                },
                new Player()
                {
                    Name = "Wayne Rooney",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65,
                    Team = context.Teams.First(t => t.Name == "Manchester United F.C.")
                },
                new Player()
                {
                    Name = "Lionel Messi",
                    BirthDate = DateTime.Parse("1982-01-13"),
                    Height = 1.65,
                    Team = null
                },
                new Player()
                {
                    Name = "Theo Walcott",
                    BirthDate = DateTime.Parse("1983-02-17"),
                    Height = 1.75,
                    Team = null
                },
                new Player()
                {
                    Name = "Cristiano Ronaldo",
                    BirthDate = DateTime.Parse("1984-03-16"),
                    Height = 1.85,
                    Team = null
                },
                new Player()
                {
                    Name = "Aaron Lennon",
                    BirthDate = DateTime.Parse("1985-04-15"),
                    Height = 1.95,
                    Team = null
                },
                new Player()
                {
                    Name = "Gareth Bale",
                    BirthDate = DateTime.Parse("1986-05-14"),
                    Height = 1.90,
                    Team = null
                },
                new Player()
                {
                    Name = "Antonio Valencia",
                    BirthDate = DateTime.Parse("1987-05-23"),
                    Height = 1.82,
                    Team = null
                },
                new Player()
                {
                    Name = "Robin van Persie",
                    BirthDate = DateTime.Parse("1988-06-13"),
                    Height = 1.84,
                    Team = null
                },
                new Player() {Name = "Ronaldinho", BirthDate = DateTime.Parse("1989-07-30"), Height = 1.87, Team = null},

            };

            foreach (var player in Players)
            {
                context.Players.Add(player);
            }
            context.SaveChanges();
        }

        private void CreateBets(ExamDbContext context)
        {
            var bets = new List<Bet>
            {
                new Bet()
                {
                    Match = context.Matches.First(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name== "Chelsea - FC Barcelona"),
                    HomeBet = 30.00,
                    AwayBet = 0.00,
                    User = context.Users.First(u => u.UserName == "alex@usa.net")
                },
                new Bet()
                {
                    Match = context.Matches.First(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name== "Chelsea - FC Barcelona"),
                    HomeBet = 0.00,
                    AwayBet = 50.00,
                    User = context.Users.First(u => u.UserName == "alex@usa.net")
                },
                new Bet()
                {
                    Match = context.Matches.First(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name== "Chelsea - FC Barcelona"),
                    HomeBet = 0.00,
                    AwayBet = 120.00,
                    User = context.Users.First(u => u.UserName == "alex@usa.net")
                },
                new Bet()
                {
                    Match = context.Matches.First(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name== "FC Barcelona - Manchester City"),
                    HomeBet = 120.00,
                    AwayBet = 0.00,
                    User = context.Users.First(u => u.UserName == "alex@usa.net")
                },
                new Bet()
                {
                    Match = context.Matches.First(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name== "Bayern Munich - Manchester United F.C."),
                    HomeBet = 500.00,
                    AwayBet = 0.00,
                    User = context.Users.First(u => u.UserName == "alex@usa.net")
                },
                new Bet()
                {
                    Match = context.Matches.First(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name== "Bayern Munich - Manchester United F.C."),
                    HomeBet = 50.00,
                    AwayBet = 0.00,
                    User = context.Users.First(u => u.UserName == "tanya@gmail.com")
                },
                new Bet()
                {
                    Match = context.Matches.First(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name== "Bayern Munich - Manchester United F.C."),
                    HomeBet = 0.00,
                    AwayBet = 20.00,
                    User = context.Users.First(u => u.UserName == "tanya@gmail.com")
                },
                new Bet()
                {
                    Match = context.Matches.First(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name== "Chelsea - FC Barcelona"),
                    HomeBet = 0.00,
                    AwayBet = 220.00,
                    User = context.Users.First(u => u.UserName == "tanya@gmail.com")
                }
            };
            foreach (var bet in bets)
            {
                context.Bets.Add(bet);
            }
            context.SaveChanges();
        }

        private void CreateVotes(ExamDbContext context)
        {
            var votes = new List<Vote>
            {
                new Vote()
                {
                    Team = context.Teams.First(t => t.Name == "Bayern Munich"),
                    User = context.Users.First(u => u.UserName == "tanya@gmail.com")
                },
                new Vote()
                {
                    Team = context.Teams.First(t => t.Name == "Real Madrid"),
                    User = context.Users.First(u => u.UserName == "tanya@gmail.com")
                },
                new Vote()
                {
                    Team = context.Teams.First(t => t.Name == "Bayern Munich"),
                    User = context.Users.First(u => u.UserName == "alex@usa.net")
                }
            };

            foreach (var vote in votes)
            {
                context.Votes.Add(vote);
            }
            context.SaveChanges();

        }
        #endregion
    }
}
