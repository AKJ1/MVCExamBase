using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCExam.Models;

namespace MVCExam.Data.Contracts
{
    public interface IExamData
    {
        IRepository<User> Users { get; }

        IRepository<Player> Players { get; }

        IRepository<Team> Teams { get; }

        IRepository<Match> Matches { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Bet> Bets { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();

    }
}
