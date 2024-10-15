using System;
using PetPals.Entity;

namespace PetPals.BusinessLayer.Repository;

public interface IPetRepository
{
        void AddPet(Pet pet);
        void RemovePet(int petId);
        List<Pet> GetAvailablePets();
}
