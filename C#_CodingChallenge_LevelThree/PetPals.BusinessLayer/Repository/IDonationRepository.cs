using System;
using PetPals.Entity;

namespace PetPals.BusinessLayer.Repository;

public interface IDonationRepository
{
    bool RecordDonation(CashDonation donation);
}
