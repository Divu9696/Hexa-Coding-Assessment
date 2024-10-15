using System;
using PetPals.Entity;

namespace PetPals.BusinessLayer.Services;

public interface IAdopterService
{
        void RegisterAdopter(Adopter adopter);
        List<Adopter> GetAllAdopters();
}
