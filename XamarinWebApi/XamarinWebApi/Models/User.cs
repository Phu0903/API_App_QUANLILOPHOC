using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebApi.Models
{
    public class User
    {

       
        public int ID { get; set; }
        public string Name_user { get; set; }
        public string BirthDay_user { get; set; }
        public string NumberPhone_user { get; set; }
        public string Password { get; set; }
        public string userName { get; set; }
    }
}