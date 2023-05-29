using AppleShop.Ordering.API.Messages;

namespace AppleShop.Ordering.API.MessageSender;

public interface IMessageSender
{
    Task SendMessage(BaseMessage message, string queue);
}