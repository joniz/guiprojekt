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
using System.Drawing;

namespace guiprojekt
{
    
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon MyNotifyIcon;

        public MainWindow()
                {
                    InitializeComponent();
                    MyNotifyIcon = new System.Windows.Forms.NotifyIcon();
                    MyNotifyIcon.Icon = new System.Drawing.Icon(@"C:\labbar\GUIProjekt\guiprojekt\ReminderIcon.ico",16,16);
                    MyNotifyIcon.MouseDoubleClick +=
                        new System.Windows.Forms.MouseEventHandler
                            (MyNotifyIcon_MouseDoubleClick);
                }



        void MyNotifyIcon_MouseDoubleClick(object sender,System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            MyNotifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }

        




        private void monthPicker_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void monthPicker_Loaded_1(object sender, RoutedEventArgs e)
        {

        }



        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

      
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.ShowInTaskbar = false;
            MyNotifyIcon.BalloonTipTitle = "Minimize Sucessful";
            MyNotifyIcon.BalloonTipText = "Minimized the app ";
            MyNotifyIcon.ShowBalloonTip(400);
            MyNotifyIcon.Visible = true;
        }

       

    }
}
