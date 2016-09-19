using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQAssignment
{
    public class Requestor
    {

        public string Name { get; set; }

        public List<String> Degrees { get; set; }


        public Requestor(string name, List<String> degrees)
        {
            this.Name = name;
            degrees = new List<string>();
        }


        

    }
}
