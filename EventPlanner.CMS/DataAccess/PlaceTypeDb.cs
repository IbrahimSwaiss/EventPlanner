using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EventPlanner.CMS.DataAccess {
    public static class PlaceTypeDb {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable GetAllPlaceTypes() {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllPlaceTypes", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static void CreateTest(string name)
        {
            using (var sqlConnection = new SqlConnection(ConnStr))
            {
                using (var cmd = new SqlCommand("CreatePlaceType", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Create(string name) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("CreatePlaceType", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Edit(int id, string name) {
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var cmd = new SqlCommand("EditPlaceType", sqlConn)) {
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
                using (var cmd = new SqlCommand("DeletePlaceType", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetPlaceById(int id) {
            var dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnStr)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetPlaceType", sqlConn) {
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