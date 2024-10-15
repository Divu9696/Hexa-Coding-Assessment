using System;
using PetPals.Entity;
using Microsoft.Data.SqlClient;
using PetPals.BusinessLayer.Util;
namespace PetPals.BusinessLayer.Repository;

public class DonationRepository : IDonationRepository
{
    // private List<Donation> donations = new List<Donation>();
    public bool RecordDonation(CashDonation donation)
        {
            try
            {
                if (donation.Amount < 10)
                {
                    throw new ArgumentException("Donation amount must be at least $10.");
                }

                using (SqlConnection connection = DBUtil.GetConnection())
                {
                    string query = "INSERT INTO donations (DonorName, DonationAmount,DonationDate) VALUES (@donorName, @amount, @donationDate)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@donorName", donation.DonorName);
                        cmd.Parameters.AddWithValue("@amount", donation.Amount);
                        cmd.Parameters.AddWithValue("@donationDate", donation.DonationDate);
                        connection.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording donation: " + ex.Message);
            }
        }
}
