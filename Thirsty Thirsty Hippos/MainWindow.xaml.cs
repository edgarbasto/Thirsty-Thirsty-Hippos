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



            //SetTimer();

            //aTimer.Stop();
            //aTimer.Dispose();

            //Timer timer = new Timer(100);
            //timer.Elapsed += async (sender, e) => await HandleTimer();
            //timer.Start();           
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(
                () => this.image.Margin = new Thickness(image.Margin.Left+5, image.Margin.Top, image.Margin.Right, image.Margin.Bottom);
           
               
            );
        }
   
        //  Timer Tick setup
        //public static void SetTimer()
        //{
        //    aTimer = new System.Timers.Timer(100);

        //    aTimer.Elapsed += OnTimedEvent;
        //    aTimer.AutoReset = true;
        //    aTimer.Enabled = true;
        //    //https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.110).aspx

        //}

        //private static void OnTimedEvent(object source, ElapsedEventArgs e)
        //{
        //    if(isLeftPressed)
        //    {

        //    }
        //}




        private void image_KeyDown(object sender, KeyEventArgs e)
        {

            //switch (e.Key)
            //{
            //    case Key.Left:
            //        leftMargin -= 5;
            //        e.Handled = true;
            //        break;
            //    case Key.Right:
            //        leftMargin += 5;
            //        e.Handled = true;
            //        break;

            //}

            //this.image.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);



            if (e.Key == Key.Left)
            {
                isLeftPressed = true;
            }

            if (e.Key == Key.Right)
            {
                isRightPressed = true;
            }

        }



        private void image_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                isLeftPressed = false;
            }

            if (e.Key == Key.Right)
            {
                isRightPressed = false;
            }


        }
    }
}
