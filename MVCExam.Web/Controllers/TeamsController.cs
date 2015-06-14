using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExam.Web.Controllers
{
    using System.Net;
    using System.Web.Routing;
    using Microsoft.AspNet.Identity;
    using Models;
    using MVCExam.Models;

    public class TeamsController : BaseController
    {
        //
        // GET: /Teams/
        public ActionResult Index()
        {
            return View();
        }

        [Route("/Detail/{Id}")]
        public ActionResult Detail(int? Id)
        {
            if (Id == null && RouteData.Values["Id"] !=null)
            {
                Id = int.Parse((string)RouteData.Values["Id"]);
            }
            if (Id == null || !data.Teams.All().Any(t => t.Id == Id))
            {
                Id = 1;
            }
            var wantedTeam = data.Teams.GetById(Id);
            bool hasVoted = false;
            var currentUser = User.Identity.GetUserId();
            if (currentUser != null)
            {
             hasVoted = data.Votes.All().Any(v => v.UserId == currentUser && v.TeamId == Id);   
            }
            var model = new TeamsViewModel()
            {
                Name = wantedTeam.Name,
                NickName = wantedTeam.Nickname,
                Votes = data.context.Votes.Count(v => v.TeamId == wantedTeam.Id),
                FoundedOn = wantedTeam.DateFounded,
                Website = wantedTeam.Website,
                TeamId = wantedTeam.Id,
                HasVoted = hasVoted,
                Players = wantedTeam.Players.Select(p => new PlayerViewModel()
                {
                    BornOn = p.BirthDate,
                    Height = p.Height,
                    Name = p.Name
                }).ToList()
            };
            return View(model);
        }

        [Route("/Vote/{Id}")]
        [Authorize]
        public ActionResult Vote(int Id)
        {
            if (!Request.IsAuthenticated)
            {
                return new HttpUnauthorizedResult();
            }
            if (Id == null && RouteData.Values["Id"] != null)
            {
                Id = int.Parse((string)RouteData.Values["Id"]);
            }
            var currentUser = User.Identity.GetUserId();
            bool hasVoted = true;
            if(currentUser != null)
            {
                hasVoted = data.Votes.All().Any(v => v.UserId == currentUser && v.TeamId == Id);
            }
            if (hasVoted)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vote = new Vote();
                vote.TeamId = Id;
                vote.UserId = User.Identity.GetUserId();
                data.Votes.Add(vote);
                data.SaveChanges();
                return new HttpStatusCodeResult(200);   
            }
        }
	}
}