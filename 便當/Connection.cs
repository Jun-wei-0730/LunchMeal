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
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                ResultList.Add(reader.GetValue(i).ToString());
                            }
                        }
                        // conn.Close();
                        return ResultList;
                    }
                    else
                    {
                        // conn.Close();
                        return null;
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
                    Console.WriteLine(cmd);
                    cmd.ExecuteNonQuery();
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
        public void CleanTable(string ParentTable, string ChildTable, string ID)
        {
            string CleanupCommand = $"DELETE FROM {ParentTable} WHERE {ID} NOT IN (SELECT DISTINCT {ID} FROM {ChildTable});";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                Console.WriteLine("已連線");
                using (SqlCommand commandobj = new SqlCommand(CleanupCommand, conn))
                {
                    commandobj.ExecuteNonQuery();
                    Console.WriteLine("執行成功");
                }
                conn.Close();
                Console.WriteLine("關閉連線");
            }

        }

    }
}
