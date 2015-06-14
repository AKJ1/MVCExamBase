using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExam.Web.Controllers
{
    using Data;
    using Data.UnitOfWork;
    using Microsoft.Ajax.Utilities;
    using Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var TopMatches = this.data.Matches.All()
                .OrderBy(m => m.Date)
                .Take(3)
                .Select(m => new MatchViewModel()
                {
                    MatchDate = m.Date,
                    MatchId = m.Id,

                    HomeTeam = new TeamsViewModel()
                    {
                        Name = m.HomeTeam.Name,
                        NickName = m.HomeTeam.Nickname,
                        TeamId = m.HomeTeamId
                    },
                    AwayTeam = new TeamsViewModel()
                    {
                        Name = m.AwayTeam.Name,
                        NickName = m.AwayTeam.Nickname,
                        TeamId = m.AwayTeamId
                    }
                    //Comments = data.Comments.Find(c => c.MatchId == m.Id).Select(c => new CommentViewModel()
                    //{
                    //    Content = c.Content,
                    //    Poster = c.Author.UserName,
                    //    PostedOn = c.PostedOn
                    //}).ToList()
                }).ToList();

            var TopTeams = this.data.Teams.All()
                .OrderByDescending(t => data.context.Votes.Count(v => v.TeamId == t.Id))
                .Take(3)
                .Select(m => new TeamsViewModel()
                {
                    Name = m.Name,
                    NickName = m.Nickname,
                    Votes = data.context.Votes.Count(v => v.TeamId == m.Id),
                    FoundedOn = m.DateFounded,
                    Website = m.Website,
                    TeamId = m.Id,
                    Players = m.Players.Select(p => new PlayerViewModel()
                    {
                        BornOn = p.BirthDate,
                        Height = p.Height,
                        Name = p.Name
                    }).ToList()
                }).ToList();


            HomeViewModel model = new HomeViewModel()
            {
                TopMatches = TopMatches,
                TopTeams = TopTeams
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}