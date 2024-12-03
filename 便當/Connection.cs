using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace 便當
{
    public class Connection
    {
        public List<string> CustomerIDConn(string ID)
        {
            List<string> ResultList = new List<string>();
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from Customers where CustomerID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows) return null;
                    else
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                ResultList.Add(reader.GetValue(i).ToString());
                            }
                        }
                        return ResultList;
                    }
                }
            }
        }
        public void ParameterByList(string command, Dictionary<string,string>ParaPairs)
        {
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    foreach (var pairs in ParaPairs)
                    {
                        cmd.Parameters.AddWithValue(pairs.Key, pairs.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ParameterCommandByOne(string command, string Para, string Value)
        {
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    cmd.Parameters.AddWithValue(Para, Value);
                    Console.WriteLine(command);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<string> ParameterSelectByOne(string command, string Para, string Value)
        {
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    cmd.Parameters.AddWithValue(Para,Value);
                    Console.WriteLine(command);
                    var reader =  cmd.ExecuteReader();
                    List<string> ReadList = new List<string>();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                            {Console.WriteLine(reader[i].ToString());
                            ReadList.Add(reader.GetString(i));
                        }
                    }
                    return ReadList;
                }
            }
        }
        public string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
        public DataTable conn(string command)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand commandobj = new SqlCommand(command, conn))
                {
                    using (SqlDataReader reader = commandobj.ExecuteReader())
                    { dataTable.Load(reader); }
                }
            }
            return dataTable;
        }
        public void connOrder(string command)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand commandobj = new SqlCommand(command, conn))
                {
                    commandobj.ExecuteNonQuery();  // 執行 SQL 命令 
                }
                conn.Close();
            }
        }
        public void BackupDB()
        {
            string BackupLocation = ConfigurationManager.ConnectionStrings["BackUpLocation"].ConnectionString;
            string BackupCommand = $"backup database @DB to Disk = '{BackupLocation}'";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand commandobj = new SqlCommand(BackupCommand, conn))
                {
                    commandobj.Parameters.AddWithValue("@DB", "MealDB");
                    commandobj.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
