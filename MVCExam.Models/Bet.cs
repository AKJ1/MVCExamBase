using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExam.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double HomeBet { get; set; }

        [Required]
        public double AwayBet { get; set; }

        [Required]
        public Match Match { get; set; }

        [Required]
        public User User { get; set; }
    }
}
