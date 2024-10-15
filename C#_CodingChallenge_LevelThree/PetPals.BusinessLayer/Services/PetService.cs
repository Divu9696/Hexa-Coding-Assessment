using System;
using PetPals.Entity;
using PetPals.BusinessLayer.Repository;
using PetPals.BusinessLayer.Exceptions;

namespace PetPals.BusinessLayer.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void AddPet(Pet pet)
        {
            try
            {
                // Validate Pet Age
                if (pet.Age <= 0)
                {
                    throw new InvalidPetAgeException("Pet age must be a positive integer.");
                }

                _petRepository.AddPet(pet);
            }
            catch (InvalidPetAgeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
        }

        public void RemovePet(int petId)
        {
            _petRepository.RemovePet(petId);
        }

        public List<Pet> GetAvailablePets()
        {
            return _petRepository.GetAvailablePets();
            
        }
        
}
