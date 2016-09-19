using System;
using System.Collections.Generic;
using System.Messaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MSMQAssignment
{
    public class Requestor
    {
        private Message requestMsg;

        private MessageQueue requestQueue;
        private MessageQueue replyQueue;

        
        public string Name { get; set; }


        public Requestor(string requestQueName, string replyQueName, string name)
        {
            Name = name;
            requestQueue = new MessageQueue(requestQueName);
            replyQueue = new MessageQueue(replyQueName);

            replyQueue.MessageReadPropertyFilter.SetAll();
            ((XmlMessageFormatter)replyQueue.Formatter).TargetTypeNames = new string[] { "System.String,mscorlib" };

        }

        public void SendApplication(string applicationMsg)
        {
            requestMsg = new Message();
            requestMsg.Body = applicationMsg;
            requestMsg.Label = Name;
            Console.WriteLine("{0} sent an application to {1}",Name,requestQueue.Id);
            Console.WriteLine("MessageId: {0}",requestMsg.Id);
        }

        public void receive()
        {

            Message replyMsg = replyQueue.Receive();

            Console.WriteLine("{0} you've gotten an response from {1}", Name, replyQueue.Label);
            Console.WriteLine("CorrelationId {0}", replyMsg.CorrelationId);

        }



       
      
        

    }
}
