using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EventPlanner.CMS.Models;

namespace EventPlanner.CMS.DataAccess
{
    public static class ServiceDb {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable GetAllServices() {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllServices", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static void Create(Service service) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("CreateService", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = service.Name;
                    cmd.Parameters.Add("@costPerHour", SqlDbType.Decimal).Value = service.CostPerHour;
                    cmd.Parameters.Add("@serviceTypeId", SqlDbType.Int).Value = service.ServiceTypeId;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Edit(Service service) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("EditService", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = service.Id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = service.Name;
                    cmd.Parameters.Add("@costPerHour", SqlDbType.Decimal).Value = service.CostPerHour;
                    cmd.Parameters.Add("@serviceTypeId", SqlDbType.Int).Value = service.ServiceTypeId;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetServiceById(int id) {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetService", sqlConn) {
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
                using (var cmd = new SqlCommand("DeleteService", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}