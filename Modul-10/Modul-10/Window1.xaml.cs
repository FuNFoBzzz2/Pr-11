using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Modul_10
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Entities1 bd = new Entities1();
  
        Users ser = new Users();
        List<Users> user1;
        int bol = 0;
        public Window1(List<Users> user)
        {
            InitializeComponent();
            if (user1 != null)
            {
                user1.Clear();
            }
            if (user.Any())
            {
                user1 = user;
            }
            
            Loadtxt();
        }
        
        private void Loadtxt()
        {
            if (user1!=null)
            {
                bol = 1;
                txtName.Text = user1.First().Name;
                txtFName.Text = user1.First().FName;
                txtOtchestvo.Text = user1.First().Otchestvo;
                txtEmail.Text = user1.First().Email;
                txtJob.Text = user1.First().Job;
                txtLogin.Text = user1.First().Login;
                txtPassword.Text = user1.First().Password;
            }
            else {
                bol = 0;
                txtName.Clear();
                txtFName.Clear();
                txtOtchestvo.Clear();
                txtEmail.Clear();
                txtJob.Clear();
                txtLogin.Clear();
                txtPassword.Clear();
            }
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Regex reg = new Regex($"^\\S+@\\S+\\.\\S+$");
            if (bol==0) {
                if (txtName.Text.Any())
                {
                    if (txtFName.Text.Any())
                    {
                        if (txtOtchestvo.Text.Any())
                        {
                            if (txtEmail.Text.Any())//reg.ToString())
                            {
                                if (bd.Users.Where(x => x.Email.Equals(txtEmail.Text)).Any())
                                {
                                    MessageBox.Show("Пользователь с данным email уже зарегистрирован");
                                }
                                else {
                                    if (txtJob.Text.Any())
                                    {
                                        if (txtLogin.Text.Length >= 6)
                                        {
                                            var login = txtLogin.Text;
                                            var log = bd.Users.Where(x => x.Login.Equals(login));
                                            if (log.Any())
                                            {
                                                MessageBox.Show("Пользователь с данным логином уже зарегистрирован");
                                            }
                                            else
                                            {
                                                if (txtPassword.Text.Length >= 6)
                                                {
                                                    Users us = new Users()
                                                    {
                                                        FName = txtFName.Text,
                                                        Name = txtName.Text,
                                                        Otchestvo = txtOtchestvo.Text,
                                                        Email = txtEmail.Text,
                                                        Job = txtJob.Text,
                                                        Login = txtLogin.Text,
                                                        Password = txtPassword.Text
                                                    };
                                                    bd.Users.Add(us);
                                                    bd.SaveChanges();
                                                    MainWindow mw = new MainWindow();
                                                    mw.Show();
                                                    this.Close();
                                                }
                                            }
                                        }
                                    }
                                    else { MessageBox.Show("Работа недействительна"); }
                                }
                            }
                            else { MessageBox.Show("Убедитесь что Маил поля заполнены!"); }
                        }
                        else { MessageBox.Show("Убедитесь что Отчество поля заполнены!"); }
                    }
                    else { MessageBox.Show("Убедитесь что Фамилия поля заполнены!"); }
                }
                else { MessageBox.Show("Убедитесь что Имя поля заполнены!"); }
            }
            else
            {
                if (txtName.Text.Any())
                {
                    if (txtFName.Text.Any())
                    {
                        if (txtOtchestvo.Text.Any())
                        {
                            if (txtEmail.Text.Any()) //== reg.ToString())
                            {
                                var email = txtEmail.Text;
                                if(email==user1.First().Email)
                                {
                                    if (txtJob.Text.Any())
                                    {
                                        if (txtLogin.Text.Any())
                                        {
                                            var login = txtLogin.Text;
                                            if (login == user1.First().Login)
                                            {
                                                var log = bd.Users.FirstOrDefault(x => x.Login.Equals(login));
                                                if (log==null)
                                                {
                                                    MessageBox.Show("Пользователь с данным логином уже зарегистрирован");
                                                }
                                                else
                                                {
                                                    if (txtPassword.Text.Length >= 6)
                                                    {
                                                        log.FName = txtFName.Text;
                                                        log.Name = txtName.Text;
                                                        log.Otchestvo = txtOtchestvo.Text;
                                                        log.Email = txtEmail.Text;
                                                        log.Job = txtJob.Text;
                                                        log.Login = txtLogin.Text;
                                                        log.Password = txtPassword.Text;
                                                        bd.SaveChanges();
                                                        MainWindow mw = new MainWindow();
                                                        mw.Show();
                                                        this.Close();
                                                    }
                                                }

                                            }
                                        }
                                        else { MessageBox.Show("Убедитесь что Логин при изменении поля заполнены!"); }
                                    }
                                    else { MessageBox.Show("Убедитесь что Работа при изменении поля заполнены!"); }
                                }
                                else 
                                {
                                    var resultemail = bd.Users.Where(x => x.Email.Equals(email));
                                    if (resultemail.Any())
                                    {
                                        MessageBox.Show("Такая почта существует в базе данных!");
                                    }
                                    else
                                    {
                                        if (txtJob.Text.Any())
                                        {
                                            if (txtLogin.Text.Length >= 6)
                                            {
                                                var login = txtLogin.Text;
                                                if (login == user1.First().Login)
                                                {
                                                    var log = bd.Users.Where(x => x.Login.Equals(login));
                                                    if (log.Any())
                                                    {
                                                        MessageBox.Show("Пользователь с данным логином уже зарегистрирован");
                                                    }
                                                    else
                                                    {
                                                        if (txtPassword.Text.Length >= 6)
                                                        {
                                                            Users us = new Users()
                                                            {
                                                                FName = txtFName.Text,
                                                                Name = txtName.Text,
                                                                Otchestvo = txtOtchestvo.Text,
                                                                Email = txtEmail.Text,
                                                                Job = txtJob.Text,
                                                                Login = txtLogin.Text,
                                                                Password = txtPassword.Text
                                                            };
                                                            bd.Users.Add(us);
                                                            bd.SaveChanges();
                                                            MainWindow mw = new MainWindow();
                                                            mw.Show();
                                                            this.Close();
                                                        }
                                                    }

                                                }
                                                else { }
                                            }
                                            else { MessageBox.Show("Убедитесь что Логин при изменении поля"); }
                                        }
                                        else { MessageBox.Show("Убедитесь что Работа при изменении поля заполнены!"); }
                                    }
                                }
                            }
                            else { MessageBox.Show("Убедитесь что Почта при изменении поля заполнены!"); }
                        }
                        else { MessageBox.Show("Убедитесь что Отчество при изменении поля заполнены!"); }
                    }
                    else { MessageBox.Show("Убедитесь что Фамилия при изменении поля заполнены!"); }
                }
                else { MessageBox.Show("Убедитесь что Имя при изменении поля заполнены!"); }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
