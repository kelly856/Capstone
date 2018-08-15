using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Objects;

namespace ClothingElaine.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
    }
}
