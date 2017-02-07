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



        private void createReminder_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow = Application.Current.MainWindow as MainWindow;





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

            _parentWindow.writeToFile(_parentWindow._listWithAllReminders);
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
        


      private void checkTextFile()
        {
           
            string path = @"C:\Users\" + Environment.UserName + "\\remindersBin.bin";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) { }
            }

        }

     

 

        private bool validateSelectedDays()
        {
            if ((bool)mondaybox.IsChecked || (bool)tuesdaybox.IsChecked || (bool)wednesdaybox.IsChecked || (bool)thursdaybox.IsChecked || (bool)fridaybox.IsChecked || (bool)saturdaybox.IsChecked || (bool)sundaybox.IsChecked)
                return true;
            else return false;

        }
        private bool timeTest(DateTime startTime, DateTime alarmTime)
        {
            if (startTime.Hour >= alarmTime.Hour && startTime.Minute >= alarmTime.Minute)
            {
                return false;


            }
            else return true;


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

            if (isValidTime(starttid.Text) && isValidTime(alarmtid.Text) && !titel.Contains("|") && !(titel.Length > 20) && !(string.IsNullOrWhiteSpace(titel)) && !(titel.Length < 3) && (
                (bool)mondaybox.IsChecked || (bool)tuesdaybox.IsChecked || (bool)wednesdaybox.IsChecked || (bool)thursdaybox.IsChecked || (bool)fridaybox.IsChecked || (bool)saturdaybox.IsChecked || (bool)sundaybox.IsChecked) && timeTest(Convert.ToDateTime(starttid.Text), Convert.ToDateTime(alarmtid.Text)))


            {
                if(validateSelectedDays())
                createReminder.IsEnabled = true;

            }
            else createReminder.IsEnabled = false;
        }

        
    }
}

    




    