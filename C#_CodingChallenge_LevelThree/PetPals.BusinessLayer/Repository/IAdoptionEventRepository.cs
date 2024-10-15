using System;
using PetPals.Entity;

namespace PetPals.BusinessLayer.Repository;

public interface IAdoptionEventRepository
{
        void RegisterParticipant(Adopter participant);
        void HostEvent();
}
