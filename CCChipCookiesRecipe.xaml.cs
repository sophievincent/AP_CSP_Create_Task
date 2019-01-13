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
    /// Interaction logic for CCChipCookiesRecipe.xaml
    /// </summary>
    public partial class CCChipCookiesRecipe : Window
    {
        public CCChipCookiesRecipe()
        {
            InitializeComponent();

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Block9";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canRecipe.Background = bkg;

            txtTitle.Text = "Choco-\nlate\nChoco-\nlate\nChip\nCookie \nRecipe\n";
            txtRecipe.Text = "Ingredients: \n\n1 1/2 cups sugar \n2 cups flour \n2/3 cup cocoa powder \n2 sticks butter \n2 eggs \n1/4 teaspoon salt \n2 cups chocolate chips \n2 teaspoons vanilla \n2 teaspoons milk " +
                "\n\n\n Instructions: \n\n1. Measure all ingredients and mix in a bowl \n2. Place on baking sheet \n3. Set oven to 350 \n4. Cook for 10 minutes \n5. Let cool before removing from baking sheet";
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



