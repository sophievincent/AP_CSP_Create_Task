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
    /// Interaction logic for ApplePieRecipe.xaml
    /// </summary>
    public partial class ApplePieRecipe : Window
    {
        public ApplePieRecipe()
        {
            InitializeComponent();

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Block9";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canRecipe.Background = bkg;

            txtTitle.Text = "Apple\n \nPie\n \nRecipe\n";
            txtRecipe.Text = "Ingredients: \n\n2/3 cups sugar \n3 lbs apples \n1/2 stick butter \n1/4 teaspoons cinnamon " +
                "\n\n\n Instructions: \n\n1. Measure all ingredients and mix in a bowl \n2. Pour into pie crust \n3. Set oven to 375 \n4. Cook for 50 minutes \n5. Let cool before enjoying";
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


