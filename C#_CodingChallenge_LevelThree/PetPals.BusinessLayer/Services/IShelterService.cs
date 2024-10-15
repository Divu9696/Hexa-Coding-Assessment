using System;
using PetPals.Entity;
namespace PetPals.BusinessLayer.Services;

public interface IShelterService
{
        void RegisterShelter(Shelter shelter);
        List<Shelter> GetAllShelters();
}
