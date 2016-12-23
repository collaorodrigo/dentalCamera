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
using WebEye.Controls.Wpf;

namespace DentalCamera
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int contador;
        public MainWindow()
        {
            InitializeComponent();
            ListaCamara.ItemsSource = Camara1.GetVideoCaptureDevices();
            contador = ListaCamara.Items.Count;
            if (contador != 0)
            {
                ListaCamara.SelectedItem = ListaCamara.Items[0];
            }
            else
            {
                buttonStart.IsEnabled = false;
            }
        }
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            //ListaCamara.SelectedItem;
            var cameraId = (WebCameraId)ListaCamara.SelectedItem;
            Camara1.StartCapture(cameraId);
            buttonCaptura.IsEnabled = true;
        }

        private void buttonCaptura_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
            //  BitmapImage image = new BitmapImage(Camara1.GetCurrentImage();
        }
    }
}
