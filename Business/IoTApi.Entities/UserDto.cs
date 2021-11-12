using System;
using System.Collections.Generic;
using System.Text;

namespace IoTApi.Entities
{
    public class UserDto
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public int Is_Active { get; set; }

    }

    public class EntitiesResult
    {
        public string status { get; set; }
        public string message { get; set; }
        public UserLoginDto data { get; set; }

    }


    public class UserLoginDto
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public int isActive { get; set; }
        public int Login { get; set; }
    }

}
