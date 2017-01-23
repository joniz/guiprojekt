using System;
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


namespace guiprojekt
{
    /// <summary>
    /// Interaction logic for addReminder.xaml
    /// </summary>
    public partial class addReminder : UserControl
    {

        List<reminder> _reminderList = new List<reminder>();

        public addReminder()
        {
            InitializeComponent();
        }

        private void createReminder_Click(object sender, RoutedEventArgs e)
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

            reminder reminderObj = new reminder(reminderTitle, startTime, alarmTime, weekDays);
            _reminderList.Add(reminderObj);
            System.Diagnostics.Debug.WriteLine(reminderObj._title);
            System.Diagnostics.Debug.WriteLine(reminderObj._startTime);
            System.Diagnostics.Debug.WriteLine(_reminderList.Count);
            for (int i = 0; reminderObj._weekDays.Count > i; i++)
            {
                System.Diagnostics.Debug.WriteLine(reminderObj._weekDays[i]);
            }
            writeToFile(reminderObj);

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

        private void checkTextFile()
        {
            string path = @"reminders.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) { }
            }
        }

        private void writeToFile(reminder remObj)
        {
            using (StreamWriter outputFile = new StreamWriter(@"reminders.txt", true))
            {
                outputFile.WriteLine("");
                outputFile.Write(remObj._title);
                outputFile.Write(" ");
                outputFile.Write(remObj._startTime);
                outputFile.Write(" ");
                for (int i = 0; remObj._weekDays.Count > i; i++)
                {
                    outputFile.Write(remObj._weekDays[i]);
                    outputFile.Write(" ");
                }
            }
        }

        private bool isValidTime(string time)
        {
            DateTime testVariable;
            return DateTime.TryParse(time, out testVariable);
        }

        private void testTimeInput(object sender, TextChangedEventArgs e)
        {
            if (isValidTime(starttid.Text) && isValidTime(alarmtid.Text))
            {
                createReminder.IsEnabled = true;

            }
            else createReminder.IsEnabled = false;
        }

    }
}

