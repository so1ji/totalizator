using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models;
using Totalizator.Models.DbModel;

namespace Totalizator.Services
{

    public class UserService : IUserRepository
    {
        totalizatorEntities db = new totalizatorEntities();
        public IEnumerable<User> ListUser()
        {
            return db.Users;
        }

        public User Validate(string email, string password)
          => ListUser().FirstOrDefault(x => x.Email == email && x.Password == password);

        public IEnumerable<User> GetUserById(int id)
        {
            IEnumerable<User> userIEnum = db.Users;

            var users = userIEnum.Where(p => p.Id == id).ToList();
            return users;
        }

        public User GetUserByName(string name)
        {
            var user = db.Users.Where(p => p.UserName == name).FirstOrDefault();
            return user;
        }


        public void UpdateUser(int id)
        {
            //TODO UPDATE 
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();

        }
    }
}