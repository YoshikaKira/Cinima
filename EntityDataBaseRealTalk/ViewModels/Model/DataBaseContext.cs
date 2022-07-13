using EntityDataBaseRealTalk.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBaseRealTalk
{
    class DataBaseContext: DbContext 
    {
        // консоль диспетчера пакетов (вид - другие окна - консоль диспетчера пакетов)
        // enable-migrations
        // add-migration first
        // update-database

        // ctrl+alt+x - вызов кнопок для ксамла
        public DataBaseContext():base("DefaultConnection") // наследуемся от базового класса defaultconnection
        {

        }
        public DbSet <Cinema> Cinemas { get; set; } // DbSet - лист для таблиц баз данных
        public DbSet<Actors> Actorss { get; set; }
    }
}