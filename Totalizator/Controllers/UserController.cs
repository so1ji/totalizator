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
    [Authorize(Roles = "Admin, Moderator, User")]
    public class UserController : ApiController
    {
        IUserRepository repository;

        public UserController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public string GetCountOfUsers()
        {
            var countOfUsers = repository.GetCountOfUsers();
            return JsonConvert.SerializeObject(countOfUsers);
        }

        [HttpGet]
        [AllowAnonymous]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [AllowAnonymous]
        public HttpResponseMessage Register(UserDomenModel userDomenData)
        {
            if (repository.CheckEmailAndUserName(userDomenData.Email, userDomenData.UserName))
            {
                if (userDomenData != null)
                {
                    var userData = Mapper.Map<User>(userDomenData);
                    repository.AddUser(userData);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.Conflict);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteUser(UserDomenModel userDomen)
        {
            if (userDomen != null)
            {
                ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                var name = ClaimsPrincipal.Current.Identity.Name;
                if (userDomen.UserName == name)
                {
                    return new HttpResponseMessage(HttpStatusCode.Conflict);
                }
                var user = Mapper.Map<User>(userDomen);
                repository.DeleteUser(user.Id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Moderator, User")]
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
        [Authorize(Roles = "Admin, Moderator, User")]
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
        [Authorize(Roles = "Admin, Moderator, User")]
        public HttpResponseMessage ChangePassword(string newPassword)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var name = ClaimsPrincipal.Current.Identity.Name;
            if (repository.ChangePassword(name, newPassword))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Conflict);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin, Moderator, User")]
        public HttpResponseMessage DeleteCurrentUser()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var name = ClaimsPrincipal.Current.Identity.Name;
            var user = repository.GetUserByName(name);
            repository.DeleteUser(user.Id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

