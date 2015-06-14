using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExam.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel
    {
        public string Poster { get; set; }

        public DateTime PostedOn { get; set; }

        public string Content { get; set; }
    }

    public class CommentPostModel
    {
        [Required]
        public string Content { get; set; }
    }
}