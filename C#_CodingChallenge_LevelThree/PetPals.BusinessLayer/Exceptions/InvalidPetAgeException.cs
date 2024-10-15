using System;

namespace PetPals.BusinessLayer.Exceptions;

public class InvalidPetAgeException : Exception
{
    public InvalidPetAgeException(string message) : base(message) { }
}
