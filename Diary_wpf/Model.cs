using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary_wpf
{
    public class Model
    {
        public string Name;
        public string Description;
        public DateTime Date;
        public static List<Model> collection = new List<Model> { };
        public Model(string Name, string Description, DateTime Date)
        {
            this.Name = Name;
            this.Description = Description;
            this.Date = Date;
        }
        public Model()
        {
            this.Name = Name;
            this.Description = Description;
            this.Date = Date;
        }
    }
}
