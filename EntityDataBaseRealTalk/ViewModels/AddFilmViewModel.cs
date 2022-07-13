using EntityDataBaseRealTalk.ViewModels.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBaseRealTalk.ViewModels
{
    class AddFilmViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        DataBaseContext _context = new DataBaseContext();
        Cinema _cinema;
        List<Actors> _actors;
        Actors _actor;
        public Actors SelectedActor
        {
            get { return _actor; }
            set
            {
                _actor = value;
                Notify("SelectedActor");
            }
        }

        public List<Actors> MainActors
        {
            get { return _actors; }
            set
            {
                _actors = value;
                Notify("MainActors");
            }
        }
        public AddFilmViewModel()
        {
            MyCinema = new Cinema();
            MyCinema.Name = "";
            MainActors = _context.Actorss.ToList();
        }
        public Cinema MyCinema
        {
            get { return _cinema; }
            set
            {
                _cinema = value;
                Notify("MyCinema");
            }
        }
        bool CanExecute()
        {
            if (_cinema.Name != "" && _cinema.Poster != "")
                return true;
            return false;
        }
        void SaveToDataBase (object obj)
        {
            MyCinema.Status = "I haven't watched this film";
            MyCinema.Mainactors = _actor;
            _context.Cinemas.Add(MyCinema);
            _context.SaveChanges();
            AddFilm addFilm = (AddFilm)obj; // в качестве параметра окно, которое мы должны закрыть
            addFilm.Close();
        }
        public ButtonCommand SaveCinemaToDataBase
        {
            get { return new ButtonCommand(SaveToDataBase, CanExecute); }
        }
        public ButtonCommand AddPoster
        {
            get
            {
                return new ButtonCommand(new Action<object>((obj) =>
          {
              OpenFileDialog openFile = new OpenFileDialog();
              openFile.Filter = "png|*.png|jpg|*.jpg|jpeg|*.jpeg";
              if (openFile.ShowDialog() == true)
              {
                  MyCinema.Poster = openFile.FileName;
                  Notify("MyCinema");
              }
          }
          ));
            }
        }
        void Notify (string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}