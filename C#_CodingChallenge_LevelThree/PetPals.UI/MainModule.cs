using System;
using System.Collections.Generic;
using PetPals.Entity;
using PetPals.BusinessLayer;
using PetPals.BusinessLayer.Repository;
using PetPals.BusinessLayer.Services;
using Microsoft.Data.SqlClient;
using PetPals.BusinessLayer.Util;
using PetPals.BusinessLayer.Exceptions;

namespace PetPals.UI;

public class MainModule
{
        static void Main(string[] args)
        {


            
            using (SqlConnection connection = DBUtil.GetConnection())
            {
            IPetRepository petRepository = new PetRepository();
    
            IDonationRepository donationRepository = new DonationRepository();
            
            IAdoptionEventRepository adoptionEventRepository = new AdoptionEventRepository();
            
            IAdopterRepository adopterRepository = new AdopterRepository();
            
            IShelterRepository shelterRepository = new ShelterRepository();
        
            PetShelter petShelter = new PetShelter();

            PetService petService=new PetService(petRepository);
            DonationService donationService=new DonationService(donationRepository);
            AdoptionEventService adoptionEventService= new AdoptionEventService(adoptionEventRepository);
            AdopterService adopterService=new AdopterService(adopterRepository);
            ShelterService shelterService=new ShelterService(shelterRepository);

            while (true)
            {
            try
            {
                PrintMenu();
                string choice = Console.ReadLine();
                HandleUserChoice(choice, petService,adoptionEventService,donationService);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input format is incorrect. Please enter valid data.");
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidPetAgeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (AdoptionException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        }
        }
           
            

            
        static void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║           Main Menu                  ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. Add Pet");
        Console.WriteLine("2. Remove Pet");
        Console.WriteLine("3. List Available Pets");
        Console.WriteLine("4. Make Cash Donation");
        Console.WriteLine("5. Host Adoption Event");
        Console.WriteLine("6. Exit");
        Console.ResetColor();
    }

static void HandleUserChoice(string choice, PetService petService,AdoptionEventService adoptionEventService,DonationService donationService)
    {
        switch (choice)
        {
            case "1": AddPet(petService); break;
            case "2": RemovePet(petService); break;
            case "3": GetAvailablePets(petService); break;
            case "4": MakeCashDonation(donationService); break;
            case "5": HostEvent(adoptionEventService); break;
            case "6": Environment.Exit(0); break;
            default: Console.WriteLine("Invalid choice. Please try again."); break;
        }
    }


    static void AddPet(PetService petService)
    {
        try
        {
            Console.WriteLine("Enter Pet Details:");
            Console.Write("Pet Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Breed: ");
            string breed = Console.ReadLine();

            Pet newPet = new Pet{
                Name = name,
                Age = age,
                Breed=breed
            }  ;// PetId will be generated in the database

            petService.AddPet(newPet);  // Add pet to shelter
            Console.WriteLine("Pet added successfully.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid age. Please enter a valid integer for age.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding pet: {ex.Message}");
        }
    }

    // Remove an existing pet from the shelter
    static void RemovePet(PetService petService)
    {
        try
        {
            Console.Write("Enter Pet ID to remove: ");
            int petId = int.Parse(Console.ReadLine());
            petService.RemovePet(petId);  // Remove pet by ID
            Console.WriteLine("Pet removed successfully.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter a valid Pet ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing pet: {ex.Message}");
        }
    }

    // List all available pets
    static void GetAvailablePets(PetService petService)
    {
        try
        {
            Console.WriteLine("Listing available pets:");
            var pets = petService.GetAvailablePets();
            foreach (var pet in pets)
            {
            Console.WriteLine(pet.ToString());  // ToString() will be called automatically
            }
            // Console.WriteLine(petService.GetAvailablePets());
            // Console.WriteLine("Pets"); // List pets in shelter
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error listing pets: {ex.Message}");
        }
    }

    // Make a cash donation
     static void MakeCashDonation(DonationService donationService)
    {
        try
        {
            Console.Write("Enter Donor Name: ");
            string donorName = Console.ReadLine();
            Console.Write("Enter Donation Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Donation Date (yyyy-mm-dd): ");
            DateTime donationDate = DateTime.Parse(Console.ReadLine());

            CashDonation donation = new CashDonation{
                DonorName=donorName,
                Amount=amount,
                DonationDate=donationDate
            };
            donationService.RecordDonation(donation);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter valid data.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing donation: {ex.Message}");
        }
    }

    // Make an item donation
    //  static void MakeItemDonation(DonationService donationService)
    // {
    //     try
    //     {
    //         Console.Write("Enter Donor Name: ");
    //         string donorName = Console.ReadLine();
    //         Console.Write("Enter Donation Amount: ");
    //         decimal amount = decimal.Parse(Console.ReadLine());
    //         Console.Write("Enter Item Type: ");
    //         string itemType = Console.ReadLine();

    //         ItemDonation donation = new ItemDonation{
    //             DonorName=donorName,
    //              Amount=amount, 
    //              ItemType=itemType};
    //         donationService.RecordDonation(donation);
    //     }
    //     catch (FormatException ex)
    //     {
    //         Console.WriteLine("Invalid input. Please enter valid data.");
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"Error processing item donation: {ex.Message}");
    //     }
    // }

    // Host an adoption event
    static void HostEvent(AdoptionEventService adoptionEventService)
    {
        try
        {
            Console.WriteLine("Hosting Adoption Event...");
            AdoptionEvent adoptionEvent = new AdoptionEvent();
            adoptionEventService.HostEvent();  // Host the event
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error hosting adoption event: {ex.Message}");
        }
    }
            


            public void DisplayPetListings()
            {
                using (SqlConnection connection = DBUtil.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Pets", connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"Pet Name: {reader["Name"]}, Age: {reader["Age"]}, Breed: {reader["Breed"]}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error retrieving pet listings: {ex.Message}");
                    }
                }

                
            }

    public void RecordDonation(CashDonation donation)
    {
        using (SqlConnection connection = DBUtil.GetConnection())
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Donations (DonorName, Amount, DonationDate) VALUES (@DonorName, @Amount, @DonationDate)", connection);
                cmd.Parameters.AddWithValue("@DonorName", donation.DonorName);
                cmd.Parameters.AddWithValue("@Amount", donation.Amount);
                cmd.Parameters.AddWithValue("@DonationDate", donation.DonationDate);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Donation recorded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error recording donation: {ex.Message}");
            }
        }
    }
            

}

