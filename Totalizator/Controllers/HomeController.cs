using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Totalizator.Services;
using Ninject;

namespace Totalizator.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository _repo;
        public HomeController(IUserRepository userRepository)
        {
            _repo = userRepository;
        }

        public HomeController()
        {

        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }


        public ActionResult Main()
        {
            return View();
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        public ActionResult NewBet()
        {
            return View();
        }

        public ActionResult EditEvent()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }

    }
}
