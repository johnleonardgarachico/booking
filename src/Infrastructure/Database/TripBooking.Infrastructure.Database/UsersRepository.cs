using Microsoft.Data.SqlClient;
using System.Data;
using TripBooking.Domain.Database;

namespace TripBooking.Infrastructure.Database
{
    public class UsersRepository
    {
        // TODO: Set from Server AppSettings
        private const string _connectionString =
            "Server=localhost;Database=Booking;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        
        public async Task<Guid?> AddUserAsync(string firstName, string lastName, 
            DateOnly birthDate, string username, string password, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("[Booking].[AddUser]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                await conn.OpenAsync(cancellationToken);
                
                var result = await cmd.ExecuteScalarAsync(cancellationToken);

                return result as Guid?;
            }
        }

        public async Task<List<User>> GetUsersAsync(Guid userId, CancellationToken cancellationToken)
        {
            var users = new List<User>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("[Booking].[GetUser]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);

                await conn.OpenAsync(cancellationToken);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync(cancellationToken))
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        users.Add(new User
                        {
                            Id = reader.GetGuid(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            BirthDate = DateOnly.FromDateTime(reader.GetDateTime(3)),
                            Username = reader.GetString(4)
                        });
                    }
                }
            }

            return users;
        }

        public async Task<bool> UpdateUserAsync(Guid userId, string firstName, 
            string lastName, DateOnly birthDate, string username, string password, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("[Booking].[UpdateUser]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                await conn.OpenAsync(cancellationToken);

                var rowsAffected = await cmd.ExecuteNonQueryAsync(cancellationToken);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("[Booking].[DeleteUser]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);

                await conn.OpenAsync(cancellationToken);

                int rowsAffected = await cmd.ExecuteNonQueryAsync(cancellationToken);

                return rowsAffected > 0;
            }
        }
    }
}
