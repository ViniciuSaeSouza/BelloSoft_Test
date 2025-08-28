﻿namespace Infrastructure.Exceptions;

[Serializable]
public class ExternalApiException : Exception
{
    public ExternalApiException(string message) : base(message) { }
    public ExternalApiException(string message, Exception innerException)
        : base(message, innerException) { }

}
