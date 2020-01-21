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
        public string GetUserNameFromToken()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var name = ClaimsPrincipal.Current.Identity.Name;
            return name;
        }

        [HttpGet]
        public string GetUserNameById(int id)
        {
            string json = JsonConvert.SerializeObject(repository.GetUserById(id).FirstOrDefault());
            return json;
        }

        [HttpPost]
        public HttpResponseMessage Register(User userData)
        {
            if (userData != null)
            {
                //if (userData.UserName.Length > 3 && userData.UserName.Length < 15)
                //{
                //    if (userData.Password.Length > 6 && userData.Password.Length < 10)
                //    {
                //        if (userData.Email.Length > 5 && userData.Email.Length < 40)
                //        {
                            repository.AddUser(userData);
                            return new HttpResponseMessage(HttpStatusCode.OK);
            //            }
            //        }
            //    }
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }


        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        public void DeleteUser(User user)
        {
            if (user != null)
            {
                repository.DeleteUser(user.Id);
            }
        }
    }
}
