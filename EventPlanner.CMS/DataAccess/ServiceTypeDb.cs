using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EventPlanner.CMS.DataAccess {
    public static class ServiceTypeDb {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable GetAllServiceTypes() {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllServiceTypes", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static void Create(string name) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("CreateServiceType", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Edit(int id, string name) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("EditServiceType", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetServiceById(int id) {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetServiceType", sqlConn) {
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
                using (var cmd = new SqlCommand("DeleteServiceType", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}