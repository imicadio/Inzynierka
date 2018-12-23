using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.User
{
    public class UsersDto :BaseModelDto
    {
        public int Id { get; set; }
        public List<UserForDetailDto> Users { get; set; }
        public UsersDto()
        {
            Users = new List<UserForDetailDto>();
        }
    }
}
