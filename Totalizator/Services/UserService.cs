using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models;

namespace Totalizator.Services
{

    public class UserService : IUserRepository
    {
        sweeptakesDBEntities db = new sweeptakesDBEntities();
        public IEnumerable<User> ListUser()
        {

            return db.Users;
        }

        public User Validate(string email, string password) //TODO ADD IN INTERFACE
          => ListUser().FirstOrDefault(x => x.Email == email && x.Password == password);

        public IEnumerable<User> GetUserById(int id)
        {
            IEnumerable<User> userIEnum = db.Users;

            var users = userIEnum.Where(p => p.Id == id).ToList();
            return users;
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
            //TODO check nulls
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();

        }
    }
}