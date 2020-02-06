using System.Collections.Generic;
using Totalizator.Models;
using Totalizator.Models.DbModel;

namespace Totalizator.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> ListUser(int pageNumber);
        void AddUser(User user);
        IEnumerable<User> GetUserById(int id);

        void DeleteUser(int id);
        User GetUserByName(string name);
        User Validate(string email, string password);
        bool CheckEmailAndUserName(string email, string username);
        int GetCountOfUsers();
        void MakeUserAdmin(User user);
        void MakeUserModerator(User user);
        bool ChangeEmail(string name, string newEmail);
        bool ChangeName(string name, string newName);
        bool ChangePassword(string name, string newPassword);
    }
}
