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
    class ExamData: IExamData
    {
        private DbContext context;
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
                //if (type.IsAssignableFrom(typeof(ApplicationUser)))
                //{
                //    typeOfRepo = typeof(UsersRepository);
                //}

                var repo = Activator.CreateInstance(typeOfRepo, this.context);
                this.repositories.Add(type, repo);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
