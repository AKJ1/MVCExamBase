using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExam.Web.Controllers
{
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.AspNet.Identity;
    using Models;
    using MVCExam.Models;

    public class MatchController : BaseController
    {
        //
        // GET: /Matches/
        [Route("/Matches/{page?}")]
        public ActionResult Index(int page = 0)
        {
            int lastPage = (int) Math.Ceiling((double) (this.data.Matches.All().Count()/5)) ;
            if (RouteData.Values["id"] != null)
            {
                page =  int.Parse(RouteData.Values["id"].ToString());
            }
            else{
                page = 0;
            }
            if (page >= lastPage)
            {
                page = lastPage;
            }
            var Matches = this.data.Matches.All()
                   .OrderBy(m => m.Date)
                   .Skip(page * 5)
                   .Take(5)
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
                       
                   }).ToList();

            var model = new MatchesModel
            {
                Matches = Matches,
                Page = page,
                LastPage = lastPage
            };
            return View(model);
        }

        [Route("/Match/Detail/{Id}")]
        public ActionResult Detail(int? Id)
        {
            var m = this.data.Matches.GetById(Id);
            var MatchModel = new MatchViewModel()
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
                },
                Comments = data.Comments.Find(c => c.MatchId == m.Id).Select(c => new CommentViewModel()
                {
                    Content = c.Content,
                    Poster = c.Author.UserName,
                    PostedOn = c.PostedOn
                }).ToList(),
                HomeTeamBetAmount = data.Bets.Find(b => b.Match.Id == m.Id).Sum(b => b.HomeBet),
                AwayTeamBetAmount = data.Bets.Find(b => b.Match.Id == m.Id).Sum(b => b.AwayBet)
                
            };
            if (RouteData.Values["id"] == null)
            {
                return RedirectToAction("Index");
            }
            Id = int.Parse((string) RouteData.Values["id"]);
            return View(MatchModel);
        }

        [Authorize]
        [Route("/Match/{Id}/Comment")]
        public ActionResult Comment(int Id,CommentPostModel model)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = data.Users.GetById(currentUserId);
            if (!data.Matches.All().Any(m => m.Id == Id))
            {
                return new HttpNotFoundResult();
            }


            if (currentUser!= null)
            {
                var newComment = new Comment();
                newComment.AuthorId = currentUserId;
                newComment.MatchId = Id;

                data.Comments.Add(newComment);
                data.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Comment(CommentPostModel model)
        {
            if
            
        }
	}
}