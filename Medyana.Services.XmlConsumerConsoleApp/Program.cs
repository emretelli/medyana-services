using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using Serilog.Core;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medyana.Services.XmlConsumerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(60000);
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "123456" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "polyclinics-xml-files",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var file = Encoding.UTF8.GetString(body);
                    Console.WriteLine(file);
                    var patientList = XmlParser.ParseXmlFileToPatientList(file);
                    var manager = new PatientManager();
                    manager.SendPatientListToApi(patientList).GetAwaiter();
                };
                channel.BasicConsume(queue: "polyclinics-xml-files",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();

            }
        }
    }
}
