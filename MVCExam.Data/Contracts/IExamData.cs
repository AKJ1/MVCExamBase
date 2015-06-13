using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCExam.Models;

namespace MVCExam.Data.Contracts
{
    interface IExamData
    {
        IRepository<User> Users { get; }
        int SaveChanges();

    }
}
