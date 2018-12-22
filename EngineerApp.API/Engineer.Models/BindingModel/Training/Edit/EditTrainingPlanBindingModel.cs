using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.BindingModel.Training.Edit
{
    public class EditTrainingPlanBindingModel
    {
        public int Id { get; set; }
        //[Required]
        //[StringLength(40, ErrorMessage = "Nazwa treningu powinna zawierać od 3 do 40 znaków", MinimumLength = 3)]
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string TrainerName { get; set; }
        public string UserName { get; set; }

        //public List<EditTrainingDayBindingModel> EditTrainingDayBindingModels { get; set; }

        //public EditTrainingPlanBindingModel()
        //{
        //    EditTrainingDayBindingModels = new List<EditTrainingDayBindingModel>();
        //}
    }
}
