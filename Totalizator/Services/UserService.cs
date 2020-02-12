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
        ITotalizatorContext db;

        public UserService(ITotalizatorContext dbContext)
        {
            db = dbContext;
        }


        public IEnumerable<User> ListUser(int pageNumber)
        {
          //  db.Configuration.LazyLoadingEnabled = false;
            int pageSize = 7;
            return db.Users.Include("Roles").OrderBy(p => p.UserName).Skip((pageNumber - 1) * pageSize).Take(pageSize);


        }

        public User Validate(string email, string password)
          => db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

        public IEnumerable<User> GetUserById(int id)
        {
           // db.Configuration.LazyLoadingEnabled = false;
            IEnumerable<User> userIEnum = db.Users;
            var users = userIEnum.Where(p => p.Id == id).ToList();
            return users;
        }

        public User GetUserByName(string name)
        {
         //   db.Configuration.LazyLoadingEnabled = false;

            return db.Users.Include("Roles").Where(p => p.UserName == name).FirstOrDefault();
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

                //var RoleUser = db.Roles.Where(x => x.Name == "User").FirstOrDefault();
                //user.Roles.Add(RoleUser);
                //db.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            db.Users.Remove(db.Users.Where(p => p.Id == id).FirstOrDefault());
            db.SaveChanges();
        }

        public bool CheckEmailAndUserName(string email, string username)
        {
            if (db.Users.Where(p => p.Email == email).FirstOrDefault() != null) return false;
            if (db.Users.Where(p => p.UserName == username).FirstOrDefault() != null) return false;
            else return true;
        }

        public int GetCountOfUsers()
        {
            return db.Users.Count();
        }

        public void MakeUserAdmin(User user)
        {
            var dbUser = db.Users.Where(p => p.Id == user.Id).FirstOrDefault();

            dbUser.Email = user.Email;
            dbUser.UserName = user.UserName;
            dbUser.Password = user.Password;
            dbUser.Roles.Add(db.Roles.Where(p => p.Name == "Admin").FirstOrDefault());
            db.SaveChanges();
        }

        public void MakeUserModerator(User user)
        {
            var dbUser = db.Users.Where(p => p.Id == user.Id).FirstOrDefault();

            dbUser.Email = user.Email;
            dbUser.UserName = user.UserName;
            dbUser.Password = user.Password;
            dbUser.Roles.Add(db.Roles.Where(p => p.Name == "Moderator").FirstOrDefault());
            db.SaveChanges();
        }

        public bool ChangeEmail(string name, string newEmail)
        {
            if (db.Users.Where(p => p.Email == newEmail).FirstOrDefault() == null)
            {
                var user = GetUserByName(name);
                user.Email = newEmail;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ChangeName(string name, string newName)
        {
            if (db.Users.Where(p => p.UserName == newName).FirstOrDefault() == null)
            {
                var user = GetUserByName(name);
                user.UserName = newName;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ChangePassword(string name, string newPassword)
        {
            if (newPassword != null)
            {
                var user = GetUserByName(name);
                user.Password = newPassword;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}