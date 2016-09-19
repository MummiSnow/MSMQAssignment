using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Replier replier1 = new Replier();

            Requestor student1 = new Requestor("Student1ResponseQueue", "Nidalee");
            student1.SendApplication("Hello i have something good to offer");
            Requestor student2 = new Requestor("Student2ResponseQueue", "Monk");
            student1.SendApplication("Hello Kin");


            replier1.getRequests();

            

            
            

            Console.ReadKey();

        }
    }
}
