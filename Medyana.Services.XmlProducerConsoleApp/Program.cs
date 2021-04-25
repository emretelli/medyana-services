using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Services.XmlProducerConsoleApp
{
    class Program
    {
        public static void Main()
        {
            List<string> files = XmlReader.ReadXmlFiles();
            for(int i = 0; i < files.Count; i++)
            {
                SendFile(files[i]);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        public static void SendFile(string file)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "123456" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "polyclinics-xml-files",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(file);

                channel.BasicPublish(exchange: "",
                                     routingKey: "polyclinics-xml-files",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
