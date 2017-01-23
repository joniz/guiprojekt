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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        DateTime _date = new DateTime(2008, 3, 15);
        int _page = 0;
        string[] _days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public MainWindow()
        {
            InitializeComponent();

            MyNotifyIcon = new System.Windows.Forms.NotifyIcon();
            MyNotifyIcon.Icon = new System.Drawing.Icon(@"ReminderIcon.ico", 16, 16);
            MyNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MyNotifyIcon_MouseDoubleClick);

        }
        void MyNotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            this.WindowState = WindowState.Normal;
            this.Focus();
            MyNotifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
         {
             this.ShowInTaskbar = false;
            
         }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            MyNotifyIcon.BalloonTipTitle = "Minimize Sucessful";
            MyNotifyIcon.BalloonTipText = "Minimized the app ";
            MyNotifyIcon.ShowBalloonTip(400);
            MyNotifyIcon.Visible = true;

        }
        
        
        
        
        private void newReminder_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            _page = 8;
            newReminder.Visibility = System.Windows.Visibility.Visible;
        }

        

        private void CheckWeekday(int page)
        {
            if (page == 1)
            {
                infoMonday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (page == 2)
            {
                infoTuesday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (page == 3)
            {
                infoWednesday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (page == 4)
            {
                infoThursday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (page == 5)
            {
                infoFriday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (page == 6)
            {
                infoSaturday.Visibility = System.Windows.Visibility.Hidden;
            } if (page == 7)
            {
                infoSunday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (page == 8)
            {
                newReminder.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void readFromFile()
        {

        }

        private void monday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (infoMonday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoMonday.Visibility = System.Windows.Visibility.Visible;
                _page = 1;
            }
            else
            {
                infoMonday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void tuesday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (infoTuesday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoTuesday.Visibility = System.Windows.Visibility.Visible;
                _page = 2;
            }
            else
            {
                infoTuesday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void wednesday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (infoWednesday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoWednesday.Visibility = System.Windows.Visibility.Visible;
                _page = 3;
            }
            else
            {
                infoWednesday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void thursday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (infoThursday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoThursday.Visibility = System.Windows.Visibility.Visible;
                _page = 4;
            }
            else
            {
                infoThursday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void friday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (infoFriday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoFriday.Visibility = System.Windows.Visibility.Visible;
                _page = 5;
            }
            else
            {
                infoFriday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void saturday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (infoSaturday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoSaturday.Visibility = System.Windows.Visibility.Visible;
                _page = 6;
            }
            else
            {
                infoSaturday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void sunday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (infoSunday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoSunday.Visibility = System.Windows.Visibility.Visible;
                _page = 7;
            }
            else
            {
                infoSunday.Visibility = System.Windows.Visibility.Hidden;
            }
        }


    }
}
