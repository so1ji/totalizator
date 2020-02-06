using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Services;
using Ninject;
using Totalizator.Models;
using Newtonsoft.Json;
using Totalizator.Util;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using Totalizator.Models.DbModel;
using System.Web;
using AutoMapper;
using Totalizator.Models.DomenModel;

namespace Totalizator.Controllers
{

    public class UserController : ApiController
    {
        IUserRepository repository;

        public UserController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        [HttpGet]
        public string GetUserList(int pageNumber)
        {
            var userList = repository.ListUser(pageNumber);
            List<UserDomenModel> userListDomen = new List<UserDomenModel>();
            foreach (User e in userList)
            {
                UserDomenModel userItemDomen = Mapper.Map<UserDomenModel>(e);
                userListDomen.Add(userItemDomen);
            }
            return JsonConvert.SerializeObject(userListDomen);
        }

        [HttpGet]
        public string GetCountOfUsers()
        {
            var countOfUsers = repository.GetCountOfUsers();
            return JsonConvert.SerializeObject(countOfUsers);
        }

        [HttpGet]
        public string GetCurrentUser()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var name = ClaimsPrincipal.Current.Identity.Name;

            var user = repository.GetUserByName(name);
            var userDomen = Mapper.Map<UserDomenModel>(user);
            var json = JsonConvert.SerializeObject(userDomen);
            return json;
        }

        [HttpGet]
        public string GetCurrentUserId()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var name = ClaimsPrincipal.Current.Identity.Name;

            var user = repository.GetUserByName(name);
            var userDomen = Mapper.Map<UserDomenModel>(user);
            var json = JsonConvert.SerializeObject(userDomen.Id);

            return json;
        }

        [HttpPost]
        public HttpResponseMessage MakeUserAdmin(UserDomenModel userDomen)
        {
            if (userDomen != null)
            {
                var user = Mapper.Map<User>(userDomen);
                repository.MakeUserAdmin(user);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage MakeUserModerator(UserDomenModel userDomen)
        {
            if (userDomen != null)
            {
                var user = Mapper.Map<User>(userDomen);
                repository.MakeUserModerator(user);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage Register(UserDomenModel userDomenData)
        {
            if (repository.CheckEmailAndUserName(userDomenData.Email, userDomenData.UserName))
            {
                if (userDomenData != null)
                {
                    //if (userData.UserName.Length > 3 && userData.UserName.Length < 15)
                    //{
                    //    if (userData.Password.Length > 6 && userData.Password.Length < 10)
                    //    {
                    //        if (userData.Email.Length > 5 && userData.Email.Length < 40)
                    //        {
                    var userData = Mapper.Map<User>(userDomenData);
                    repository.AddUser(userData);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                    //            }
                    //        }
                    //    }
                }
            }
            return new HttpResponseMessage(HttpStatusCode.Conflict);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteUser(UserDomenModel userDomen)
        {
            if (userDomen != null)
            {
                var user = Mapper.Map<User>(userDomen);
                repository.DeleteUser(user.Id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public HttpResponseMessage ChangeEmail(string newEmail)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var name = ClaimsPrincipal.Current.Identity.Name;
            if (repository.ChangeEmail(name, newEmail))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Conflict);
        }

        [HttpGet]
        public HttpResponseMessage ChangeName(string newName)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var name = ClaimsPrincipal.Current.Identity.Name;
            if (repository.ChangeName(name, newName))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Conflict);
        }

        [HttpGet]
        public HttpResponseMessage ChangePassword(string newPassword)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var name = ClaimsPrincipal.Current.Identity.Name;
            if (repository.ChangePassword(name, newPassword))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Conflict);
        }
    }
}

