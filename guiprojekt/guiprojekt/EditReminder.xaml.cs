﻿using System;
using System.IO;
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
using System.Runtime.Serialization.Formatters.Binary;
using guiprojekt;


namespace guiprojekt
{
    /// <summary>
    /// Interaction logic for addReminder.xaml
    /// </summary>
    public partial class EditReminder : UserControl
    {
        MainWindow _parentWindow;

        public EditReminder()
        {

            InitializeComponent();
            titleForReminder.IsEnabled = true;
        }

      
        private void editReminder_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow = Application.Current.MainWindow as MainWindow;
            System.Diagnostics.Debug.WriteLine(_parentWindow._listWithAllReminders.Count);
            if (boxCheck())
            {
                List<DayOfWeek> weekDays = new List<DayOfWeek>();

                string reminderTitle = titleForReminder.Text;
                string startTime = starttid.Text;
                string alarmTime = alarmtid.Text;

                if ((bool)mondaybox.IsChecked)
                {
                    weekDays.Add(DayOfWeek.Monday);
                }
                if ((bool)tuesdaybox.IsChecked)
                {
                    weekDays.Add(DayOfWeek.Tuesday);
                }
                if ((bool)wednesdaybox.IsChecked)
                {
                    weekDays.Add(DayOfWeek.Wednesday);
                }
                if ((bool)thursdaybox.IsChecked)
                {
                    weekDays.Add(DayOfWeek.Thursday);
                }
                if ((bool)fridaybox.IsChecked)
                {
                    weekDays.Add(DayOfWeek.Friday);
                }
                if ((bool)saturdaybox.IsChecked)
                {
                    weekDays.Add(DayOfWeek.Saturday);
                }
                if ((bool)sundaybox.IsChecked)
                {
                    weekDays.Add(DayOfWeek.Sunday);
                }
                

                for (int x = 0; x < _parentWindow._listWithAllReminders.Count; x++ )
                {
                    if (_parentWindow._listWithAllReminders[x]._editing == true)
                    {
                        _parentWindow._listWithAllReminders.RemoveAt(x);
                    }
                }

                for (int x = 0; x < weekDays.Count; x++)
                {
                    reminder reminderObj = new reminder(reminderTitle, startTime, alarmTime, weekDays[x].ToString());
                    _parentWindow._listWithAllReminders.Add(reminderObj);
                }
                
                Model.writeToFile(_parentWindow._listWithAllReminders);
                _parentWindow.readFromFile();
                titleForReminder.Text = "";
                alarmtid.Text = "";
                starttid.Text = "";
                mondaybox.IsChecked = false;
                tuesdaybox.IsChecked = false;
                wednesdaybox.IsChecked = false;
                thursdaybox.IsChecked = false;
                fridaybox.IsChecked = false;
                saturdaybox.IsChecked = false;
                sundaybox.IsChecked = false;

            }
        }


      

        public bool boxCheck()
        {
            if ((bool)mondaybox.IsChecked || (bool)tuesdaybox.IsChecked || (bool)wednesdaybox.IsChecked || (bool)thursdaybox.IsChecked || (bool)fridaybox.IsChecked || (bool)saturdaybox.IsChecked || (bool)sundaybox.IsChecked)
            {
                return true;
            }
            else return false;
        }

     
    

        private bool isValidTime(string time)
        {
            DateTime testVariable;
            return DateTime.TryParse(time, out testVariable);
        }

        private void testRoutedInput(object sender, RoutedEventArgs e)
        {
            testInput();
        }
        private void testInput(object sender = null, TextChangedEventArgs e = null)
        {
            string titel = titleForReminder.Text;
            if (isValidTime(starttid.Text) && isValidTime(alarmtid.Text) && !(titel.Length > 20) && !(string.IsNullOrWhiteSpace(titel)) && !(titel.Length < 3) && (
                (bool)mondaybox.IsChecked || (bool)tuesdaybox.IsChecked || (bool)wednesdaybox.IsChecked || (bool)thursdaybox.IsChecked || (bool)fridaybox.IsChecked || (bool)saturdaybox.IsChecked || (bool)sundaybox.IsChecked) && Model.timeTest(Convert.ToDateTime(starttid.Text), Convert.ToDateTime(alarmtid.Text)))
            {
                editReminder.IsEnabled = true;

            }
            else editReminder.IsEnabled = false;
        }
    }
}






