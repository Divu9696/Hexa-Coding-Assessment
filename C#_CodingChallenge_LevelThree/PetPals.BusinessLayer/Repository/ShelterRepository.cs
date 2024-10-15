using System;
using PetPals.Entity;
namespace PetPals.BusinessLayer.Repository;

public class ShelterRepository : IShelterRepository
{
        private List<Shelter> shelters = new List<Shelter>();

        public void RegisterShelter(Shelter shelter)
        {
            shelters.Add(shelter);
        }

        public List<Shelter> GetAllShelters()
        {
            return shelters;
        }
}
