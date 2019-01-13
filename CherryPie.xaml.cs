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
    /// Interaction logic for CherryPie.xaml
    /// </summary>
    public partial class CherryPie : Window
    {

        int intWholeMeas_Sugar = 0;
        int intFractionMeas_Sugar = 0;
        int intWholeMeas_CornStarch = 0;
        int intFractionMeas_CornStarch = 0;
        int intWholeMeas_Cherries = 0;
        int intFractionMeas_Cherries = 0;
        int intWholeMeas_Vanilla = 0;
        int intFractionMeas_Vanilla = 0;


        Boolean SugarAdded = false;
        Boolean CornStarchAdded = false;
        Boolean CherriesAdded = false;
        Boolean VanillaAdded = false;

        Boolean done = false;


        public CherryPie()
        {
            InitializeComponent();

            txtInstructions.Text = "\n Get ready to start baking! Click on the book to \n check the recipe. Use the ''+'' and ''-'' buttons to \n add and subtract the amount that needs to be \n added. When the number matches the recipe click \n the ''Add In'' button to add it to the bowl! When \n you're all done click the ''Mix!'' button to move on!";

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Kitchen";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canCherryPie.Background = bkg;

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
            txtCount3.Background = bubble;
            txtCount8.Background = bubble;

            ImageBrush addblock = new ImageBrush();
            String addblockID = "Block4";
            addblock.ImageSource = convertToBitmapSource(addblockID);
            btnAdd1.Background = addblock;
            btnAdd2.Background = addblock;
            btnAdd3.Background = addblock;
            btnAdd8.Background = addblock;

            ImageBrush PandSBlock = new ImageBrush();
            String PandSBlockID = "Block5";
            PandSBlock.ImageSource = convertToBitmapSource(PandSBlockID);
            btnPlus1.Background = PandSBlock;
            btnSubtract1.Background = PandSBlock;
            btnPlus2.Background = PandSBlock;
            btnSubtract2.Background = PandSBlock;
            btnPlus3.Background = PandSBlock;
            btnSubtract3.Background = PandSBlock;
            btnPlus8.Background = PandSBlock;
            btnSubtract8.Background = PandSBlock;

            imgBowl.Source = convertToBitmapSource("EmptyBowl");

            imgIngredient1.Source = convertToBitmapSource("Sugar");
            imgIngredient2.Source = convertToBitmapSource("CornStarch");
            imgIngredient3.Source = convertToBitmapSource("Cherries");
            imgIngredient8.Source = convertToBitmapSource("Vanilla");
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
            CherryPieRecipe taskWindow = new CherryPieRecipe();
            taskWindow.Show();
        }



        private void Add_Sugar(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Sugar += 1;

            if (intFractionMeas_Sugar == 4)
            {
                intFractionMeas_Sugar = 0;
                intWholeMeas_Sugar += 1;
            }

            txtCount1.Text = intWholeMeas_Sugar.ToString() + " " + intFractionMeas_Sugar.ToString() + "/4";
        }

        private void Remove_Sugar(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Sugar -= 1;

            if (intFractionMeas_Sugar < 0 && intWholeMeas_Sugar > 0)
            {
                intFractionMeas_Sugar = 3;
                intWholeMeas_Sugar -= 1;
            }

            if (intFractionMeas_Sugar < 0 && intWholeMeas_Sugar == 0)
            {
                intFractionMeas_Sugar += 0;
                intFractionMeas_Sugar = 0;
                intWholeMeas_Sugar = 0;
            }

            txtCount1.Text = intWholeMeas_Sugar.ToString() + " " + intFractionMeas_Sugar.ToString() + "/4";
        }

        private void Add_CornStarch(object sender, RoutedEventArgs e)
        {
            intFractionMeas_CornStarch += 1;

            if (intFractionMeas_CornStarch == 4)
            {
                intFractionMeas_CornStarch = 0;
                intWholeMeas_CornStarch += 1;
            }

            txtCount2.Text = intWholeMeas_CornStarch.ToString() + " " + intFractionMeas_CornStarch.ToString() + "/4";
        }

        private void Remove_CornStarch(object sender, RoutedEventArgs e)
        {
            intFractionMeas_CornStarch -= 1;

            if (intFractionMeas_CornStarch < 0 && intWholeMeas_CornStarch > 0)
            {
                intFractionMeas_CornStarch = 3;
                intWholeMeas_CornStarch -= 1;
            }

            if (intFractionMeas_CornStarch < 0 && intWholeMeas_CornStarch == 0)
            {
                intFractionMeas_CornStarch += 0;
                intFractionMeas_CornStarch = 0;
                intWholeMeas_CornStarch = 0;
            }

            txtCount2.Text = intWholeMeas_CornStarch.ToString() + " " + intFractionMeas_CornStarch.ToString() + "/4";
        }

        private void Add_Cherries(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Cherries += 1;

            if (intFractionMeas_Cherries == 4)
            {
                intFractionMeas_Cherries = 0;
                intWholeMeas_Cherries += 1;
            }

            txtCount3.Text = intWholeMeas_Cherries.ToString() + " " + intFractionMeas_Cherries.ToString() + "/4";
        }

        private void Remove_Cherries(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Cherries -= 1;

            if (intFractionMeas_Cherries < 0 && intWholeMeas_Cherries > 0)
            {
                intFractionMeas_Cherries = 3;
                intWholeMeas_Cherries -= 1;
            }

            if (intFractionMeas_Cherries < 0 && intWholeMeas_Cherries == 0)
            {
                intFractionMeas_Cherries += 0;
                intFractionMeas_Cherries = 0;
                intWholeMeas_Cherries = 0;
            }

            txtCount3.Text = intWholeMeas_Cherries.ToString() + " " + intFractionMeas_Cherries.ToString() + "/4";
        }

        private void Add_Vanilla(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Vanilla += 1;

            if (intFractionMeas_Vanilla == 4)
            {
                intFractionMeas_Vanilla = 0;
                intWholeMeas_Vanilla += 1;
            }

            txtCount8.Text = intWholeMeas_Vanilla.ToString() + " " + intFractionMeas_Vanilla.ToString() + "/4";
        }

        private void Remove_Vanilla(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Vanilla -= 1;

            if (intFractionMeas_Vanilla < 0 && intWholeMeas_Vanilla > 0)
            {
                intFractionMeas_Vanilla = 3;
                intWholeMeas_Vanilla -= 1;
            }

            if (intFractionMeas_Vanilla < 0 && intWholeMeas_Vanilla == 0)
            {
                intFractionMeas_Vanilla += 0;
                intFractionMeas_Vanilla = 0;
                intWholeMeas_Vanilla = 0;
            }

            txtCount8.Text = intWholeMeas_Vanilla.ToString() + " " + intFractionMeas_Vanilla.ToString() + "/4";
        }


        private void AddIn_Sugar(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Sugar == 1 && intFractionMeas_Sugar == 2)
            {
                SugarAdded = true;
                txtCount1.Text = "Added";
                txtCount1.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        private void AddIn_CornStarch(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_CornStarch == 4 && intFractionMeas_CornStarch == 0)
            {
                CornStarchAdded = true;
                txtCount2.Text = "Added";
                txtCount2.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        private void AddIn_Cherries(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Cherries == 4 && intFractionMeas_Cherries == 0)
            {
                CherriesAdded = true;
                txtCount3.Text = "Added";
                txtCount3.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        
        private void AddIn_Vanilla(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Vanilla == 0 && intFractionMeas_Vanilla == 1)
            {
                VanillaAdded = true;
                txtCount8.Text = "Added";
                txtCount8.FontSize = 20;
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
            imgIngredient3.Source = convertToBitmapSource("Done");
            imgIngredient8.Source = convertToBitmapSource("Done");

            imgBowl.Source = convertToBitmapSource("Done");


            ImageBrush blank = new ImageBrush();
            String blankID = "Done";
            blank.ImageSource = convertToBitmapSource(blankID);

            btnMix.Background = blank;
            btnMix.Content = "";

            btnAdd1.Background = blank;
            btnAdd2.Background = blank;
            btnAdd3.Background = blank;
            btnAdd8.Background = blank;

            btnSubtract1.Background = blank;
            btnSubtract2.Background = blank;
            btnSubtract3.Background = blank;
            btnSubtract8.Background = blank;

            btnPlus1.Background = blank;
            btnPlus2.Background = blank;
            btnPlus3.Background = blank;
            btnPlus8.Background = blank;

            txtCount1.Background = blank;
            txtCount2.Background = blank;
            txtCount3.Background = blank;
            txtCount8.Background = blank;

            btnAdd1.Content = "";
            btnAdd2.Content = "";
            btnAdd3.Content = "";
            btnAdd8.Content = "";

            btnSubtract1.Content = "";
            btnSubtract2.Content = "";
            btnSubtract3.Content = "";
            btnSubtract8.Content = "";

            btnPlus1.Content = "";
            btnPlus2.Content = "";
            btnPlus3.Content = "";
            btnPlus8.Content = "";

            txtCount1.Text = "";
            txtCount2.Text = "";
            txtCount3.Text = "";
            txtCount8.Text = "";

            if (done == true)
            {
                this.Close();
            }
        }

        private void NextEvent(object sender, RoutedEventArgs e)
        {
            txtInstructions.Text = "\nYay! You're all done!";
            imgBowl.Source = convertToBitmapSource("CherryPie");

            done = true;
            btnMix.Content = "Done";
        }
    }
}

