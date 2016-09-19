using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQAssignment
{
    class Replier
    {
        private MessageQueue replyQueue;
        private MessageQueue requestQueue;


        public Replier()
        {
            GetRequestQueue();
        }

        public void GetRequestQueue()
        {
            if (MessageQueue.Exists(@".\Private$\ApplicationQueue"))
                requestQueue = new System.Messaging.MessageQueue(@".\Private$\ApplicationQueue");
            else requestQueue = MessageQueue.Create(@".\Private$\ApplicationQueue"); Console.WriteLine(" Queue Created ");
            
        }
        
        
      
        public void getRequests()
        {
            Message requestMessage;// = requestQueue.EndReceive(asyncResult.AsyncResult);

            string str = ""; string label = "";

            try
            {
                requestMessage = requestQueue.Receive(new TimeSpan(0, 3, 0));
                Console.WriteLine("Recieved request from {0} with id{1}", requestMessage.Label, requestMessage.Id);
                string contents = requestMessage.Body.ToString();
                MessageQueue replyQueue = requestMessage.ResponseQueue;
                Message replyMessage = new Message();
                replyMessage.Body = contents;
                replyMessage.CorrelationId = requestMessage.Id;
                replyQueue.Send(replyMessage);
                Console.WriteLine("Sent request to {0} with id {1} and corr id {2}", replyMessage.Label, replyMessage.Id, replyMessage.CorrelationId);


                //requestMessage.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                //str = requestMessage.Body.ToString();
                //label = requestMessage.Label;
            }

            catch
            {
                str = "Recieved nothing - No requests";
            }

            Console.WriteLine(" Received from " + label);
        }

    }
}
