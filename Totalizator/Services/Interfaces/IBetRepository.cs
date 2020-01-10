using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totalizator.Models;

namespace Totalizator.Services
{
    public interface IBetRepository
    {
        IEnumerable<Bet> ListBet();
        void AddBet(Bet item);
    }
}
