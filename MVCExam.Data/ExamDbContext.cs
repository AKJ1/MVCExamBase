namespace MVCExam.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCExam.Data.Contracts;
    using MVCExam.Data.Migrations;
    using MVCExam.Models;
    using MVCExam.Models;

    public class ExamDbContext : IdentityDbContext<User>, IExamDbContext
    {
        public ExamDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExamDbContext, ExamDbMigrationsConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Match>()
                .HasRequired(m => m.AwayTeam)
                .WithMany()
                .HasForeignKey(t => t.AwayTeamId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(t => t.HomeTeamId)
                .WillCascadeOnDelete(false);
        }

        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IRepository<Comment> Comments { get; set; }
    }
}
