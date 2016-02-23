using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitJson.Model
{


    public class UserCollection
    {
        public string totalProperty { get; set; }
        public string jsoninfo { get; set; }
        public string remarks { get; set; }
        public User[] items { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string Boole { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string realname { get; set; }
        public string sex { get; set; }
        public string mobile { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public string tel { get; set; }
        public string remarks { get; set; }
        public string local { get; set; }
    }


}
