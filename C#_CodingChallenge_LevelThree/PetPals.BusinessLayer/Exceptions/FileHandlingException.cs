using System;

namespace PetPals.BusinessLayer.Exceptions;

public class FileHandlingException : Exception
{
    public FileHandlingException(string message) : base(message) { }
}
