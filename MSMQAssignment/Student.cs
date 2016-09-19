using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQAssignment
{
    public class Student
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public List<String> Degrees { get; set; }


        public Student(string name, int age, List<String> degrees)
        {
            this.Age = age;
            this.Name = name;
            degrees = new List<string>();
        }


        

    }
}
