using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EventPlanner.CMS.ViewModels.EventVMs;

namespace EventPlanner.CMS.DataAccess {
    public class EventTypeDb {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable GetAllEventTypes() {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllEventTypes", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static void Create(string name) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("CreateEventType", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Edit(int id, string name) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("EditEventType", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("DeleteEventType", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetEventById(int id) {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetEventType", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };

                    da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}