using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Totalizator.Services;
using Ninject.Web.WebApi;
using System.Data.Entity;
using Totalizator.Models.DbModel;

namespace Totalizator.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<totalizatorEntities>();
            
            Bind<IUserRepository>().To<UserService>();
            Bind<IEventRepository>().To<EventService>();
            Bind<ITeamRepository>().To<TeamService>();
            Bind<IBetRepository>().To<BetService>();
        }
    }
}