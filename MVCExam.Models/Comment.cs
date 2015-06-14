using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExam.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Dynamic;

    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PostedOn { get; set; }

        [Required]
        public virtual User Author { get; set; }

        public virtual Match Match { get; set; }

        [ForeignKey("Match")]
        public int MatchId { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }
    }
}
