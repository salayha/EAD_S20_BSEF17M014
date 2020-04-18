using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAO
    {
       // private static String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        private static String connStr = @"server=localhost;port=3306;Uid=root;Pwd=8080;database=mydrive;Convert Zero Datetime=True";
        public static int validateUser(String login, String password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select * from userinfo where Username= '" + login + "' and Password='" + password + "'";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    var result = command.ExecuteScalar();
                    if (result!=null)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }

                }
            }
            catch (Exception)
            {
                return -2;
            }
        }
        public static int insertUser(String login, String password, String uname)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select count(*) from userinfo where Username='" + login + "' ";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    var result =command.ExecuteScalar();
                    if (result!=null)
                    {
                        return -1;
                    }
                    else
                    {
                        sqlQuery = String.Format("INSERT INTO userinfo (Name, Username, Password) Values ('{0}','{1}','{2}')", uname, login, password);
                        command = new MySqlCommand(sqlQuery, conn);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return -2;
            }
        }
        public static List<FolderDTO> getRoots(int parent)
        {
            try
            {
                List<FolderDTO> arr = new List<FolderDTO>();
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select * from folders where ParentID='" + parent + "' ";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    var reader = command.ExecuteReader();
                    FolderDTO dto;
                    while (reader.Read())
                    {
                        dto = new FolderDTO();
                        dto.Fname = reader.GetString(reader.GetOrdinal("FolderName"));
                        dto.FID = reader.GetInt32(reader.GetOrdinal("FolderId"));
                        dto.PID = reader.GetInt32(reader.GetOrdinal("ParentID"));
                        arr.Add(dto);
                    }
                    return arr;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static int makeNewFolder(string fname, int parent)
        {
            try
            {
                int fid=-1;
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select count(*) from folders where ParentID='" + parent + "' and FolderName='"+fname+"'";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    var res = (int)command.ExecuteScalar();
                    if (res == 0)
                    {
                        sqlQuery = String.Format("Insert into folders (FolderName, ParentID ) Values('{0}','{1}')", fname,parent);
                        command = new MySqlCommand(sqlQuery, conn);
                        res = command.ExecuteNonQuery();
                        sqlQuery = "Select FolderId from folders where ParentID='" + parent + "' and FolderName='" + fname + "'";
                        command = new MySqlCommand(sqlQuery, conn);
                        fid = (int)command.ExecuteScalar();
                    }
                    return fid;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
