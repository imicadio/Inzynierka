using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Survey
{
    public class Surveyy
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Biceps> Bicepss { get; set; }
        public ICollection<BodyFat> BodyFats { get; set; }
        public ICollection<BodyWeight> BodyWeights { get; set; }
        public ICollection<Calf> Calfs { get; set; }
        public ICollection<Chest> Chests { get; set; }
        public ICollection<Hip> Hips { get; set; }
        public ICollection<Thigh> Thighs { get; set; }

        // many-to-one User
        public int? TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public User TrainerSurvey { get; set; }

        // many-to-one User
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User UserSurvey { get; set; }
    }
}
