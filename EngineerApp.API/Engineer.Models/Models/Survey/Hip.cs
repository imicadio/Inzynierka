using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Survey
{
    public class Hip
    {
        // Biodra - Hip
        [Key]
        public int Id { get; set; }
        public double Size { get; set; }
        public DateTime DateAdded { get; set; }
        public int TrainerId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public int SurveyId { get; set; }
        [ForeignKey(nameof(SurveyId))]
        public Surveyy Survey { get; set; }
    }
}
