using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Services;

namespace Totalizator.Controllers
{
    public class BetController : ApiController
    {

        IBetRepository _repo;

        public BetController(IBetRepository betRepository)
        {
            _repo = betRepository;
        }

    }
}
