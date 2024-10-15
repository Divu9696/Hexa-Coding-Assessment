using System;
using PetPals.Entity;
using Microsoft.Data.SqlClient;
using PetPals.BusinessLayer.Util;

namespace PetPals.BusinessLayer.Repository;

public class PetRepository : IPetRepository
{
    // private List<Pet> availablePets = new List<Pet>();

        public void AddPet(Pet pet)
        {
        using (SqlConnection connection = DBUtil.GetConnection())
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO Petss (Name, Age, Breed) VALUES (@Name, @Age, @Breed)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", pet.Name);
                cmd.Parameters.AddWithValue("@Age", pet.Age);
                cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Pet added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding pet: {ex.Message}");
            }
        }
        }

    public void RemovePet(int petId)
    {
        using (SqlConnection connection = DBUtil.GetConnection())
        {
            try
            {
                connection.Open();
                string query = "DELETE FROM Petss WHERE PetId = @PetId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PetId", petId);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Pet removed successfully.");
                }
                else
                {
                    Console.WriteLine("Pet not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing pet: {ex.Message}");
            }
        }
    }

    public List<Pet> GetAvailablePets()
        {
            List<Pet> pets = new List<Pet>();

            try
            {
                using (SqlConnection connection = DBUtil.GetConnection())
                {
                    string query = "SELECT Name, Age, Breed FROM Petss";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        pets.Add(new Pet
                        {
                            Name = reader["Name"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Breed = reader["Breed"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving pets: " + ex.Message);
            }

            return pets;
        }

}
