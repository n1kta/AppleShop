using AppleShop.Payment.API.Messages;

namespace AppleShop.Payment.API.RabbitMQSender;

public interface IMessageSender
{
    Task SendMessage(BaseMessage baseMessage);
}