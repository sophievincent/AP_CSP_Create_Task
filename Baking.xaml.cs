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
    /// Interaction logic for Baking.xaml
    /// </summary>
    public partial class Baking : Window
    {

        Boolean CCakeChoosen = false;
        Boolean VCakeChoosen = false;
        Boolean RVCakeChoosen = false;
        Boolean BCakeChoosen = false;
        
        Boolean CherryPieChoosen = false;
        Boolean APieChoosen = false;
        Boolean ChPieChoosen = false;
        Boolean ICPieChoosen = false;
        
        Boolean CCCookiesChoosen = false;
        Boolean SDCookiesChoosen = false;
        Boolean SCookiesChoosen = false;
        Boolean CCCCookiesChoosen = false;
        
        Boolean CCupcakesChoosen = false;
        Boolean VCupcakesChoosen = false;
        Boolean RVCupcakesChoosen = false;
        Boolean BCCupcakesChoosen = false;
        
        int x;
        int y;
        int index = 0;
        int indexCake = 0;
        int indexCupCake = 0;
        int indexCookies = 0;
        int indexPie = 0;

        String[] OpeningContent = new String[]
        {
            "Cake",
            "Cup Cakes",
            "Cookies",
            "Pie"
        };

        String[] WhatFoodChosenContent = new String[]
        {
            "\n     You've chosen cake! What kind do you want to make?",
            "\n     You've chosen cup cakes! What kind do you want to make?",
            "\n     You've chosen cookies! What kind do you want to make?",
            "\n     You've chosen pie! What kind do you want to make?"
        };


        String[] CakeChoosenContent = new String[]
        {
            "Chocolate\nCake",
            "Vanilla\nCake",
            "Red Velvet\nCake",
            "Birthday\nCake"
        };


        String[] CupCakeChoosenContent = new String[]
        {
            "Chocolate\nCupcakes",
            "Vanilla\nCupcakes",
            "Red Velvet\nCupcakes",
            "Birthday Cake\nCupcakes"
        };


        String[] CookiesChoosenContent = new String[]
        {
            "Chocolate\nChip\nCookies",
            "Snicker\nDoodle\nCookies",
            "Sugar\nCookies",
            "Chocolate \nChocolate\nChip Cookies"
        };


        String[] PieChoosenContent = new String[]
        {
            "Cherry \nPie",
            "Apple \nPie",
            "Chocolate \nPie",
            "Ice Cream \nPie"
        };

        

        public Baking()
        {
            InitializeComponent();

            CreateGrid1(2, 2);
            CreateGridCake(2, 2);
            CreateGridCupCake(2, 2);
            CreateGridCookies(2, 2);
            CreateGridPie(2, 2);

            canBaking.Children.Remove(grdCakeGrid);
            canBaking.Children.Remove(grdCupCakeGrid);
            canBaking.Children.Remove(grdCookiesGrid);
            canBaking.Children.Remove(grdPieGrid);

            ImageBrush bkg = new ImageBrush();
            String bkgID = "Kitchen";
            bkg.ImageSource = convertToBitmapSource(bkgID);
            canBaking.Background = bkg;

            ImageBrush inst = new ImageBrush();
            String instID = "Block1";
            inst.ImageSource = convertToBitmapSource(instID);
            txtInstructions.Background = inst;

            ImageBrush select = new ImageBrush();
            String selectID = "BlockSelect";
            select.ImageSource = convertToBitmapSource(selectID);

            


            btnNext.Content = "Next";
            btnNext.FontFamily = new FontFamily("LetterOMatic!");
            btnNext.FontSize = 48;
            btnNext.Opacity = 0;

            //txtTextBlock.Text = "this is a line \nthis is a line";
            txtInstructions.FontFamily = new FontFamily("LetterOMatic!");
            txtInstructions.FontSize = 28;
            txtInstructions.Text = "\n     Choose what type of dessert you want to make!";

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

        public void CreateGrid1(int rows, int columns)
        {
            Grid FirstGrid = new Grid();
            for (int i = 0; i < rows; i++)
            {
                FirstGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < columns; i++)
            {
                FirstGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (x = 0; x < rows; x++)
            {
                for (y = 0; y < columns; y++)
                {
                    Button btn1 = new Button();
                    btn1.Height = grdMainGrid.Height / rows - 10;
                    btn1.Width = grdMainGrid.Width / columns - 10;
                    btn1.FontFamily = new FontFamily("LetterOMatic!");
                    btn1.FontSize = 52;
                    btn1.BorderThickness = new Thickness(0.0);
                    ImageBrush csfood = new ImageBrush();
                    String csfoodID = "Block4";
                    csfood.ImageSource = convertToBitmapSource(csfoodID);
                    btn1.Background = csfood;
                    btn1.Content = OpeningContent[index];
                    

                    if (index == 0)
                    {
                        btn1.Click += Btn0_Click;
                        
                    }
                    if (index == 1)
                    {
                        btn1.Click += Btn1_Click;
                    }
                    if (index == 2)
                    {
                        btn1.Click += Btn2_Click;
                    }
                    if (index == 3)
                    {
                        btn1.Click += Btn3_Click;
                    }

                    index += 1;
                    Grid.SetColumn(btn1, y);
                    Grid.SetRow(btn1, x);
                    FirstGrid.Children.Add(btn1);
                }

            }

            grdMainGrid.Children.Add(FirstGrid);
        }

        public void CreateGridCake(int rows, int columns)
        {
            Grid CakeGrid = new Grid();
            for (int i = 0; i < rows; i++)
            {
                CakeGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < columns; i++)
            {
                CakeGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (x = 0; x < rows; x++)
            {
                for (y = 0; y < columns; y++)
                {
                    Button btnCake = new Button();
                    btnCake.Height = grdMainGrid.Height / rows - 10;
                    btnCake.Width = grdMainGrid.Width / columns - 10;
                    btnCake.FontFamily = new FontFamily("LetterOMatic!");
                    btnCake.FontSize = 52;
                    btnCake.BorderThickness = new Thickness(0.0);
                    ImageBrush csfood = new ImageBrush();
                    String csfoodID = "Block4";
                    csfood.ImageSource = convertToBitmapSource(csfoodID);
                    btnCake.Background = csfood;
                    btnCake.Content = CakeChoosenContent[indexCake];


                    if (indexCake == 0)
                    {
                        btnCake.Click += CakeBtn0_Click;

                    }
                    if (indexCake == 1)
                    {
                        btnCake.Click += CakeBtn1_Click;
                    }
                    if (indexCake == 2)
                    {
                        btnCake.Click += CakeBtn2_Click;
                    }
                    if (indexCake == 3)
                    {
                        btnCake.Click += CakeBtn3_Click;
                    }

                    indexCake += 1;
                    Grid.SetColumn(btnCake, y);
                    Grid.SetRow(btnCake, x);
                    CakeGrid.Children.Add(btnCake);
                }

            }
            grdCakeGrid.Children.Add(CakeGrid);
        }

        public void CreateGridCupCake(int rows, int columns)
        {
            Grid CupCakeGrid = new Grid();
            for (int i = 0; i < rows; i++)
            {
                CupCakeGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < columns; i++)
            {
                CupCakeGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (x = 0; x < rows; x++)
            {
                for (y = 0; y < columns; y++)
                {
                    Button btnCupCake = new Button();
                    btnCupCake.Height = grdMainGrid.Height / rows - 10;
                    btnCupCake.Width = grdMainGrid.Width / columns - 10;
                    btnCupCake.FontFamily = new FontFamily("LetterOMatic!");
                    btnCupCake.FontSize = 52;
                    btnCupCake.BorderThickness = new Thickness(0.0);
                    ImageBrush csfood = new ImageBrush();
                    String csfoodID = "Block4";
                    csfood.ImageSource = convertToBitmapSource(csfoodID);
                    btnCupCake.Background = csfood;
                    btnCupCake.Content = CupCakeChoosenContent[indexCupCake];


                    if (indexCupCake == 0)
                    {
                        btnCupCake.Click += CupCakeBtn0_Click;

                    }
                    if (indexCupCake == 1)
                    {
                        btnCupCake.Click += CupCakeBtn1_Click;
                    }
                    if (indexCupCake == 2)
                    {
                        btnCupCake.Click += CupCakeBtn2_Click;
                    }
                    if (indexCupCake == 3)
                    {
                        btnCupCake.Click += CupCakeBtn3_Click;
                    }

                    indexCupCake += 1;
                    Grid.SetColumn(btnCupCake, y);
                    Grid.SetRow(btnCupCake, x);
                    CupCakeGrid.Children.Add(btnCupCake);
                }

            }
            grdCupCakeGrid.Children.Add(CupCakeGrid);
        }

        public void CreateGridCookies(int rows, int columns)
        {
            Grid CookiesGrid = new Grid();
            for (int i = 0; i < rows; i++)
            {
                CookiesGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < columns; i++)
            {
                CookiesGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (x = 0; x < rows; x++)
            {
                for (y = 0; y < columns; y++)
                {
                    Button btnCookies = new Button();
                    btnCookies.Height = grdMainGrid.Height / rows - 10;
                    btnCookies.Width = grdMainGrid.Width / columns - 10;
                    btnCookies.FontFamily = new FontFamily("LetterOMatic!");
                    btnCookies.FontSize = 52;
                    btnCookies.BorderThickness = new Thickness(0.0);
                    ImageBrush csfood = new ImageBrush();
                    String csfoodID = "Block4";
                    csfood.ImageSource = convertToBitmapSource(csfoodID);
                    btnCookies.Background = csfood;
                    btnCookies.Content = CookiesChoosenContent[indexCookies];


                    if (indexCookies == 0)
                    {
                        btnCookies.Click += CookiesBtn0_Click;

                    }
                    if (indexCookies == 1)
                    {
                        btnCookies.Click += CookiesBtn1_Click;
                    }
                    if (indexCookies == 2)
                    {
                        btnCookies.Click += CookiesBtn2_Click;
                    }
                    if (indexCookies == 3)
                    {
                        btnCookies.Click += CookiesBtn3_Click;
                    }

                    indexCookies += 1;
                    Grid.SetColumn(btnCookies, y);
                    Grid.SetRow(btnCookies, x);
                    CookiesGrid.Children.Add(btnCookies);
                }

            }
            grdCookiesGrid.Children.Add(CookiesGrid);
        }

        public void CreateGridPie(int rows, int columns)
        {
            Grid PieGrid = new Grid();
            for (int i = 0; i < rows; i++)
            {
                PieGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < columns; i++)
            {
                PieGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (x = 0; x < rows; x++)
            {
                for (y = 0; y < columns; y++)
                {
                    Button btnPie = new Button();
                    btnPie.Height = grdMainGrid.Height / rows - 10;
                    btnPie.Width = grdMainGrid.Width / columns - 10;
                    btnPie.FontFamily = new FontFamily("LetterOMatic!");
                    btnPie.FontSize = 52;
                    btnPie.BorderThickness = new Thickness(0.0);
                    ImageBrush csfood = new ImageBrush();
                    String csfoodID = "Block4";
                    csfood.ImageSource = convertToBitmapSource(csfoodID);
                    btnPie.Background = csfood;
                    btnPie.Content = PieChoosenContent[indexPie];


                    if (indexPie == 0)
                    {
                        btnPie.Click += PieBtn0_Click;

                    }
                    if (indexPie == 1)
                    {
                        btnPie.Click += PieBtn1_Click;
                    }
                    if (indexPie == 2)
                    {
                        btnPie.Click += PieBtn2_Click;
                    }
                    if (indexPie == 3)
                    {
                        btnPie.Click += PieBtn3_Click;
                    }

                    indexPie += 1;
                    Grid.SetColumn(btnPie, y);
                    Grid.SetRow(btnPie, x);
                    PieGrid.Children.Add(btnPie);
                }

            }
            grdPieGrid.Children.Add(PieGrid);
        }


        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            txtInstructions.Text = WhatFoodChosenContent[0];
            canBaking.Children.Remove(grdMainGrid);
            canBaking.Children.Add(grdCakeGrid);
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            txtInstructions.Text = WhatFoodChosenContent[1];
            canBaking.Children.Remove(grdMainGrid);
            canBaking.Children.Add(grdCupCakeGrid);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            txtInstructions.Text = WhatFoodChosenContent[2];
            canBaking.Children.Remove(grdMainGrid);
            canBaking.Children.Add(grdCookiesGrid);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            txtInstructions.Text = WhatFoodChosenContent[3];
            canBaking.Children.Remove(grdMainGrid);
            canBaking.Children.Add(grdPieGrid);
        }


        private void CakeBtn0_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCakeGrid);
            CCakeChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CakeBtn1_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCakeGrid);
            VCakeChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CakeBtn2_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCakeGrid);
            RVCakeChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CakeBtn3_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCakeGrid);
            BCakeChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }


        private void CupCakeBtn0_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCupCakeGrid);
            CCupcakesChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CupCakeBtn1_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCupCakeGrid);
            VCupcakesChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CupCakeBtn2_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCupCakeGrid);
            RVCupcakesChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CupCakeBtn3_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCupCakeGrid);
            BCCupcakesChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }


        private void CookiesBtn0_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCookiesGrid);
            CCCookiesChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CookiesBtn1_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCookiesGrid);
            SDCookiesChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CookiesBtn2_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCookiesGrid);
            SCookiesChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void CookiesBtn3_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdCookiesGrid);
            CCCCookiesChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }


        private void PieBtn0_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdPieGrid);
            CherryPieChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void PieBtn1_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdPieGrid);
            APieChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void PieBtn2_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdPieGrid);
            ChPieChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void PieBtn3_Click(object sender, RoutedEventArgs e)
        {
            canBaking.Children.Remove(grdPieGrid);
            ICPieChoosen = true;

            txtInstructions.Text = "\n     Great! Click the 'Next' Button to get started!";

            ImageBrush next = new ImageBrush();
            String nextID = "Block2";
            next.ImageSource = convertToBitmapSource(nextID);
            btnNext.Opacity = 100;
            btnNext.Background = next;
        }

        private void ClickedNext(object sender, RoutedEventArgs e)
        {
            if (CCakeChoosen == true)
            {
                Cake taskWindow = new Cake();
                taskWindow.Show();
                this.Close();
            }
            if (VCakeChoosen == true)
            {
                VanillaCake taskWindow = new VanillaCake();
                taskWindow.Show();
                this.Close();
            }
            if (RVCakeChoosen == true)
            {
                RVCake taskWindow = new RVCake();
                taskWindow.Show();
                this.Close();
            }
            if (BCakeChoosen == true)
            {
                BirthdayCake taskWindow = new BirthdayCake();
                taskWindow.Show();
                this.Close();
            }


            if (CherryPieChoosen == true)
            {
                CherryPie taskWindow = new CherryPie();
                taskWindow.Show();
                this.Close();
            }
            if (APieChoosen == true)
            {
                ApplePie taskWindow = new ApplePie();
                taskWindow.Show();
                this.Close();
            }
            if (ChPieChoosen == true)
            {
                ChocolatePie taskWindow = new ChocolatePie();
                taskWindow.Show();
                this.Close();
            }
            if (ICPieChoosen == true)
            {
                IceCreamPie taskWindow = new IceCreamPie();
                taskWindow.Show();
                this.Close();
            }


            if (CCCookiesChoosen == true)
            {
                ChocolateChipCookies taskWindow = new ChocolateChipCookies();
                taskWindow.Show();
                this.Close();
            }
            if (SDCookiesChoosen == true)
            {
                Snickerdoodle taskWindow = new Snickerdoodle();
                taskWindow.Show();
                this.Close();
            }
            if (SCookiesChoosen == true)
            {
                SugarCookies taskWindow = new SugarCookies();
                taskWindow.Show();
                this.Close();
            }
            if (CCCCookiesChoosen == true)
            {
                CCChipCookies taskWindow = new CCChipCookies();
                taskWindow.Show();
                this.Close();
            }


            if (CCupcakesChoosen == true)
            {
                CCupCake taskWindow = new CCupCake();
                taskWindow.Show();
                this.Close();
            }
            if (VCupcakesChoosen == true)
            {
                VCupCake taskWindow = new VCupCake();
                taskWindow.Show();
                this.Close();
            }
            if (RVCupcakesChoosen == true)
            {
                RVCupCake taskWindow = new RVCupCake();
                taskWindow.Show();
                this.Close();
            }
            if (BCCupcakesChoosen == true)
            {
                BCCupCake taskWindow = new BCCupCake();
                taskWindow.Show();
                this.Close();
            }
        }
    }
}
