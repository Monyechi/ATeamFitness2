using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATeamFitness.Models
{
    public class TimeBlock
    {
        [Key]
        public int TimeBlockId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
    }
}
