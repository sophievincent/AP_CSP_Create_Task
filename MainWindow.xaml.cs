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

namespace CreateTaskFinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Button btnTest = new Button();
        //^^^this works, doesn't make button appear

        public MainWindow()
        {

            InitializeComponent();

            ImageBrush bgin = new ImageBrush();
            String bginID = "Block3";
            bgin.ImageSource = convertToBitmapSource(bginID);
            btnBegin.Background = bgin;

            ImageBrush info = new ImageBrush();
            String infoID = "Block2";
            info.ImageSource = convertToBitmapSource(infoID);
            btnInfo.Background = info;

            ImageBrush bkg = new ImageBrush();
            String bkgID = "MainBackground";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canMainScreen.Background = bkg;

            convertAllImagesToBitmapSource();
        }

        public BitmapSource convertToBitmapSource(string imageFileResourceName)
        {

            System.Drawing.Bitmap picture = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(imageFileResourceName);
            // Problem - the image is returned as a bitmap, but the 
            // source property of the image box requires a 'BitmapSource'.
            // Converting Bitmap to BitmapSource here.
            System.Windows.Media.Imaging.BitmapSource sourcePicture =
                CustomExtensions.BitmapSourceExtension.ToBitmapSource(picture);
            //pass the source back from the function, do a return
            return sourcePicture;
        }

        private void convertAllImagesToBitmapSource()
        {
            
        }
        private void BeginGame_Click(object sender, RoutedEventArgs e)
        {
            Baking taskWindow = new Baking();
            taskWindow.Show();
            this.Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Information taskWindow = new Information();
            taskWindow.Show();
        }
    }
}
