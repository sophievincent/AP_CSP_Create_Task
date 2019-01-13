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

namespace CreateTaskFinalProject
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Block10";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canInfoPage.Background = bkg;

            ImageBrush close = new ImageBrush();
            String closeID = "Block3";
            close.ImageSource = convertToBitmapSource(closeID);
            btnClose.Background = close;

            txtTitle.Text = "Instructions";
            txtInstructions.Text = "1. click the 'Let's begin baking' button to start \n2. Choose what kind of dessert you want to make \n3. Choose your flavor\n 4. Follow the recipe to add ingredients into the bowl" +
                "\n4. Click the 'Mix!' button to start the baking \n5. Marval at how good your creation looks!";
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

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
