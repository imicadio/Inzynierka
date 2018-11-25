﻿using Engineer.Models.Models.Trainings;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models
{
    public class User : IdentityUser<int>
    {
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        [InverseProperty("UserPlan")]
        public ICollection<TrainingDay> Users { get; set; }

        [InverseProperty("TrainerPlan")]
        public ICollection<TrainingDay> Trainers { get; set; }
    }
}
