using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SplitJson.Model;

namespace SplitJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = string.Format("{0}", "heelo", "world");
            Console.Write(s);
        }
        static void Method01()
        {
            string a = File.ReadAllText(Environment.CurrentDirectory + "\\Userinfo.json");
            UserCollection ul = JsonConvert.DeserializeObject<UserCollection>(a);
            foreach (var u in ul.items)
            {
                string filename = u.id + ".json";
                var fs = File.Create(filename);
                StreamWriter sr = new StreamWriter(fs);
                sr.Write(JsonConvert.SerializeObject(u));
                sr.Close();
            }
        }
    }
}
