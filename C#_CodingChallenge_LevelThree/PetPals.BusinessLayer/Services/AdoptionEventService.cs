using System;
using PetPals.Entity;
using PetPals.BusinessLayer.Repository;
namespace PetPals.BusinessLayer.Services;

public class AdoptionEventService : IAdoptionEventService
{
        private readonly IAdoptionEventRepository _adoptionEventRepository;

        public AdoptionEventService(IAdoptionEventRepository adoptionEventRepository)
        {
            _adoptionEventRepository = adoptionEventRepository;
        }

        public void RegisterParticipant(Adopter participant)
        {
            _adoptionEventRepository.RegisterParticipant(participant);
        }

        public void HostEvent()
        {
            _adoptionEventRepository.HostEvent();
        }
}
