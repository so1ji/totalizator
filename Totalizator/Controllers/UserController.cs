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
        public string GetAllUsers()
        {
            var users = repository.ListUser();
            return JsonConvert.SerializeObject(users);
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
        public void DeleteUser(UserDomenModel userDomen)
        {
            if (userDomen != null)
            {
                var user = Mapper.Map<User>(userDomen);
                repository.DeleteUser(user.Id);
            }
        }
    }
}
