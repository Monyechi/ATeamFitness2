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
        public string TimeBlockIdentifier { get; set; }
        public string TimeBlockKey { get; set; }
        public string TrainerName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }

        public TimeBlock()
        {
            TimeBlockId = GenerateRandomAlphanumericString();
        }
        public string GenerateRandomAlphanumericString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[50];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

    }

}
