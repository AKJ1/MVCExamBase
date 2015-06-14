using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExam.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Match
    {
        public Match()
        {
            
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual Team HomeTeam { get; set; }

        [Required]
        public virtual Team AwayTeam { get;set; }

        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        public ICollection<Comment> Comments { get; set; }
        
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime Date { get; set; }
    }
}
