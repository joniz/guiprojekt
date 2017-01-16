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

namespace guiprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void monthPicker_Loaded(object sender, RoutedEventArgs e)
        {

        }



        int weekday = 0;

        private void CheckWeekday(int day)
        {
            if (day == 1)
            {
                infoMonday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (day == 2)
            {
                infoTuesday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (day == 3)
            {
                infoWednesday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (day == 4)
            {
                infoThursday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (day == 5)
            {
                infoFriday.Visibility = System.Windows.Visibility.Hidden;
            }
            if (day == 6)
            {
                infoSaturday.Visibility = System.Windows.Visibility.Hidden;
            } if (day == 7)
            {
                infoSunday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void monday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(weekday);
            if (infoMonday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoMonday.Visibility = System.Windows.Visibility.Visible;
                weekday = 1;
            }
            else
            {
                infoMonday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void tuesday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(weekday);
            if (infoTuesday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoTuesday.Visibility = System.Windows.Visibility.Visible;
                weekday = 2;
            }
            else
            {
                infoTuesday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void wednesday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(weekday);
            if (infoWednesday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoWednesday.Visibility = System.Windows.Visibility.Visible;
                weekday = 3;
            }
            else
            {
                infoWednesday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void thursday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(weekday);
            if (infoThursday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoThursday.Visibility = System.Windows.Visibility.Visible;
                weekday = 4;
            }
            else
            {
                infoThursday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void friday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(weekday);
            if (infoFriday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoFriday.Visibility = System.Windows.Visibility.Visible;
                weekday = 5;
            }
            else
            {
                infoFriday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void saturday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(weekday);
            if (infoSaturday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoSaturday.Visibility = System.Windows.Visibility.Visible;
                weekday = 6;
            }
            else
            {
                infoSaturday.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void sunday_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(weekday);
            if (infoSunday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoSunday.Visibility = System.Windows.Visibility.Visible;
                weekday = 7;
            }
            else
            {
                infoSunday.Visibility = System.Windows.Visibility.Hidden;
            }
        }


    }
}
