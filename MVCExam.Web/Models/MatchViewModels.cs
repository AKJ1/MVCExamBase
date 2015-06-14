using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExam.Web.Models
{
    public class MatchViewModel
    {
        public TeamsViewModel HomeTeam { get; set; }

        public double HomeTeamBetAmount { get; set; }

        public TeamsViewModel AwayTeam { get; set; }

        public double AwayTeamBetAmount { get; set; }

        public DateTime MatchDate { get; set; }

        public int MatchId { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

    }

    public class MatchesModel
    {
        public ICollection<MatchViewModel> Matches { get; set; }

        public int Page { get; set; }

        public int LastPage { get; set; }
    }
}