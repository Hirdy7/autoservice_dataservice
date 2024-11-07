using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
using System.Data;
using System.Data.SqlClient;


namespace autoservice_dataservice
{
    /// <summary>
    /// Логика взаимодействия для Form_For_Window.xaml
    /// </summary>
    public partial class Form_For_Window : Window
    {
        private int ClntID;
        AutoServiceDBEntities db;
        public Form_For_Window()
        {
            InitializeComponent();
            db = new AutoServiceDBEntities();
           
        }
        static void sql()
        {
           string connectionString = "Server=192.168.147.54;Database=AutoServiceDB;User Id=is;Password=1;";
            string query = "SELECT * FROM Vehicles WHERE VehicleID = @VehicleID";
            Console.Write("Введите VehicleID: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int vehicleId))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.Add(new SqlParameter("@VehicleID", vehicleId));

                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            if (reader.HasRows)
                            {
                                
                                while (reader.Read())
                                {
                                    
                                    Console.WriteLine($"Make: {reader["Make"]}, Model: {reader["Model"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Транспортное средство не найдено.");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Введите корректный VehicleID.");
            }




        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients Vehicles_Form_ADD = new Clients();
            Vehicles_Form_ADD.ClientID = Convert.ToInt32(ClientID.Text);
            Vehicles_Form_ADD.FirstName = FirstName.Text;
            Vehicles_Form_ADD.LastName = LastName.Text;
            Vehicles_Form_ADD.Email = Email.Text;
            Vehicles_Form_ADD.Phone = Phone.Text;
            Vehicles_Form_ADD.Address = Address.Text;
            db.Clients.Add(Vehicles_Form_ADD);
            db.SaveChanges();
            this.Close();
            RestartApp();




        }
        public static void RestartApp()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();


        }

        

        

    }
}
