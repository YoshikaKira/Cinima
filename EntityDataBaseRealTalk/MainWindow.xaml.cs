using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityDataBaseRealTalk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBaseContext context = new DataBaseContext();
            Cinema cinema = new Cinema();
            cinema.Name = "Memento";
            cinema.DateOfPublishment = DateTime.Now.AddYears(-22);
            cinema.Poster = "C:\\1\\Memento.jpg";
            cinema.Status = "I watched this film";

            context.Cinemas.Add(cinema); // добавляем фильм в базу данных
            context.SaveChanges(); // добавляем данные в таблицу (отправляем запросы в базу данных)
            MessageBox.Show("It is done!");
        }*/
    }
}