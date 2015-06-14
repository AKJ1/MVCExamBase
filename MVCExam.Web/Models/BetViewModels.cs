using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExam.Web.Models
{
    public class BetViewModels
    {
    }

    public class BetPostModel
    {
        public double HomeAmount { get; set; }

        public double AwayAmount { get; set; }
    }
}