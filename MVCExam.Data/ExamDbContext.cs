using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCExam.Data.Migrations;
using MVCExam.Models;
using MVCExam.Models;

namespace MVCExam.Data
{
    public class ExamDbContext : IdentityDbContext<User>
    {
        public ExamDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExamDbContext, ExamDbMigrationsConfiguration>());
        }


        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }
    }
}
