using System;
using PetPals.Entity;
namespace PetPals.BusinessLayer.Services;

public interface IAdoptionEventService
{
        void RegisterParticipant(Adopter participant);
        void HostEvent();
}
