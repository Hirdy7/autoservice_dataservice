using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace autoservice_dataservice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AutoServiceDBEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AutoServiceDBEntities();
            dgVehicles.ItemsSource = db.Vehicles.ToList();
            dgClients.ItemsSource = db.Clients.ToList();
        }
        
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            dgVehicles.ItemsSource = db.Vehicles.ToList();
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
  
            Vehicles pr = new Vehicles();
            pr.VehicleID = Convert.ToInt32(tbId.Text);
            pr.Make = tbMAKE.Text;
            pr.Model = tbMODEL.Text;
            pr.Year = Convert.ToInt32(tbYEAR.Text);
            pr.LicensePlate = tbLICENSE.Text;
            pr.ClientID = Convert.ToInt32(tbCLIENT.Text);
            db.Vehicles.Add(pr);
            db.SaveChanges();
            dgVehicles.ItemsSource = db.Vehicles.ToList();

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            int sDId = Convert.ToInt32(tbId.Text);
            var selectDID = db.Vehicles.Where(w => w.VehicleID == sDId).FirstOrDefault();
            db.Vehicles.Remove(selectDID);
            db.SaveChanges();
            dgVehicles.ItemsSource = db.Vehicles.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int sUpId = Convert.ToInt32(tbId.Text);
            var selecUptId = db.Vehicles.Where(w => w.VehicleID == sUpId).FirstOrDefault();
            selecUptId.VehicleID = Convert.ToInt32(tbId.Text);
            selecUptId.Make = tbMAKE.Text;
            selecUptId.Model = tbMODEL.Text;
            selecUptId.Year = Convert.ToInt32(tbYEAR.Text);
            selecUptId.LicensePlate = tbLICENSE.Text;
            selecUptId.ClientID = Convert.ToInt32(tbCLIENT.Text);
            db.SaveChanges();
            dgVehicles.ItemsSource = db.Vehicles.ToList();
        }

        private void Button_Click_New(object sender, RoutedEventArgs e)
        {
            var NewForm = new Form_For_Window();
            NewForm.Show();                                    
        }

        private void Button_Click_Filter(object sender, RoutedEventArgs e)
        {
            var NewForm = new Filter_Window();
            NewForm.Show();
        }
    }
}
