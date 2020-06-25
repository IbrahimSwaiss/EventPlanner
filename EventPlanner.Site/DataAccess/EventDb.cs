using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EventPlanner.Site.DataAccess {
    public class EventDb {
        private static readonly string ConnString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static void Create(DateTime start, DateTime end, int eventTypeId, int placeId, Guid userId,
            string imageUrl, List<int> servicesIds, string comment) {

            var servicesDt = new DataTable();
            servicesDt.Columns.Add("ServiceId");
            foreach (var id in servicesIds) {
                servicesDt.Rows.Add(id);
            }

            using (var sqlConn = new SqlConnection(ConnString)) {
                using (var cmd = new SqlCommand("CreateEvent", sqlConn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = start;
                    cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = end;
                    cmd.Parameters.Add("@eventTypeId", SqlDbType.Int).Value = eventTypeId;
                    cmd.Parameters.Add("@placeId", SqlDbType.Int).Value = placeId;
                    cmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;
                    cmd.Parameters.Add("@imageUrl", SqlDbType.NVarChar).Value
                        = string.IsNullOrEmpty(imageUrl) ? DBNull.Value : (object)imageUrl;
                    cmd.Parameters.Add("@services", SqlDbType.Structured).Value = servicesDt;
                    cmd.Parameters.Add("@comment", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(comment) ? DBNull.Value : (object)comment;

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetAllEvents() {
            DataTable dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnString)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllEvents", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };

                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable GetAllPlaces() {
            DataTable dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnString)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllPlaces", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };

                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static DataTable GetAllEventTypes() {
            DataTable dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnString)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllEventTypes", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };

                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable GetAllServices() {
            DataTable dt = new DataTable();
            using (var sqlConn = new SqlConnection(ConnString)) {
                using (var da = new SqlDataAdapter()) {
                    da.SelectCommand = new SqlCommand("GetAllServices", sqlConn) {
                        CommandType = CommandType.StoredProcedure
                    };

                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}