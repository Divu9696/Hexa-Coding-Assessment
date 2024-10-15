using System;
using PetPals.Entity;
using Microsoft.Data.SqlClient;
using PetPals.BusinessLayer.Util;
namespace PetPals.BusinessLayer.Repository;

public class AdoptionEventRepository : IAdoptionEventRepository
{
        private AdoptionEvent _adoptionEvent;

        public AdoptionEventRepository()
        {
            _adoptionEvent = new AdoptionEvent();
        }

        // Register participants for the adoption event
        public void RegisterParticipant(Adopter adopter)
        {
            try
            {
                using (SqlConnection connection = DBUtil.GetConnection())
                {
                    string query = "INSERT INTO participants (Name) VALUES (@name)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", adopter.Name);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering participant: " + ex.Message);
            }
        }

        public List<Adopter> GetRegisteredParticipants()
        {
            List<Adopter> adopters = new List<Adopter>();

            try
            {
                using (SqlConnection connection = DBUtil.GetConnection())
                {
                    string query = "SELECT Name FROM participants";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        adopters.Add(new Adopter { Name = reader["Name"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving adopters: " + ex.Message);
            }

            return adopters;
        }

        public void HostEvent()
        {
            Console.WriteLine("Hosting Adoption Event...");
            if (_adoptionEvent.Participants.Count == 0)
            {
                Console.WriteLine("No participants registered for the event.");
                return;
            }

            foreach (var participant in _adoptionEvent.Participants)
            {
                participant.Adopt();
            }
        }
}
