using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Totalizator.Services;
using Ninject.Web.WebApi;

namespace Totalizator.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserService>();
            Bind<IEventRepository>().To<EventService>();
            Bind<ITeamRepository>().To<TeamService>();
            Bind<IBetRepository>().To<BetService>();
        }
    }
}