namespace MVCExam.Web.Models
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public ICollection<MatchViewModel> TopMatches { get; set; }

        public ICollection<TeamsViewModel> TopTeams { get; set; }
    }
}