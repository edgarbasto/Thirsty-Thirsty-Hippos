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
            dispatcherTimer.Interval = new TimeSpan(0,0,6);
            dispatcherTimer.Start();


            //ticker do jogo
            DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0,0,0,0,10);
            gameTimer.Start();




        }

        

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            
            Image[] cervejas = new Image[5] { sagres0, sagres1, sagres2, sagres3, sagres4 };

            for (int i=0; i< 5; i++)
            {

            
                if (image.Margin.Top > cervejas[i].Margin.Top - 50  && image.Margin.Top < cervejas[i].Margin.Top + 50 )
                {
                    if (image.Margin.Left > cervejas[i].Margin.Left - 50 && image.Margin.Left < cervejas[i].Margin.Left + 50)
                    {
                        theGrid.Children.Remove(cervejas[i]);
                        txtcolision.Text = "COLISION DETECTED";
                    }
                }
            }



        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Random _t = new Random();

            int[] leftStart = new int[5];
            int[] topStart = new int[5];
            int[] leftFinish = new int[5];
            int[] topFinish = new int[5];

            Image[] cervejas = new Image[5] { sagres0, sagres1, sagres2, sagres3, sagres4};
            


            for (int i=0; i < 5; i++) {

                theGrid.Children.Remove(cervejas[i]);
                //cervejas[i].Source = new BitmapImage(new Uri("images/sagres.png", UriKind.Relative));

                theGrid.Children.Add(cervejas[i]);

                leftStart[i] = _t.Next(10, (int)theGrid.ActualWidth - 50);
                topStart[i] = _t.Next(10, 70);
                leftFinish[i] = _t.Next(10, (int)theGrid.ActualWidth - 50);
                topFinish[i] = _t.Next(680, 700);

                int tempoAnim = _t.Next(2, 6);

                //Animação Cerveja
                ThicknessAnimation thicknessanimation = new ThicknessAnimation();
                thicknessanimation.From = new Thickness(leftStart[i], topStart[i], this.Margin.Right, this.Margin.Bottom);
                thicknessanimation.To = new Thickness(leftFinish[i], topFinish[i], this.Margin.Right, this.Margin.Bottom);
                thicknessanimation.Duration = TimeSpan.FromSeconds(tempoAnim);

                
                cervejas[i].BeginAnimation(MarginProperty, thicknessanimation);
                
                
            }


            
            txtmov.Text = sagres1.Margin.ToString();

            Dispatcher.Invoke(
                () =>
                {

                    //txthippo.Text = image.Margin.ToString();
                    //txtmov.Text = sagres1.Margin.ToString();
                    //txtmov.Text = sagres1.Margin.Left.ToString() + ", " + sagres1.Margin.Top.ToString() + ", " + sagres1.Margin.Right.ToString() + ", " + sagres1.Margin.Bottom.ToString();


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


        //private bool bebeCerveja()
        //{
        //    bool ponto;


        //    sagres1.Margin 
        //    if ()

        //    //sagres1.Margin.Left.ToString() + ", " + sagres1.Margin.Top.ToString() + ", " + sagres1.Margin.Right.ToString() + ", " + sagres1.Margin.Bottom.ToString();

        //    return ponto;
        //}


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
            int moveSpeed = 15;

            if (e.Key == Key.Left)
            {
                //Keyboard.IsKeyDown(Key.A)
                isLeftPressed = true;
                //this.txtkey.Text = "LEFT LEFT";
                txtkey.Text = "LEFT:" + isLeftPressed.ToString();
                txtcoord.Text = image.Margin.ToString();
                //txtcoord.Text = image.Margin.Left.ToString() +", "+ image.Margin.Top.ToString() + ", " + image.Margin.Right.ToString() + ", " + image.Margin.Bottom.ToString();
                if (image.Margin.Left > 1) {
                    image.Margin = new Thickness(image.Margin.Left - moveSpeed, image.Margin.Top, image.Margin.Right + moveSpeed, image.Margin.Bottom);
                }
                


            }

            if (e.Key == Key.Right)
            {
                isRightPressed = true;
                txtkey.Text = "RIGHT:" + isRightPressed.ToString();
                txtcoord.Text = image.Margin.Left.ToString() + ", " + image.Margin.Top.ToString() + ", " + image.Margin.Right.ToString() + ", " + image.Margin.Bottom.ToString();
                if (image.Margin.Right > -325)
                {
                    image.Margin = new Thickness(image.Margin.Left + moveSpeed, image.Margin.Top, image.Margin.Right - moveSpeed, image.Margin.Bottom);
                }

            }

            if (e.Key == Key.Space)
            {
                //421 to top
                while (image.Margin.Top > theGrid.ActualHeight - 450)
                {
                    image.Margin = new Thickness(image.Margin.Left, image.Margin.Top-2, image.Margin.Right, image.Margin.Bottom);
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

            if (e.Key == Key.Space)
            {
                //421 to top
                while (image.Margin.Top < 421)
                {
                    image.Margin = new Thickness(image.Margin.Left, image.Margin.Top + 2, image.Margin.Right, image.Margin.Bottom);
                }

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

            //sagres1.ManipulationStarted += Sagres1_ManipulationStarted;



            //Storyboard teste = new Storyboard();

            //teste.BeginAnimation(MarginProperty, thicknessanimation);



            //Completed não funciona ):

            //HandoffBehavior handoffBehavior = new HandoffBehavior();
            //sagres1.ManipulationCompleted += Sagres1_ManipulationCompleted;

            //CervejaAnimation teste = new CervejaAnimation();
            //teste.ThicknessAnimationExample();


            //Storyboard db = FindResource("Storyline") as Storyboard;
            

            //runStoryboard("Storyline", sagres1.Name);

        }


        //void runStoryboard(string storyboardName, string objectName)
        //{
        //    Storyboard sb = FindResource(storyboardName) as Storyboard;

        //    foreach (var child in sb.Children)
        //        Storyboard.SetTargetName(child, objectName);

        //    sb.Begin(this); 
        //}


        private void Sagres1_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            txtmov.Text = "ANIMATION STARTED";
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            txtmov.Text = "ANIMATION COMPLETED";
            //Storyboard Storyline = new Storyboard();
        }

        

        

        //public class CervejaAnimation : Page
        //{
        //    public void ThicknessAnimationExample()
        //    {

        //        // TESTE COM STORYBOARD ----------------------------------------------------------

        //        //Namescope para esta página
        //        NameScope.SetNameScope(this, new NameScope());

        //        //Criar a imagem
        //        Image sagrespt = new Image();

        //        sagrespt.Width = 100;
        //        sagrespt.Height = 100;
        //        BitmapImage bi3 = new BitmapImage();
        //        bi3.BeginInit();
        //        bi3.UriSource = new Uri("images/sagres.png", UriKind.Relative);
        //        bi3.EndInit();
        //        sagrespt.Source = bi3;

        //        this.RegisterName("imgAnimated", sagrespt);

        //        //Definição da animação 
        //        ThicknessAnimation thicknessanimation = new ThicknessAnimation();


        //        thicknessanimation.From = new Thickness(0, 10, 683, 461);
        //        thicknessanimation.To = new Thickness(300, 300, this.Margin.Right, this.Margin.Bottom);
        //        thicknessanimation.Duration = TimeSpan.FromSeconds(1);


        //        //Atribuir a animação
        //        Storyboard.SetTargetName(thicknessanimation, "imgAnimated");
        //        Storyboard.SetTargetProperty(thicknessanimation, new PropertyPath(MarginProperty));

        //        //Criação da storyboard
        //        Storyboard moveCerveja = new Storyboard();
        //        moveCerveja.Children.Add(thicknessanimation);

        //        sagrespt.Loaded += delegate (object sender, RoutedEventArgs e)
        //        {
        //            moveCerveja.Begin(this);
        //        };

        //        StackPanel myStackPanel = new StackPanel();
        //        myStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
        //        myStackPanel.Children.Add(sagrespt);

        //        Content = myStackPanel;

        //    }


        //} //CervejaAnimation







    } //mainwidow
} //namespace
