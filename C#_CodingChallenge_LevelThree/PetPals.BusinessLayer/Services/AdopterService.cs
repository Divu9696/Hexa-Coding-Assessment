using System;
using PetPals.Entity;
using PetPals.BusinessLayer.Repository;
namespace PetPals.BusinessLayer.Services;

public class AdopterService : IAdopterService
{
        private readonly IAdopterRepository _adopterRepository;

        public AdopterService(IAdopterRepository adopterRepository)
        {
            _adopterRepository = adopterRepository;
        }

        public void RegisterAdopter(Adopter adopter)
        {
            _adopterRepository.RegisterAdopter(adopter);
        }

        public List<Adopter> GetAllAdopters()
        {
            return _adopterRepository.GetAllAdopters();
        }
}
