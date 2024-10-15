using System;
using PetPals.Entity;
using PetPals.BusinessLayer.Repository;

namespace PetPals.BusinessLayer.Services;

public class ShelterService : IShelterService
{
        private readonly IShelterRepository _shelterRepository;

        public ShelterService(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public void RegisterShelter(Shelter shelter)
        {
            _shelterRepository.RegisterShelter(shelter);
        }

        public List<Shelter> GetAllShelters()
        {
            return _shelterRepository.GetAllShelters();
        }
}
