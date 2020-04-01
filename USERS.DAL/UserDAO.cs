using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace USERS.DAL
{
    public static class UserDAO
    {
        private static String connStr = @"Data Source=.\SQLEXPRESS2019;Initial Catalog=Assignment4;User ID=sa;Password=pucit123";
        public static Boolean validateEmail(String eml)
        {

            String email1 = eml;
            String pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(eml, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static Boolean validateUser(String Login, String Pass)

        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select count(*) from dbo.Users where Login='" + Login + "' and Password='" + Pass + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var result = (int)command.ExecuteScalar();
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Boolean checkUserEmail(String email)

        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select count(*) from dbo.Users where Email='" + email + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var result = (int)command.ExecuteScalar();
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static int updateUser(UserDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select * from dbo.Users where Login='" + dto.login + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        sqlQuery = String.Format("Update dbo.Users Set Name='{0}', Login='{1}', Password='{2}',Gender='{3}',Address='{4}',Age='{5}',NIC='{6}',DOB='{7}',IsCricket='{8}',Hockey='{9}',Chess='{10}',ImageName='{11}',CreatedOn='{12}',Email='{13}' where Login='" + dto.login + "'", dto.name, dto.login, dto.password, dto.gender, dto.address, dto.age, dto.NIC, dto.DOB, dto.cricket, dto.hockey, dto.chess, dto.image, dto.created, dto.email);
                        command = new SqlCommand(sqlQuery, conn);
                        return command.ExecuteNonQuery();
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

        public static int insertUser(UserDTO dto)

        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select * from dbo.Users where Login='" + dto.login + "' or Email='"+dto.email+"' ";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return -1;
                    }
                    else
                    {
                        sqlQuery = String.Format("INSERT INTO dbo.Users (Name, Login, Password,Gender,Address,Age,NIC,DOB,IsCricket,Hockey,Chess,ImageName,CreatedOn,Email) Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", dto.name, dto.login, dto.password, dto.gender, dto.address, dto.age, dto.NIC, dto.DOB, dto.cricket, dto.hockey, dto.chess, dto.image, dto.created, dto.email);
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
        public static int updatePassword(String login, String password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = String.Format("Update dbo.Users Set Password='"+password+"' where Login='" + login + "'");
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    return command.ExecuteNonQuery();
                }

            }
            catch(Exception)
            {
                return -1;
            }
        }
        public static UserDTO loadUser(String login)
        {
            try
            {
                UserDTO dto = new UserDTO();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    String sqlQuery = "Select * from dbo.Users where Login='" + login + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        dto.name = reader.GetString(1);
                        dto.login = reader.GetString(2);
                        dto.password = reader.GetString(3);
                        dto.gender = Convert.ToChar(reader.GetString(4));
                        dto.address = reader.GetString(5);
                        dto.age = reader.GetInt32(6);
                        dto.NIC = reader.GetString(7);
                        dto.DOB = reader.GetDateTime(8);
                        dto.cricket = reader.GetBoolean(9);
                        dto.hockey = reader.GetBoolean(10);
                        dto.chess = reader.GetBoolean(11);
                        dto.image = reader.GetString(12);
                        dto.created = reader.GetDateTime(13);
                        dto.email = reader.GetString(14);

                        return dto;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static String getUserImage(String login)

        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    String image;
                    conn.Open();
                    String sqlQuery = "Select ImageName from dbo.Users where Login='" + login + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        image = reader.GetString(0);
                        return image;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static String getUserLogin(String email)

        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    String login;
                    conn.Open();
                    String sqlQuery = "Select Login from dbo.Users where Email='" + email + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        login = reader.GetString(0);
                        return login;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Boolean sendEmail(String toEmailAddress, String subject, String body)
        {
            try
            {
                String fromDisplayEmail = "EAD.SEMorning@gmail.com";
                String fromPassword = "SEMorning2017";
                String fromDisplayName = "GUI Admin";
                MailAddress fromAddress = new MailAddress(fromDisplayEmail, fromDisplayName);
                MailAddress toAddress = new MailAddress(toEmailAddress);
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body=body
                
                })
                {
                    smtp.Send(message);
                }
                return true;

            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
