using EntityDataBaseRealTalk.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EntityDataBaseRealTalk.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        DataBaseContext context;
        List<Cinema> _cinemas;
        string _find;
        Cinema _selectedItem;
        List<Actors> _actors;
        Actors _actor;

        public Cinema SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                _actors = context.Actorss.ToList();
                MainActors = (from A in _actors where A.Id == _selectedItem.Mainactors.Id select A).FirstOrDefault();
               // MessageBox.Show(MainActors.Name);
                Notify("SelectedItem");
            }
        }
        public Actors MainActors
        {
            get { return _actor; }
            set
            {
                _actor = value;
                Notify("MainActors");
            }
        }
        public ButtonCommand ChangeStatus
        {
            get
            {
                return new ButtonCommand(new Action<object>((obj) =>
          {
              SelectedItem.Status = "I've watched this film";
              context.SaveChanges();
              MyFilms = context.Cinemas.ToList();
          }
          ),
          new Func<bool>(() =>
        {
            return _selectedItem != null;
        })

                    );
            }
        }
        public string Find
        {
            get { return _find; }
            set { _find = value;
                Notify("Find");
                MyFilms = (from cinema in context.Cinemas
                           where cinema.Name.Contains(_find)
                           select cinema).ToList();
            }
        }
        public ButtonCommand Delete
        {
            get
            {
                return new ButtonCommand(new Action<object>((obj) =>
                {
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удалить запись?",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.Cinemas.Remove(SelectedItem);
                        context.SaveChanges();
                        MyFilms = context.Cinemas.ToList();
                    }
                })
                   , new Func<bool>(() => { return _selectedItem != null; }));
            }
        }
        public List <Cinema> MyFilms
        {
            get { return _cinemas; }
            set
            {
                _cinemas = value;
                Notify("MyFilms");
            }
        }
        public ButtonCommand AddClick
        {
            get
            {
                return new ButtonCommand(new Action<object>((obj) =>
                {
                    AddFilm addFilm = new AddFilm();
                    addFilm.ShowDialog();
                    MyFilms = context.Cinemas.ToList();
                }
          ));
            }
        }
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainWindowViewModel()
        {
            context = new DataBaseContext();
            MyFilms = context.Cinemas.ToList();
        }
    }
}