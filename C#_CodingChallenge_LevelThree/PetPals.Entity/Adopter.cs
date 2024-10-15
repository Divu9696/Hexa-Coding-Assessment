using System;

namespace PetPals.Entity;

public class Adopter : IAdoptable
{
        public string Name { get; set; }

        // Implementing Adopt method as required by the IAdoptable interface
        public void Adopt()
        {
            Console.WriteLine($"{Name} is adopting a pet!");
        }
}
