using EntityDataBaseRealTalk.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBaseRealTalk
{
    class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPublishment { get; set; }
        public string Poster { set; get; }
        public string Status { get; set; }
        public Actors Mainactors { get; set; }
    }
}