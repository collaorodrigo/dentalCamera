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
using Microsoft.Win32;

namespace DentalCamera
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int contador;
        protected const string ruta = "C:\\temp\\";
        //protected List<WebCameraId> cameras; 
        public MainWindow()
        {
            InitializeComponent();
            ListaCamara.ItemsSource = Camara1.GetVideoCaptureDevices();
            contador = ListaCamara.Items.Count;
            //ruta = "C:\\temp\\";
            if (contador != 0)
            {
                ListaCamara.SelectedItem = ListaCamara.Items[0];
            }


        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            //ListaCamara.SelectedItem;
            var cameraId = (WebCameraId)ListaCamara.SelectedItem;
            Camara1.StartCapture(cameraId);
            // buttonCaptura.IsEnabled = true;
            // buttonStop.IsEnabled = true;
        }

        private void buttonCaptura_Click(object sender, RoutedEventArgs e)
        {

            string ruta1 = System.DateTime.Now.ToString("yyyy-mmm-d-HH-mm-ss");
            ruta1 = ruta + ruta1;
            Camara1.GetCurrentImage().Save(ruta1 + ".jpg");

        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            Camara1.StopCapture();
        }

        private void ListaCamara_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            buttonStart.IsEnabled = e.AddedItems.Count > 0;
        }
    }
}
