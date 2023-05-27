using AppleShop.Basket.API.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AppleShop.Basket.API.MessageSender;

public class RabbitMQMessageSender : IMessageSender
{
    private readonly string _hostname;
    private readonly string _username;
    private readonly string _password;

    private IConnection _connection;

    public RabbitMQMessageSender()
    {
        _hostname = "localhost";
        _username = "guest";
        _password = "guest";
    }

    public Task SendMessage(BaseMessage message, string queue)
    {
        if (ConnectionExists())
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue, false, false, false);

            var serializedObj = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(serializedObj);

            channel.BasicPublish(string.Empty, queue, basicProperties: null, body: body);
        }

        return Task.CompletedTask;
    }

    #region private methods

    private void CreateConnection()
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            _connection = factory.CreateConnection();
        }
        catch (Exception)
        {
            // Log error
        }
    }

    private bool ConnectionExists()
    {
        if (_connection != null)
        {
            return true;
        }

        CreateConnection();

        return _connection != null;
    }

    #endregion
}