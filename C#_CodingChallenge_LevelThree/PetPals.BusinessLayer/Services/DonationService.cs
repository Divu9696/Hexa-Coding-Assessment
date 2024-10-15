using System;
using PetPals.Entity;
using PetPals.BusinessLayer.Repository;
using PetPals.BusinessLayer.Exceptions;

namespace PetPals.BusinessLayer.Services;

public class DonationService : IDonationService
{
    private readonly IDonationRepository _donationRepository;
        public DonationService(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public void RecordDonation(CashDonation donation)
        {
            try
            {
                if (donation.Amount < 10)
                {
                    throw new InsufficientFundsException("The donation amount must be at least $10.");
                }

                _donationRepository.RecordDonation(donation);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            // _donationRepository.RecordDonation(donation);
        }
}
