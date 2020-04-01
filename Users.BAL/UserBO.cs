using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USERS.DAL;

namespace Users.BAL
{
    public static class UserBO
    {
        public static Boolean validateEmail(String email)
        {
            return UserDAO.validateEmail(email);
        }
        public static Boolean validateUser(String Login, String Pass)
        {
            return UserDAO.validateUser(Login, Pass);
        }
        public static int insertUser(UserDTO dto)
        {
            return UserDAO.insertUser(dto);
        }
        public static int updateUser(UserDTO dto)
        {
            return UserDAO.updateUser(dto);
        }
        public static UserDTO loadUser(String login)

        {
            return UserDAO.loadUser(login);
        }
        public static String getUserImage(String login)
        {
            return UserDAO.getUserImage(login);
        }
        public static String getUserLogin(String email)
        {
            return UserDAO.getUserLogin(email);
        }
        public static Boolean sendEmail(String toEmailAddress, String subject, String body)
        {
            return UserDAO.sendEmail(toEmailAddress, subject,  body);
        }
        public static Boolean checkUserEmail(String email)
        {
            return UserDAO.checkUserEmail(email);
        }
        public static int updatePassword(String login, String password)
        {
            return UserDAO.updatePassword(login, password);
        }

    }
}
