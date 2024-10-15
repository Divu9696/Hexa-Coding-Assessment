using System;
using PetPals.Entity;
using System.Collections.Generic;

namespace PetPals.BusinessLayer.Repository;

public interface IAdopterRepository
{
    void RegisterAdopter(Adopter adopter);
    List<Adopter> GetAllAdopters();
}
