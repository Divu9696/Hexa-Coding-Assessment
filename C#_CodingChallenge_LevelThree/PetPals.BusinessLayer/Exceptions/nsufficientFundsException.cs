using System;

namespace PetPals.BusinessLayer.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}
