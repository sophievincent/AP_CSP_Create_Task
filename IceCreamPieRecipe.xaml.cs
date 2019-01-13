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
    /// Interaction logic for IceCreamPieRecipe.xaml
    /// </summary>
    public partial class IceCreamPieRecipe : Window
    {
        public IceCreamPieRecipe()
        {
            InitializeComponent();

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Block9";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canRecipe.Background = bkg;

            txtTitle.Text = "Ice\nCream\n \nPie\n \nRecipe\n";
            txtRecipe.Text = "Ingredients: \n\n2 quarts ice cream \n3/4 cups crushed cookies " +
                "\n\n\n Instructions: \n\n1. Measure all ingredients and mix in a bowl \n2. Pour into pie crust \n3. Set in freezer \n4. Freeze for 80 minutes \n5. Let set before serving";
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
    }
}


