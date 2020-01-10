using System.Collections.Generic;
using Totalizator.Models;

namespace Totalizator.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> ListUser();
        void AddUser(User user);
        IEnumerable<User> GetUserById(int id);

        void DeleteUser(int id);

    }
}
