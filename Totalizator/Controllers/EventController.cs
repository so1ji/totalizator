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


        [HttpGet]
        public string GetStatusList()
        {
            var listOfStatuses = typeof(EventStatusEnum).GetEnumNames();

            return JsonConvert.SerializeObject(listOfStatuses);
        }

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

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDomenModel, Event>()
                .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date)))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => (byte)(EventStatusEnum)Enum.Parse(typeof(EventStatusEnum), src.Status)));

                cfg.CreateMap<Event, EventDomenModel>()
                .ForMember(x => x.TeamFirstName, opt => opt.MapFrom(src => src.Team.Name))
                .ForMember(x => x.TeamSecondName, opt => opt.MapFrom(src => src.Team1.Name))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(EventStatusEnum), src.Status)))
                .ForMember(x => x.Date, opt=> opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd HH:mm")));
            }
);

            var eventsList = repository.ListEvent(pageNumber);

            var mapper = new Mapper(config);
            List<EventDomenModel> eventListDomen = new List<EventDomenModel>();

            foreach (Event e in eventsList)
            {
                EventDomenModel eventItemDomen = mapper.Map<Event, EventDomenModel>(e);
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
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EventDomenModel, Event>()
                    .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date)))
                    .ForMember(x => x.Status, opt => opt.MapFrom(src => (byte)(EventStatusEnum)Enum.Parse(typeof(EventStatusEnum), src.Status)));

                    cfg.CreateMap<Event, EventDomenModel>()
                    .ForMember(x => x.TeamFirstName, opt => opt.MapFrom(src => src.Team.Name))
                    .ForMember(x => x.TeamSecondName, opt => opt.MapFrom(src => src.Team1.Name))
                    .ForMember(x => x.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(EventStatusEnum), src.Status)))
                    .ForMember(x => x.TypeName, opt => opt.MapFrom(src => src.Type.Name));
                }
                );

                var mapper = new Mapper(config);

                Event eventData = mapper.Map<Event>(domenEventData);
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
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EventDomenModel, Event>()
                    .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date)))
                    .ForMember(x => x.Status, opt => opt.MapFrom(src => (byte)(EventStatusEnum)Enum.Parse(typeof(EventStatusEnum), src.Status)));

                    cfg.CreateMap<Event, EventDomenModel>()
                    .ForMember(x => x.TeamFirstName, opt => opt.MapFrom(src => src.Team.Name))
                    .ForMember(x => x.TeamSecondName, opt => opt.MapFrom(src => src.Team1.Name))
                    .ForMember(x => x.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(EventStatusEnum), src.Status)))
                    .ForMember(x => x.TypeName, opt => opt.MapFrom(src => src.Type.Name));
                }
                );

                var mapper = new Mapper(config);

                Event eventData = mapper.Map<Event>(domenEventData);
                eventData.EditDate = DateTime.Now;
                repository.UpdateEvent(eventData);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

    }
}
