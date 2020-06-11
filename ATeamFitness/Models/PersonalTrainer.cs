using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATeamFitness.Models
{
    public class PersonalTrainer
    {
        [Key]
        public int PersonalTrainerId { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public string Specialization { get; set; }
        public string Schedule { get; set; }
        public string WorkoutCalendar { get; set; }
        public string Bio { get; set; }
        public string TrainerLocation { get; set; }
        public int Rating { get; set; }
        public List<TimeBlock> TimeBlocks { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public PersonalTrainer()
        {
            TimeBlocks = new List<TimeBlock>();
        }
    }
}
