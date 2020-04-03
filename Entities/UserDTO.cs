using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserDTO
    {
        public int id { get; set; }
        public String login { get; set; }
        public String password { get; set; }
        public String name { get; set; } 
        public String email { get; set; }
        public  Char gender { get; set; }
        public String address { get; set; }
        public int age { get; set; }
        public String NIC { get; set; }
        public DateTime DOB { get; set; }
        public Boolean cricket { get; set; }
        public Boolean hockey { get; set; }
        public Boolean chess { get; set; }
        public String image { get; set; }
        public DateTime created { get; set; }
    }
}
