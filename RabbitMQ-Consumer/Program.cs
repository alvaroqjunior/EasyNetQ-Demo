using EasyNetQ;
using RabbitMQ_Core;
using System;
using System.Threading.Tasks;

namespace RabbitMQ_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Subscribe<TestMessage>("test", HandleTextMessage);
                //Different subscriptionID receive a message too works as pub/sub
                //bus.PubSub.Subscribe<TestMessage>("test1", HandleTextMessage);
                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(TestMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Task.Delay(10000).GetAwaiter();
            Console.ResetColor();
        }
    }
}
