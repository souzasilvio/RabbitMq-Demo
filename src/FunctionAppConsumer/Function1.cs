using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionAppConsumer
{
    public class Function1
    {
        const string fila = "demo-queue";
        [FunctionName("Function1")]
        //[ExponentialBackoffRetry(3, "00:00:01", "00:15:00")]
        public void Run([RabbitMQTrigger(fila, ConnectionStringSetting = "BrokerRabbitMQ")]string myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"Mensagem recebida de fila {fila}: {myQueueItem}");             
            }
            catch (Exception ex)
            {
                log.LogError($"Erro: {ex.Message}");
            }
        }
    }
}
