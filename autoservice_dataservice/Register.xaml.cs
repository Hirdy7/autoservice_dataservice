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
using System.Windows.Shapes;

namespace autoservice_dataservice
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        AutoServiceDBEntities db;
        public Register()
        {
            InitializeComponent();
            db = new AutoServiceDBEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var NewForm = new Login();
            NewForm.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            db = new AutoServiceDBEntities();

            try
            {
                User user = new User();
                user.Login = Log.Text;
                user.Password = Pass.Text;
                db.User.Add(user);
                db.SaveChanges();
                MessageBox.Show("User was added!");

            }
            catch (Exception) 
            {
                MessageBox.Show("ERROR");
            }

        }
    }
}
