﻿namespace AppleShop.Ordering.API.Messages;

public class BaseMessage
{
    public int Id { get; set; }

    public DateTime MessageCreated { get; set; }
}