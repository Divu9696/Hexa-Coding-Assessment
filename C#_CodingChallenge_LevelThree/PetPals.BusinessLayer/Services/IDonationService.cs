using System;
using PetPals.Entity;
namespace PetPals.BusinessLayer.Services;

public interface IDonationService
{
    void RecordDonation(CashDonation donation);
}
