namespace MVCExam.Data.Contracts
{
    using System.Data.Entity;
    using MVCExam.Models;

    public interface IExamDbContext
    {
        IDbSet<User> Users { get; set; }
        int SaveChanges();

        IDbSet<Bet> Bets { get; set; }

        IDbSet<Match> Matches { get; set; }

        IDbSet<Team> Teams { get; set; }

        IDbSet<Player> Players { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IRepository<Comment> Comments { get; set; }
    }
}
