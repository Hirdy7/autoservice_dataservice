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

namespace autoservice_dataservice.DB
{
    /// <summary>
    /// Логика взаимодействия для CapchaWindow.xaml
    /// </summary>
    public partial class CapchaWindow : Window
    {
        private string captchaText;
        private Capcha captchaGenerator = new Capcha();

        public CapchaWindow()
        {
            InitializeComponent();
            RefreshCaptcha();
        }

        private void RefreshCaptcha()
        {
            BitmapImage captchaImage = captchaGenerator.GenerateCaptchaBitmapImage(out captchaText);
            img.Source = captchaImage;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaInput.Text == captchaText)
            {
                MessageBox.Show("Captcha verified!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect captcha. Try again.");
                RefreshCaptcha();
            }
        }
    }
}
