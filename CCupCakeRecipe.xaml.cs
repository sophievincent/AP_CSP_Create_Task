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
    /// Interaction logic for CCupCakeRecipe.xaml
    /// </summary>
    public partial class CCupCakeRecipe : Window
    {
        public CCupCakeRecipe()
        {
            InitializeComponent();

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Block9";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canRecipe.Background = bkg;

            txtTitle.Text = "Choco-\nlate\n \nCake\n \nRecipe\n";
            txtRecipe.Text = "Ingredients: \n\n2 cups sugar \n1 3/4 cups flour \n3/4 cup cocoa powder \n1 1/2 teaspoons baking powder \n2 eggs \n1 teaspoon salt \n1/2 cup vegetable oil \n2 teaspoons vanilla \n1 cup milk " +
                "\n\n\n Instructions: \n\n1. Measure all ingredients and mix in a bowl \n2. Pour into cupcake pan \n3. Set oven to 350 \n4. Cook for 35 minutes \n5. Let cool before removing from pan and decorating";
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


