using System;
using PetPals.Entity;

namespace PetPals.BusinessLayer.Repository;

public interface IShelterRepository
{
        void RegisterShelter(Shelter shelter);
        List<Shelter> GetAllShelters();
}
