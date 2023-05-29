using AppleShop.Payment.API.Messages;
using AppleShop.Payment.API.RabbitMQSender;
using Newtonsoft.Json;
using PaymentProcessor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AppleShop.Payment.API.Consumers;

public class RabbitMQConsumer : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;

    private readonly IMessageSender _messageSender;
    private readonly IProcessorPayment _processPayment;

    public RabbitMQConsumer(IMessageSender messageSender, IProcessorPayment processPayment)
    {
        _messageSender = messageSender;
        _processPayment = processPayment;

        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare("orderpaymentprocesstopic", false, false, false);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (s, e) =>
        {
            var content = Encoding.UTF8.GetString(e.Body.ToArray());
            var dto = JsonConvert.DeserializeObject<PaymentRequestMessage>(content);
            HandleMessage(dto).GetAwaiter().GetResult();

            _channel.BasicAck(e.DeliveryTag, false);
        };

        _channel.BasicConsume("orderpaymentprocesstopic", false, consumer);

        return Task.CompletedTask;
    }

    private async Task HandleMessage(PaymentRequestMessage dto)
    {
        var result = _processPayment.IsPaymentProcessed();

        var updatePaymentResultMessage = new UpdatePaymentResultMessage
        {
            Status = result,
            OrderId = dto.OrderId,
            Email = dto.Email
        };

        try
        {
            await _messageSender.SendMessage(updatePaymentResultMessage);
        }
        catch (Exception)
        {
            throw;
        }
    }
}