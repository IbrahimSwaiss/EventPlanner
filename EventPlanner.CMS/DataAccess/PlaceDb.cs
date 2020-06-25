using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EventPlanner.CMS.Models;

namespace EventPlanner.CMS.DataAccess
{
    public static class PlaceDb {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable GetAllPlaces() {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllPlaces", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static void Create(Place place) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("CreatePlace", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = place.Name;
                    cmd.Parameters.Add("@costPerHour", SqlDbType.Decimal).Value = place.CostPerHour;
                    cmd.Parameters.Add("@placeTypeId", SqlDbType.Int).Value = place.PlaceTypeId;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = place.Address;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Edit(Place place) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("EditPlace", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = place.Id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = place.Name;
                    cmd.Parameters.Add("@costPerHour", SqlDbType.Decimal).Value = place.CostPerHour;
                    cmd.Parameters.Add("@placeTypeId", SqlDbType.Int).Value = place.PlaceTypeId;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = place.Address;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetPlaceById(int id) {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetPlace", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };

                    da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static void Delete(int id) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("DeletePlace", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}