using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExam.Web.Models
{
    public class TeamsViewModel
    {
        public string Name { get; set; }

        public string NickName { get; set; }

        public DateTime FoundedOn { get; set; }

        public string Website { get; set; }

        public ICollection<PlayerViewModel> Players { get; set; }

        public int TeamId { get; set; }

        public int Votes { get; set; }

        public bool HasVoted { get; set; }
    }
}