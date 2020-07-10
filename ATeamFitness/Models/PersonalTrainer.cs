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
        public string TimeBlockId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public string WorkoutLocation { get; set; }
        public int Rating { get; set; }
        public int ThumbsUp { get; set; }
        public int ThumbsDown { get; set; }
        public string PictureUrl { get; set; }
        public string DefaultPictureUrl { get; set; }
        public string ProfilePictureUrl { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public PersonalTrainer()
        {
            DefaultPictureUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
        }
        


    }
}
