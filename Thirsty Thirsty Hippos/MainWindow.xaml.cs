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
using System.Windows.Threading;
using System.Timers;
using System.Windows.Media.Animation;

namespace Thirsty_Thirsty_Hippos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static System.Timers.Timer aTimer;
        bool isLeftPressed, isRightPressed;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();


        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(
                () =>
                {

                    if (isLeftPressed)
                    {
                        //txtkey.Text = "INVOKE LEFT";
                        ////this.image.Margin = new Thickness(image.Margin.Left + 5, image.Margin.Top, image.Margin.Right - 5, image.Margin.Bottom);

                        //var img = new Image();
                        //img.Width = 100;
                        //img.Height = 100;
                        //BitmapImage bi3 = new BitmapImage();
                        //bi3.BeginInit();
                        //bi3.UriSource = new Uri("images/sagres.png", UriKind.Relative);
                        //bi3.EndInit();
                        //img.Source = bi3;
                        ////img.Source = "images/sagres.png".ToString();
                        //theGrid.Children.Add(img);


                    }
                }
            );
        }


        //private void OnKeyDownHandler(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        textBlock1.Text = "You Entered: " + textBox1.Text;
        //        //textBox1.Text = "You Entered: " + textBox1.Text;
        //    }
        //}

        private void image_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Left)
            {
                //Keyboard.IsKeyDown(Key.A)
                isLeftPressed = true;
                //this.txtkey.Text = "LEFT LEFT";
                txtkey.Text = "LEFT:" + isLeftPressed.ToString();
                txtcoord.Text = image.Margin.Left.ToString() +", "+ image.Margin.Top.ToString() + ", " + image.Margin.Right.ToString() + ", " + image.Margin.Bottom.ToString();
                if (image.Margin.Left > 1) {
                    image.Margin = new Thickness(image.Margin.Left - 5, image.Margin.Top, image.Margin.Right + 5, image.Margin.Bottom);
                }
                


            }

            if (e.Key == Key.Right)
            {
                isRightPressed = true;
                txtkey.Text = "RIGHT:" + isRightPressed.ToString();
                txtcoord.Text = image.Margin.Left.ToString() + ", " + image.Margin.Top.ToString() + ", " + image.Margin.Right.ToString() + ", " + image.Margin.Bottom.ToString();
                if (image.Margin.Right > -325)
                {
                    image.Margin = new Thickness(image.Margin.Left + 5, image.Margin.Top, image.Margin.Right - 5, image.Margin.Bottom);
                }

            }

        }


        private void image_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                isLeftPressed = false;
                txtkey.Text = "LEFT:" + isLeftPressed.ToString();
            }

            if (e.Key == Key.Right)
            {
                isRightPressed = false;
                txtkey.Text = "RIGHT:" + isRightPressed.ToString();
            }


        }

        
        //Resolução do FOCUS na GRID.
        private void theGrid_Loaded(object sender, RoutedEventArgs e)
        {
            theGrid.Focus();




            //Animação cerveja
            //ThicknessAnimation thicknessanimation = new ThicknessAnimation();


            //thicknessanimation.From = new Thickness(0, 10, 683, 461);
            //thicknessanimation.To = new Thickness(300, 300, this.Margin.Right, this.Margin.Bottom);
            //thicknessanimation.Duration = TimeSpan.FromSeconds(1);

          

            //sagres1.BeginAnimation(MarginProperty, thicknessanimation);

            //Completed não funciona ):

            //HandoffBehavior handoffBehavior = new HandoffBehavior();
            //sagres1.ManipulationCompleted += Sagres1_ManipulationCompleted;

            CervejaAnimation teste = new CervejaAnimation();
            teste.ThicknessAnimationExample();
            
        }

        

        private void Sagres1_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            txtmov.Text = "ANIMATION COMPLETED";
        }


        public class CervejaAnimation : Page
        {
            public void ThicknessAnimationExample()
            {

                // TESTE COM STORYBOARD ----------------------------------------------------------

                //Namescope para esta página
                NameScope.SetNameScope(this, new NameScope());

                //Criar a imagem
                Image sagrespt = new Image();

                sagrespt.Width = 100;
                sagrespt.Height = 100;
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("images/sagres.png", UriKind.Relative);
                bi3.EndInit();
                sagrespt.Source = bi3;

                this.RegisterName("imgAnimated", sagrespt);

                //Definição da animação 
                ThicknessAnimation thicknessanimation = new ThicknessAnimation();


                thicknessanimation.From = new Thickness(0, 10, 683, 461);
                thicknessanimation.To = new Thickness(300, 300, this.Margin.Right, this.Margin.Bottom);
                thicknessanimation.Duration = TimeSpan.FromSeconds(1);


                //Atribuir a animação
                Storyboard.SetTargetName(thicknessanimation, "imgAnimated");
                Storyboard.SetTargetProperty(thicknessanimation, new PropertyPath(MarginProperty));

                //Criação da storyboard
                Storyboard moveCerveja = new Storyboard();
                moveCerveja.Children.Add(thicknessanimation);

                sagrespt.Loaded += delegate (object sender, RoutedEventArgs e)
                {
                    moveCerveja.Begin(this);
                };

                StackPanel myStackPanel = new StackPanel();
                myStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
                myStackPanel.Children.Add(sagrespt);

                Content = myStackPanel;

            }


        }







    } //mainwidow
} //namespace
