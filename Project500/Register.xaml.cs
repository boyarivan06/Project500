using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project500
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        User self_user = new User();
        public Register()
        {
            InitializeComponent();
            return_button.Click += Return_button_Click;
            this.Closed += Register_Closing;
        }

        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            ((Window)((StackPanel)((FlowDocumentScrollViewer)((FlowDocument)sender).Parent).Parent).Parent).Close();
        }

        private void Register_Closing(object sender, EventArgs e)
        {

            var newDialog = new Register();
            newDialog.ShowDialog();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText("db/users"));
            bool OK = false;
            bool only_name = false;
            foreach (User user in users)
            {
                if (user.Name == name_box.Text && user.Password == password_box.Password)
                {
                    OK = true;
                    self_user = user;
                    break;
                }
                else if (user.Name == name_box.Text && user.Password != password_box.Password)
                {
                    only_name = true;
                }
            }
            if (OK)
            {
                
                warning_label.Visibility = Visibility.Visible;
                warning_label.Content = "Успешно";
                warning_label.Foreground = new SolidColorBrush(Colors.Green);
                //Thread.Sleep(2000);
                //OK = true;
                enter_button.Content = "Готово";
                enter_button.Click += (object sender1, RoutedEventArgs e1) => { this.Close(); };
                name_box.IsEnabled = false; password_box.IsEnabled = false;
                only_name = false;
                this.Closed -= Register_Closing; 
            }
            else if (only_name)
            {
                warning_label.Content = "Неверный пароль";
            }
            else
            {
                warning_label.Content = "Подтвердите создание нового пользователя";
                enter_button.Content = "Зарегистрироваться";
                enter_button.Click += NewUser;
                //return_button -= Return_button_Click;

                return_button.Visibility = Visibility.Visible;
            }
        }

        private void NewUser(object sender, RoutedEventArgs e)
        {
            var user = new User { Name = name_box.Text, Password = password_box.Password, Created = DateTime.Now};
            self_user = user;
            List<User> users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText("db/users"));
            users.Add(user);
            warning_label.Content = "Успешно";
            warning_label.Foreground = new SolidColorBrush(Colors.Green);
            File.WriteAllText("db/users", JsonSerializer.Serialize(users));
            //Thread.Sleep(1000);
            //bool OK = true;
            enter_button.Content = "Готово";
            enter_button.Click += (object sender1, RoutedEventArgs e1) => { Close(); };
            name_box.IsEnabled = false; password_box.IsEnabled = false;
            this.Closing -= Register_Closing;
            //only_name = false;
            
        }

        /*private void CloseIf(bool all_ok)
        {
            if (all_ok)
            {
                this.Close();
            }
            else
            {

            }
        }*/

        private void return_button_Click(object sender, RoutedEventArgs e)
        {
            warning_label.Content = string.Empty;
            enter_button.Content = "Войти";
            return_button.Visibility = Visibility.Collapsed;
            name_box.Text = string.Empty;
        }
    }
}
