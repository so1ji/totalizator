using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models.DbModel;
using Totalizator.Models.DomenModel;
using Totalizator.Models.Enums;

namespace Totalizator.Models
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((cfg) =>
            {
                cfg.CreateMap<EventDomenModel, Event>()
                .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date)))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => (byte)(EventStatusEnum)Enum.Parse(typeof(EventStatusEnum), src.Status)));

                cfg.CreateMap<Event, EventDomenModel>()
                .ForMember(x => x.TeamFirstName, opt => opt.MapFrom(src => src.Team.Name))
                .ForMember(x => x.TeamSecondName, opt => opt.MapFrom(src => src.Team1.Name))
                .ForMember(x => x.TypeName, opt => opt.MapFrom(src => src.Type.Name))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(EventStatusEnum), src.Status)))
                .ForMember(x => x.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd HH:mm")));

                cfg.CreateMap<User, UserDomenModel>()
                .ForMember(x => x.Roles, opt => opt.MapFrom(src => src.Roles.FirstOrDefault().Name));
                cfg.CreateMap<UserDomenModel, User>();


                cfg.CreateMap<BetDomenModel, Bet>();
                cfg.CreateMap<Bet, BetDomenModel>()
                .ForMember(x => x.EventName, opt => opt.MapFrom(src => src.Event.Name))
                .ForMember(x => x.EventDate, opt => opt.MapFrom(src => src.Event.Date.ToString("yyyy-MM-dd HH:mm")))
                .ForMember(x => x.EventStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(EventStatusEnum), src.Event.Status)))
                .ForMember(x => x.Winner, opt => opt.MapFrom(src => src.Event.WinnerId));
            });
        }
    }
}
