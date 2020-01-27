using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totalizator.Models;
using Totalizator.Models.DbModel;

namespace Totalizator.Services
{
  public  interface IEventRepository
    {
        IQueryable<Event> ListEvent(int pageNumber);
        void AddEvent(Event item);
    }
}
