using System;
using PetPals.Entity;
using PetPals.BusinessLayer.Repository;

namespace PetPals.BusinessLayer.Repository;

public class AdopterRepository : IAdopterRepository
{
        private List<Adopter> adopters = new List<Adopter>();

        public void RegisterAdopter(Adopter adopter)
        {
            adopters.Add(adopter);
        }

        public List<Adopter> GetAllAdopters()
        {
            return adopters;
        }
}
