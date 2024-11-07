using autoservice_dataservice.DB;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        AutoServiceDBEntities db;
        int logCount = 0;
        public Login()
        {
            InitializeComponent();
            db = new AutoServiceDBEntities();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var NewForm = new Register();
            NewForm.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var Active_User = db.User.FirstOrDefault(x => x.Login == Log.Text && x.Password == Pass.Text);
                if (Active_User != null) {
                    
                    if (Log.Text == "ADMIN" && Pass.Text == "ADMIN")
                    {
                        MessageBox.Show("Добро пожаловать Администратор");
                        var Log_To_Main = new MainWindow();
                        this.Close();
                        Log_To_Main.Show();
                    }
                    else 
                    {
                        MessageBox.Show($"Добро пожаловать наш любимый {Log.Text}");
                        var Log_To_Client_Win = new Client_Window();
                        this.Close();
                        Log_To_Client_Win.Show();
                    }
                }
                else
                {
                    if(logCount % 3 == 0)
                    {
                        var Newform = new CapchaWindow();
                        Newform.Show();
                    }
                    else
                    {
                        MessageBox.Show("User was not found!");
                        logCount++;
                    }
                    
                }
            }
            catch 
            {
                MessageBox.Show("ERROR");
            }
            


        }
    }
}
