﻿using System;
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
    /// Interaction logic for Snickerdoodle.xaml
    /// </summary>
    public partial class Snickerdoodle : Window
    {

        int intWholeMeas_Sugar = 0;
        int intFractionMeas_Sugar = 0;
        int intWholeMeas_Flour = 0;
        int intFractionMeas_Flour = 0;
        int intWholeMeas_Butter = 0;
        int intFractionMeas_Butter = 0;
        int intWholeMeas_Eggs = 0;
        int intWholeMeas_Salt = 0;
        int intFractionMeas_Salt = 0;
        int intWholeMeas_Cinnamon = 0;
        int intFractionMeas_Cinnamon = 0;
        int intWholeMeas_Vanilla = 0;
        int intFractionMeas_Vanilla = 0;


        Boolean SugarAdded = false;
        Boolean FlourAdded = false;
        Boolean ButterAdded = false;
        Boolean EggsAdded = false;
        Boolean SaltAdded = false;
        Boolean CinnamonAdded = false;
        Boolean VanillaAdded = false;

        Boolean done = false;

        public Snickerdoodle()
        {
            InitializeComponent();

            txtInstructions.Text = "\n Get ready to start baking! Click on the book to \n check the recipe. Use the ''+'' and ''-'' buttons to \n add and subtract the amount that needs to be \n added. When the number matches the recipe click \n the ''Add In'' button to add it to the bowl! When \n you're all done click the ''Mix!'' button to move on!";

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Kitchen";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canCake.Background = bkg;

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
            txtCount5.Background = bubble;
            txtCount6.Background = bubble;
            txtCount7.Background = bubble;
            txtCount8.Background = bubble;

            ImageBrush addblock = new ImageBrush();
            String addblockID = "Block4";
            addblock.ImageSource = convertToBitmapSource(addblockID);
            btnAdd1.Background = addblock;
            btnAdd2.Background = addblock;
            btnAdd3.Background = addblock;
            btnAdd5.Background = addblock;
            btnAdd6.Background = addblock;
            btnAdd7.Background = addblock;
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
            btnPlus5.Background = PandSBlock;
            btnSubtract5.Background = PandSBlock;
            btnPlus6.Background = PandSBlock;
            btnSubtract6.Background = PandSBlock;
            btnPlus7.Background = PandSBlock;
            btnSubtract7.Background = PandSBlock;
            btnPlus8.Background = PandSBlock;
            btnSubtract8.Background = PandSBlock;

            imgBowl.Source = convertToBitmapSource("EmptyBowl");

            imgIngredient1.Source = convertToBitmapSource("Sugar");
            imgIngredient2.Source = convertToBitmapSource("Flour");
            imgIngredient3.Source = convertToBitmapSource("Butter");
            imgIngredient5.Source = convertToBitmapSource("Eggs");
            imgIngredient6.Source = convertToBitmapSource("Salt");
            imgIngredient7.Source = convertToBitmapSource("Cinnamon");
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
            SnickerdoodleRecipe taskWindow = new SnickerdoodleRecipe();
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

        private void Add_Flour(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Flour += 1;

            if (intFractionMeas_Flour == 4)
            {
                intFractionMeas_Flour = 0;
                intWholeMeas_Flour += 1;
            }

            txtCount2.Text = intWholeMeas_Flour.ToString() + " " + intFractionMeas_Flour.ToString() + "/4";
        }

        private void Remove_Flour(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Flour -= 1;

            if (intFractionMeas_Flour < 0 && intWholeMeas_Flour > 0)
            {
                intFractionMeas_Flour = 3;
                intWholeMeas_Flour -= 1;
            }

            if (intFractionMeas_Flour < 0 && intWholeMeas_Flour == 0)
            {
                intFractionMeas_Flour += 0;
                intFractionMeas_Flour = 0;
                intWholeMeas_Flour = 0;
            }

            txtCount2.Text = intWholeMeas_Flour.ToString() + " " + intFractionMeas_Flour.ToString() + "/4";
        }

        private void Add_Butter(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Butter += 1;

            if (intFractionMeas_Butter == 4)
            {
                intFractionMeas_Butter = 0;
                intWholeMeas_Butter += 1;
            }

            txtCount3.Text = intWholeMeas_Butter.ToString() + " " + intFractionMeas_Butter.ToString() + "/4";
        }

        private void Remove_Butter(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Butter -= 1;

            if (intFractionMeas_Butter < 0 && intWholeMeas_Butter > 0)
            {
                intFractionMeas_Butter = 3;
                intWholeMeas_Butter -= 1;
            }

            if (intFractionMeas_Butter < 0 && intWholeMeas_Butter == 0)
            {
                intFractionMeas_Butter += 0;
                intFractionMeas_Butter = 0;
                intWholeMeas_Butter = 0;
            }

            txtCount3.Text = intWholeMeas_Butter.ToString() + " " + intFractionMeas_Butter.ToString() + "/4";
        }

        private void Add_Eggs(object sender, RoutedEventArgs e)
        {
            intWholeMeas_Eggs += 1;

            txtCount5.Text = intWholeMeas_Eggs.ToString();
        }

        private void Remove_Eggs(object sender, RoutedEventArgs e)
        {
            intWholeMeas_Eggs -= 1;
            if (intWholeMeas_Eggs < 0)
            {
                intWholeMeas_Eggs = 0;
            }

            txtCount5.Text = intWholeMeas_Eggs.ToString();
        }

        private void Add_Salt(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Salt += 1;

            if (intFractionMeas_Salt == 4)
            {
                intFractionMeas_Salt = 0;
                intWholeMeas_Salt += 1;
            }

            txtCount6.Text = intWholeMeas_Salt.ToString() + " " + intFractionMeas_Salt.ToString() + "/4";
        }

        private void Remove_Salt(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Salt -= 1;

            if (intFractionMeas_Salt < 0 && intWholeMeas_Salt > 0)
            {
                intFractionMeas_Salt = 3;
                intWholeMeas_Salt -= 1;
            }

            if (intFractionMeas_Salt < 0 && intWholeMeas_Salt == 0)
            {
                intFractionMeas_Salt += 0;
                intFractionMeas_Salt = 0;
                intWholeMeas_Salt = 0;
            }

            txtCount6.Text = intWholeMeas_Salt.ToString() + " " + intFractionMeas_Salt.ToString() + "/4";
        }

        private void Add_Cinnamon(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Cinnamon += 1;

            if (intFractionMeas_Cinnamon == 4)
            {
                intFractionMeas_Cinnamon = 0;
                intWholeMeas_Cinnamon += 1;
            }

            txtCount7.Text = intWholeMeas_Cinnamon.ToString() + " " + intFractionMeas_Cinnamon.ToString() + "/4";
        }

        private void Remove_Cinnamon(object sender, RoutedEventArgs e)
        {
            intFractionMeas_Cinnamon -= 1;

            if (intFractionMeas_Cinnamon < 0 && intWholeMeas_Cinnamon > 0)
            {
                intFractionMeas_Cinnamon = 3;
                intWholeMeas_Cinnamon -= 1;
            }

            if (intFractionMeas_Cinnamon < 0 && intWholeMeas_Cinnamon == 0)
            {
                intFractionMeas_Cinnamon += 0;
                intFractionMeas_Cinnamon = 0;
                intWholeMeas_Cinnamon = 0;
            }

            txtCount7.Text = intWholeMeas_Cinnamon.ToString() + " " + intFractionMeas_Cinnamon.ToString() + "/4";
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
            if (intWholeMeas_Sugar == 2 && intFractionMeas_Sugar == 0)
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

        private void AddIn_Flour(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Flour == 2 && intFractionMeas_Flour == 3)
            {
                FlourAdded = true;
                txtCount2.Text = "Added";
                txtCount2.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        private void AddIn_Butter(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Butter == 2 && intFractionMeas_Butter == 0)
            {
                ButterAdded = true;
                txtCount3.Text = "Added";
                txtCount3.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }


        private void AddIn_Eggs(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Eggs == 2)
            {
                EggsAdded = true;
                txtCount5.Text = "Added";
                txtCount5.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        private void AddIn_Salt(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Salt == 1 && intFractionMeas_Salt == 0)
            {
                SaltAdded = true;
                txtCount6.Text = "Added";
                txtCount6.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        private void AddIn_Cinnamon(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Cinnamon == 2 && intFractionMeas_Cinnamon == 0)
            {
                CinnamonAdded = true;
                txtCount7.Text = "Added";
                txtCount7.FontSize = 20;
            }
            else
            {
                MessageBox.Show("Oops! It looks like your measurements aren't correct! Go back and fix them before adding to the bowl!");
            }
        }

        private void AddIn_Vanilla(object sender, RoutedEventArgs e)
        {
            if (intWholeMeas_Vanilla == 2 && intFractionMeas_Vanilla == 0)
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
            imgIngredient5.Source = convertToBitmapSource("Done");
            imgIngredient6.Source = convertToBitmapSource("Done");
            imgIngredient7.Source = convertToBitmapSource("Done");
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
            btnAdd5.Background = blank;
            btnAdd6.Background = blank;
            btnAdd7.Background = blank;
            btnAdd8.Background = blank;

            btnSubtract1.Background = blank;
            btnSubtract2.Background = blank;
            btnSubtract3.Background = blank;
            btnSubtract5.Background = blank;
            btnSubtract6.Background = blank;
            btnSubtract7.Background = blank;
            btnSubtract8.Background = blank;

            btnPlus1.Background = blank;
            btnPlus2.Background = blank;
            btnPlus3.Background = blank;
            btnPlus5.Background = blank;
            btnPlus6.Background = blank;
            btnPlus7.Background = blank;
            btnPlus8.Background = blank;

            txtCount1.Background = blank;
            txtCount2.Background = blank;
            txtCount3.Background = blank;
            txtCount5.Background = blank;
            txtCount6.Background = blank;
            txtCount7.Background = blank;
            txtCount8.Background = blank;

            btnAdd1.Content = "";
            btnAdd2.Content = "";
            btnAdd3.Content = "";
            btnAdd5.Content = "";
            btnAdd6.Content = "";
            btnAdd7.Content = "";
            btnAdd8.Content = "";

            btnSubtract1.Content = "";
            btnSubtract2.Content = "";
            btnSubtract3.Content = "";
            btnSubtract5.Content = "";
            btnSubtract6.Content = "";
            btnSubtract7.Content = "";
            btnSubtract8.Content = "";

            btnPlus1.Content = "";
            btnPlus2.Content = "";
            btnPlus3.Content = "";
            btnPlus5.Content = "";
            btnPlus6.Content = "";
            btnPlus7.Content = "";
            btnPlus8.Content = "";

            txtCount1.Text = "";
            txtCount2.Text = "";
            txtCount3.Text = "";
            txtCount5.Text = "";
            txtCount6.Text = "";
            txtCount7.Text = "";
            txtCount8.Text = "";

            if (done == true)
            {
                this.Close();
            }
        }

        private void NextEvent(object sender, RoutedEventArgs e)
        {
            txtInstructions.Text = "\nYay! You're all done!";
            imgBowl.Source = convertToBitmapSource("SDCookies");

            done = true;
            btnMix.Content = "Done";
        }
    }
}



