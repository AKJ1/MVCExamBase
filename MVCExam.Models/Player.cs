using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExam.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Height { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }


        public virtual Team Team { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        public bool Unemployed { get { return this.Team == null; } }

    }
}
