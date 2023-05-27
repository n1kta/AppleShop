using AppleShop.Basket.API.Messages;

namespace AppleShop.Basket.API.MessageSender;

public interface IMessageSender
{
    Task SendMessage(BaseMessage message, string queue);
}