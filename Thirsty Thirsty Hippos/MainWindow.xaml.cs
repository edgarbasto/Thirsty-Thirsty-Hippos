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


        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(
                () =>
                {

                    if (isLeftPressed)
                    {
                        this.txtkey.Text = "LEFT";
                        this.image.Margin = new Thickness(image.Margin.Left + 5, image.Margin.Top, image.Margin.Right - 5, image.Margin.Bottom);
                    }
                }
            );
        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                textBlock1.Text = "You Entered: " + textBox1.Text;
                //textBox1.Text = "You Entered: " + textBox1.Text;
            }
        }

        private void image_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Left)
            {
                //Keyboard.IsKeyDown(Key.A)
                isLeftPressed = true;
                //this.txtkey.Text = "LEFT LEFT";
                this.txtkey.Text = "POIS POIS";
            }

            if (e.Key == Key.Right)
            {
                isRightPressed = true;
            }

        }

        private void txtbox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.L) {
                
                this.txtkey.Text = "POIS POIS";
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
