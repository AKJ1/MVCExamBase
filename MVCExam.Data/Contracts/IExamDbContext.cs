using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCExam.Models;

namespace MVCExam.Data.Contracts
{
    public interface IExamDbContext
    {
        IDbSet<User> Users { get; set; }
        int SaveChanges();
        
    }
}
