using System;

namespace PetPals.BusinessLayer.Exceptions;

public class AdoptionException : Exception
{
    public AdoptionException(string message) : base(message) { }
}
