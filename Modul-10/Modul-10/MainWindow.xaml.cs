using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
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

namespace Modul_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        Entities1 bd = new Entities1();
        private void LoadData()
        {
            var clien = bd.Users.ToList();
            ListView1.ItemsSource = clien;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tt = ListView1.SelectedIndex;
            List<Users> client = ListView1.SelectedItems.Cast<Users>().ToList();
            Window1 window1 = new Window1(client);//client);
            window1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Users> clients = ListView1.SelectedItems.Cast<Users>().ToList();
            if (clients.Count > 0)
            {
                string loginToRemove = clients[0].Login;
                var removeUser = bd.Users.FirstOrDefault(x => x.Login.Contains(loginToRemove));
                if (removeUser != null)
                {
                    bd.Users.Remove(removeUser);
                    bd.SaveChanges();
                    LoadData();
                }
            }
        }
    }
}
