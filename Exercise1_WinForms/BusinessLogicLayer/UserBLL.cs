using System;
using System.Data;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        private UserDAO userDAO;

        public UserBLL()
        {
            userDAO = new UserDAO();
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Username cannot be empty");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password cannot be empty");

            User user = userDAO.Authenticate(username, password);

            if (user == null)
                throw new Exception("Invalid username or password");

            return user;
        }

        public DataTable GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }

        public bool TestDatabaseConnection()
        {
            return DatabaseConnection.TestConnection();
        }
    }
}
