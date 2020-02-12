using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totalizator.Models.DbModel
{
   public interface ITotalizatorContext
    {
        DbSet<Bet> Bets { get; }
        DbSet<Event> Events { get; }
        DbSet<Role> Roles { get; }
        DbSet<Team> Teams { get; }
        DbSet<Type> Types { get; }
        DbSet<User> Users { get; }
        DbSet<sysdiagram> sysdiagrams { get; }

        int SaveChanges();
    }
}
