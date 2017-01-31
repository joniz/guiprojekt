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
    public partial class addReminder : UserControl
    {
        MainWindow _parentWindow;




        public addReminder()
        {
            InitializeComponent();
        }

        /* public List<reminder> getReminderList
         {
            get { return _reminderList;}


         }*/





        private void createReminder_Click(object sender, RoutedEventArgs e)
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
                checkTextFile();


                for (int x = 0; x < weekDays.Count; x++)
                {
                    reminder reminderObj = new reminder(reminderTitle, startTime, alarmTime, weekDays[x].ToString());
                    _parentWindow._listWithAllReminders.Add(reminderObj);
                }

                writeToFile(_parentWindow._listWithAllReminders);
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




        private void writeToFile(List<reminder> reminderList)
        {

            using (Stream stream = File.Open("remindersBin.bin", FileMode.Create))
            {

                BinaryFormatter bin = new BinaryFormatter();


                bin.Serialize(stream, reminderList);






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

        private void checkTextFile()
        {
            string path = @"reminders.txt";
            string path2 = @"remindersBin.bin";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) { }
            }
            else if (!File.Exists(path2))
            {
                using (StreamWriter sw = File.CreateText(path2)) { }
            }
        }

        private bool isValidTime(string time)
        {
            DateTime testVariable;
            return DateTime.TryParse(time, out testVariable);
        }

        private void testInput(object sender, TextChangedEventArgs e)
        {
            string titel = titleForReminder.Text;
            if (isValidTime(starttid.Text) && isValidTime(alarmtid.Text) && !titel.Contains("|") && !(titel.Length > 20) && !(string.IsNullOrWhiteSpace(titel)) && !(titel.Length < 3))
            {
                createReminder.IsEnabled = true;

            }
            else createReminder.IsEnabled = false;
        }
    }
}

    




