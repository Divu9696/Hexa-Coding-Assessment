using System;

namespace PetPals.Entity;

public class Shelter : IAdoptable
{
        public string ShelterName { get; set; }

        // Implementing Adopt method as required by the IAdoptable interface
        public void Adopt()
        {
            Console.WriteLine($"{ShelterName} is facilitating pet adoptions!");
        }
}
