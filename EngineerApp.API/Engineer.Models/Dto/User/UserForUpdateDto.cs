using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.User
{
    public class UserForUpdateDto
    {
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
