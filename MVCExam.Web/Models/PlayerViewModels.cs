using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExam.Web.Models
{
    public class PlayerViewModel
    {
        public string Name { get; set; }

        public DateTime BornOn { get; set; }

        public double Height { get; set; }
    }
}