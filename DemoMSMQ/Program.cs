using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using System.Threading.Tasks;

namespace DemoMSMQ
{
    class Program
    {

        private MessageQueue mq;
        private string myText = "Not initialized";
        private void GetChannel()
        {
            if (MessageQueue.Exists(@".\Private$\StudentRequestQueue"))
                mq = new System.Messaging.MessageQueue(@".\Private$\StudentRequestQueue");
            else mq = MessageQueue.Create(@".\Private$\StudentRequestQueue"); Console.WriteLine(" Queue Created ");
        }
        private void Populate()
        {
            Message msg = new System.Messaging.Message(); myText = "Body text";
            msg.Body = myText;
            msg.Label = "Mummi";
            mq.Send(msg);
            Console.WriteLine(" Posted in MyQueue1");
        }
        private string GetResult()
        {
            Message msg;
            string str = ""; string label = ""; try
            {
                msg = mq.Receive(new TimeSpan(0, 0, 50));
                msg.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" }); str = msg.Body.ToString();
                label = msg.Label;
            }
            catch { str = " Error in GetResult()"; }
            Console.WriteLine(" Received from " + label); return str;
        }
        static void Main(string[] args)
        {

            Program d = new Program();
            d.GetChannel();
            d.Populate();
            //string result = d.GetResult(); Console.WriteLine(" send: {0} ", d.myText);
            //Console.WriteLine(" receive: {0} ", result); Console.ReadLine();


        }
    }
}
