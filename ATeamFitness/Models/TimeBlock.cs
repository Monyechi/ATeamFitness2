using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATeamFitness.Models
{
    public class TimeBlock
    {
        [Key]
        public string TimeBlockId { get; set; }
        public string TimeBlockKey { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        
    }
}
