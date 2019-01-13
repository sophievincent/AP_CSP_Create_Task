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
    /// Interaction logic for IceCreamPie.xaml
    /// </summary>
    public partial class IceCreamPie : Window
    {

        int intWholeMeas_IceCream = 0;
        int intFractionMeas_IceCream = 0;
        int intWholeMeas_Cookies = 0;
        int intFractionMeas_Cookies = 0;


        Boolean IceCreamAdded = false;
        Boolean CookiesAdded = false;

        Boolean done = false;

        public IceCreamPie()
        {
            InitializeComponent();

            txtInstructions.Text = "\n Get ready to start baking! Click on the book to \n check the recipe. Use the ''+'' and ''-'' buttons to \n add and subtract the amount that needs to be \n added. When the number matches the recipe click \n the ''Add In'' button to add it to the bowl! When \n you're all done click the ''Mix!'' button to move on!";

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Kitchen";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canIceCreamPie.Background = bkg;

            ImageBrush inst = new ImageBrush();
            String instID = "Block1";
            inst.ImageSource = convertToBitmapSource(instID);
            txtInstructions.Background = inst;

            ImageBrush recipe = new ImageBrush();
            String recipeID = "RecipeBook";
            recipe.ImageSource = convertToBitmapSource(recipeID);
            btnRecipe.Background = recipe;

            ImageBrush mix = new ImageBrush();
            String mixID = "Block3";
            mix.ImageSource = convertToBitmapSource(mixID);
            btnMix.Background = mix;

            btnMix.Content = "Mix!";
            btnMix.FontFamily = new FontFamily("LetterOMatic!");
            btnMix.FontSize = 48;

            btnNext.Opacity = 0;
            btnNext.Content = "";


            ImageBrush bubble = new ImageBrush();
            String bubbleID = "Block1";
            bubble.ImageSource = convertToBitmapSource(bubbleID);
            txtCount1.Background = bubble;
            txtCount2.Background = bubble;

            ImageBrush addblock = new ImageBrush();
            String addblockID = "Block4";
            addblock.ImageSource = convertToBitmapSource(addblockID);
            btnAdd1.Background = addblock;
            btnAdd2.Background = addblock;

            ImageBrush PandSBlock = new ImageBrush();
            String PandSBlockID = "Block5";
            PandSBlock.ImageSource = convertToBitmapSource(PandSBlockID);
            btnPlus1.Background = PandSBlock;
            btnSubtract1.Background = PandSBlock;
            btnPlus2.Background = PandSBlock;
            btnSubtract2.Background = PandSBlock;

            imgBowl.Source = convertToBitmapSource("EmptyBowl");

            imgIngredient1.Source = convertToBitmapSource("IceCream1");
            imgIngredient2.Source = convertToBitmapSource("Oreos");
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

        private void OpenRecipe(object sender, RoutedEventArgs e)
        {
            IceCreamPieRecipe taskWindow = new IceCreamPieRecipe();
            taskWindow.Show();
        }



        private void Add_IceCream(object sender, RoutedEventArgs e)
        {
            intFractionMeas_IceCream += 1;

            if (intFractionMeas_IceCream == 4)
            {
                intFractionMeas_IceCream = 0;
                intWholeMeas_IceCream += 1;
            }

            txtCount1.Text = intWholeMeas_IceCream.ToString() + " " + intFractionMeas_IceCream.ToString() + "/4";
        }

        private void Remove_IceCream(object sender, RoutedEventArgs e)
        {
            intFractionMeas_IceCream -= 1;

            if (intFractionMeas_IceCream < 0 && intWholeMeas_IceCream > 0)
            {
                intFractionMeas_IceCream = 3;
                intWholeMeas_IceCream -= 1;
            }

            if (intFractionMeas_IceCream < 0 && intWholeMeas_IceCream == 0)
            {
                intFractionMeas_IceCream += 0;
                intFractionMeas_IceCream = 0;
                intWholeMeas_IceCream = 0;
            }

            txtCount1.Text = intWholeMeas_IceCream.ToString() + " " + intFractionMeas_IceCream.ToString() + "/4";
        }

        private void Add_Cookies(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Cookies += 1;

            if (intFractionMeas_Cookies == 4)
            {
                intFractionMeas_Cookies = 0;
                intWholeMeas_Cookies += 1;
            }

            txtCount2.Text = intWholeMeas_Cookies.ToString() + " " + intFractionMeas_Cookies.ToString() + "/4";
        }

        private void Remove_Cookies(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Cookies -= 1;

            if (intFractionMeas_Cookies < 0 && intWholeMeas_Cookies > 0)
            {
                intFractionMeas_Cookies = 3;
                intWholeMeas_Cookies -= 1;
            }

            if (intFractionMeas_Cookies < 0 && intWholeMeas_Cookies == 0)
            {
                intFractionMeas_Cookies += 0;
                intFractionMeas_Cookies = 0;
                intWholeMeas_Cookies = 0;
            }

            txtCount2.Text = intWholeMeas_Cookies.ToString() + " " + intFractionMeas_Cookies.ToString() + "/4";
        }


        private void AddIn_IceCream(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_IceCream == 2 && intFractionMeas_IceCream == 0)
            {
                IceCreamAdded = true;
                txtCount1.Text = "Added";
                txtCount1.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        private void AddIn_Cookies(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Cookies == 0 && intFractionMeas_Cookies == 3)
            {
                CookiesAdded = true;
                txtCount2.Text = "Added";
                txtCount2.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        private void ClickedMixed(object sender, RoutedEventArgs e)
        {
            txtInstructions.Text = "\nGreat! Now that all the ingredients are mixed together we can start baking. Click the 'next' button to see the final product!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;

            btnNext.Content = "Next";
            btnNext.FontSize = 38;

            imgIngredient1.Source = convertToBitmapSource("Done");
            imgIngredient2.Source = convertToBitmapSource("Done");

            imgBowl.Source = convertToBitmapSource("Done");


            ImageBrush blank = new ImageBrush();
            String blankID = "Done";
            blank.ImageSource = convertToBitmapSource(blankID);

            btnMix.Background = blank;
            btnMix.Content = "";

            btnAdd1.Background = blank;
            btnAdd2.Background = blank;

            btnSubtract1.Background = blank;
            btnSubtract2.Background = blank;

            btnPlus1.Background = blank;
            btnPlus2.Background = blank;

            txtCount1.Background = blank;
            txtCount2.Background = blank;

            btnAdd1.Content = "";
            btnAdd2.Content = "";

            btnSubtract1.Content = "";
            btnSubtract2.Content = "";

            btnPlus1.Content = "";
            btnPlus2.Content = "";

            txtCount1.Text = "";
            txtCount2.Text = "";

            if (done == true)
            {
                this.Close();
            }
        }

        private void NextEvent(object sender, RoutedEventArgs e)
        {
            txtInstructions.Text = "\nYay! You're all done!";
            imgBowl.Source = convertToBitmapSource("IceCreamPie");

            done = true;
            btnMix.Content = "Done";
        }
    }
}

