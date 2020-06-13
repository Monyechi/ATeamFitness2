using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATeamFitness.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string TimeBlockId { get; set; }
        public string Name { get; set; }
        public string FitnessGoal { get; set; }
        public string FitnessPlan { get; set; }
        public string DietPlan { get; set; }
        public int RewardPoint { get; set; }
        public string PictureUrl { get; set; }
        public string DefaultPictureUrl { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public Customer()
        {
            DefaultPictureUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
        }



    }
}
