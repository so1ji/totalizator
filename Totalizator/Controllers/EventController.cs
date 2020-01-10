using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Services;

namespace Totalizator.Controllers
{
    public class EventController : ApiController
    {
        IEventRepository _repo;

        public EventController(IEventRepository eventRepository)
        {
            _repo = eventRepository;
        }
    }
}
