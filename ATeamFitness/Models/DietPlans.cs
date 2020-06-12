using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATeamFitness.Models
{
    public class DietPlans
    {
        [Key]
        public int PlanId { get; set; }

        public string DietType { get; set; }

        public string FitnessGoal { get; set; }

        public string FoodOptionA { get; set; }

        public string FoodOptionB { get; set; }

        public string FoodOptionC { get; set; }
    }
}
