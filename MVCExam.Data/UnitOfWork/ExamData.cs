using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCExam.Data.Contracts;
using MVCExam.Data.Repositories;
using MVCExam.Models;

namespace MVCExam.Data.UnitOfWork
{
    public class ExamData: IExamData
    {
        public ExamDbContext context;
        private IDictionary<Type, object> repositories;

        public ExamData()
            : this(new ExamDbContext())
        {
        }

        public ExamData(ExamDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();

        }
        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Player> Players
        {
            get { return this.GetRepository<Player>(); }
        }

        public IRepository<Team> Teams
        {
            get { return this.GetRepository<Team>(); }
        }

        public IRepository<Match> Matches
        {
            get { return this.GetRepository<Match>(); }
        }

        public IRepository<Vote> Votes
        {
            get { return this.GetRepository<Vote>(); }
        }

        public IRepository<Bet> Bets
        {
            get { return this.GetRepository<Bet>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepo = typeof(GenericRepository<T>);
                
                var repo = Activator.CreateInstance(typeOfRepo, this.context);
                this.repositories.Add(type, repo);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
