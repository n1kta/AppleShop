﻿namespace AppleShop.Product.API.Exceptions;

public class ApiException : Exception
{
    public ApiException() { }

    public ApiException(string message)
        : base(message) { }

    public ApiException(string message, params object[] args)
        : base(string.Format(message, args)) { }
}