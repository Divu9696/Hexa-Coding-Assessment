using System;
using PetPals.Entity;
namespace PetPals.BusinessLayer.Services;

public interface IPetService
{
        void AddPet(Pet pet);
        void RemovePet(int petId);
        List<Pet> GetAvailablePets();
}
