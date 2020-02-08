using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totalizator.Models;
using Totalizator.Models.DbModel;
using Totalizator.Models.DomenModel;
using Totalizator.Models.Enums;
using Totalizator.Services;

namespace Totalizator.Controllers
{
    [Authorize(Roles = "Admin, Moderator, User")]
    public class EventController : ApiController
    {
        IEventRepository repository;

        public EventController(IEventRepository eventRepository)
        {
            repository = eventRepository;
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet]
        public string GetStatusList()
        {
            var listOfStatuses = typeof(EventStatusEnum).GetEnumNames();

            return JsonConvert.SerializeObject(listOfStatuses);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet]
        public string GetTypesList()
        {
            totalizatorEntities dB = new totalizatorEntities();
            dB.Configuration.LazyLoadingEnabled = false;
            var typesList = dB.Types.ToList();
            return JsonConvert.SerializeObject(typesList);
        }

        [HttpGet]
        public string GetCountOfEvents()
        {
            var countOfEvents = repository.GetCountOfEvents();
            return JsonConvert.SerializeObject(countOfEvents);
        }

        [HttpGet]
        public string GetEventsList(int pageNumber)
        {
            var eventsList = repository.ListEvent(pageNumber);
            List<EventDomenModel> eventListDomen = new List<EventDomenModel>();
            foreach (Event e in eventsList)
            {
                EventDomenModel eventItemDomen = Mapper.Map<EventDomenModel>(e);
                eventListDomen.Add(eventItemDomen);
            }
            return JsonConvert.SerializeObject(eventListDomen);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public HttpResponseMessage Register(EventDomenModel domenEventData)
        {
            if (domenEventData != null) //TODO ADD VALIDATION
            {
                Event eventData = Mapper.Map<Event>(domenEventData);
                eventData.CreateDate = DateTime.Now;
                eventData.EditDate = null;
                eventData.EditorId = null;
                if (eventData.Status == 0) eventData.WinnerId = null;
                repository.AddEvent(eventData);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public HttpResponseMessage Edit(EventDomenModel domenEventData)
        {
            if (domenEventData != null) //TODO ADD VALIDATION
            {
                Event eventData = Mapper.Map<Event>(domenEventData);
                eventData.EditDate = DateTime.Now;
                repository.UpdateEvent(eventData);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
