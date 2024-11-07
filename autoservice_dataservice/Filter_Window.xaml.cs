using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Логика взаимодействия для Filter_Window.xaml
    /// </summary>
    public partial class Filter_Window : Window
    {
        AutoServiceDBEntities db;
        public Filter_Window()
        {
            InitializeComponent();
            db = new AutoServiceDBEntities();
            combobind();
            Dg_Vehicles.ItemsSource = db.Vehicles.ToList();
        }

        private void combobind()
        {
            
            var vehicles = db.Vehicles.ToList();
            Cb_Vehicles.ItemsSource = vehicles; 
        }

        private void Cb_Vehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (Cb_Vehicles.SelectedItem is Vehicles selectedVehicle)
            {
                Dg_Vehicles.ItemsSource = db.Vehicles.Where(x => x.VehicleID == selectedVehicle.VehicleID).ToList();
                
            }

            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (int.TryParse(Tb_Year.Text, out int year))
            {
                Dg_Vehicles.ItemsSource = db.Vehicles.Where(x => x.Year == year) .ToList();
            }
            else
            {
                
                Dg_Vehicles.ItemsSource = db.Vehicles.ToList(); 
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
          Dg_Vehicles.ItemsSource = db.Vehicles.ToList();            
        }

        private void Button_Click_Report(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog pD = new PrintDialog();
                if (pD.ShowDialog() == true)
                {
                    pD.PrintVisual(Dg_Vehicles, "Project");
                }
            }
            finally
            {
                this.IsEnabled=true;
            }
        }

        
    }
}
