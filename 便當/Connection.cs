using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace 便當
{
    public class ConnectionWithParameter
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
        public void ParameterByList(string command, List<string> ParaList, List<string> ValueList)
        {
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    for (int j = 0; j < ParaList.Count; j++)
                    {
                        cmd.Parameters.AddWithValue(ParaList[j], ValueList[j]);
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
    }
    public class SQLconn
    {
        readonly DataTable dataTable = new DataTable();
        public string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
        public DataTable conn(string command)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string selectstr = command;
            SqlCommand commandobj = new SqlCommand(selectstr, conn);
            SqlDataReader reader = commandobj.ExecuteReader();
            dataTable.Load(reader);
            conn.Close();
            return dataTable;
        }
        public void connOrder(string command)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                Console.WriteLine("已連線");
                using (SqlCommand commandobj = new SqlCommand(command, conn))
                {
                    commandobj.ExecuteNonQuery();  // 執行 SQL 命令 
                    Console.WriteLine("執行成功");
                }
                conn.Close();
                Console.WriteLine("關閉連線");
            }
        }
        public void BackupDB()
        {
            string BackupLocation = ConfigurationManager.ConnectionStrings["BackUpLocation"].ConnectionString;
            string BackupCommand = $"backup database @DB to Disk = '{BackupLocation}'";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                Console.WriteLine("已連線");
                using (SqlCommand commandobj = new SqlCommand(BackupCommand, conn))
                {
                    commandobj.Parameters.AddWithValue("@DB", "MealDB");
                    commandobj.ExecuteNonQuery();
                    Console.WriteLine("執行成功");
                }
                conn.Close();
                Console.WriteLine("關閉連線");
            }
        }
    }
}
