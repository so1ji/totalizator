using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Models;
using Totalizator.Models.Enums;
using Totalizator.Services;

namespace Totalizator.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventController : ApiController
    {
        IEventRepository repository;

        public EventController(IEventRepository eventRepository)
        {
            repository = eventRepository;
        }


        [HttpGet]
        public string GetStatusList()
        {
            var listOfStatuses = Enum.GetNames(typeof(EventStatusEnum));


            return JsonConvert.SerializeObject(listOfStatuses);
        }

        public string GetTypesList()
        {
            sweeptakesDBEntities dB = new sweeptakesDBEntities();
            var typesList = dB.Types.ToList();
            return JsonConvert.SerializeObject(typesList);
        }

        [HttpPost]
        public HttpResponseMessage Register(Event eventData)
        {
            if (eventData != null) //TODO ADD VALIDATION
            {
                repository.AddEvent(eventData);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

    }
}
