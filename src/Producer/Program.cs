using RabbitMQ.Client;
using System.Text;

const string _fila = "demo-queue";
const string _routingKey = "demo-queue";
var factory = new ConnectionFactory() { HostName = "localhost", UserName="silvio", Password = "123456"};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: _fila,
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    string message = "{\"cliente\": \"Silvio Jose de Souza\"}";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "",
                         routingKey: _routingKey,
                         basicProperties: null,
                         body: body);
    Console.WriteLine(" [x] Sent {0}", message);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
    