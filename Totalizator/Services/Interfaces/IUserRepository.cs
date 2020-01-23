﻿using System.Collections.Generic;
using Totalizator.Models;
using Totalizator.Models.DbModel;

namespace Totalizator.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> ListUser();
        void AddUser(User user);
        IEnumerable<User> GetUserById(int id);

        void DeleteUser(int id);
        User GetUserByName(string name);
        User Validate(string email, string password);
    }
}
