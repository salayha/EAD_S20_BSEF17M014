using Entities;
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
        private static String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        //private static String connStr = @"Data Source=.\SQLEXPRESS2019;Initial Catalog=Assignment3;User ID=sa;Password=pucit123";
        public static int validateUser(String login, String password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select count(*) from dbo.userinfo where Username= '" + login + "' and Password='" + password + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var result = (int)command.ExecuteScalar();
                    if (result == 1)
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
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select count(*) from dbo.userinfo where Username='" + login + "' ";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var result =(int) command.ExecuteScalar();
                    if (result == 1)
                    {
                        return -1;
                    }
                    else
                    {
                        sqlQuery = String.Format("INSERT INTO dbo.userinfo (Name, Username, Password) Values ('{0}','{1}','{2}')", uname, login, password);
                        command = new SqlCommand(sqlQuery, conn);
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
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select * from dbo.folders where ParentID='" + parent + "' ";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
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
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select count(*) from dbo.folders where ParentID='" + parent + "' and FolderName='"+fname+"'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var res = (int)command.ExecuteScalar();
                    if (res == 0)
                    {
                        sqlQuery = String.Format("Insert into dbo.folders (FolderName, ParentID ) Values('{0}','{1}')", fname,parent);
                        command = new SqlCommand(sqlQuery, conn);
                        res = command.ExecuteNonQuery();
                        sqlQuery = "Select FolderId from dbo.folders where ParentID='" + parent + "' and FolderName='" + fname + "'";
                        command = new SqlCommand(sqlQuery, conn);
                        fid = (int)command.ExecuteScalar();
                    }
            
                    return fid;
                }
            }
            catch (Exception)
            {
                return -2;
            }
        }
    }
}
