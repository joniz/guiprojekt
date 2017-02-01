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

       /* public List<reminder> getReminderList
        {
           get { return _reminderList;}


        }*/
        
        



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


            
           
            writeToFile(_reminderList);
            
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
            string path2 = @"remindersBin.bin";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) { }
            }else if (!File.Exists(path2))
            {
                using (StreamWriter sw = File.CreateText(path2)) { }
            }
        }

        private void writeToFile(List<reminder> remList)
        {
            using (Stream stream = File.Open("remindersBin.bin", FileMode.Create))
            {

                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, remList);


                /* outputFile.WriteLine("");
                 outputFile.Write(remObj._title);
                 outputFile.Write("|");
                 outputFile.Write(remObj._startTime.Hour.ToString());
                 outputFile.Write(":");
                 outputFile.Write(remObj._startTime.Minute.ToString());
                 outputFile.Write("|");
                 outputFile.Write(remObj._alarmTime.Hour.ToString());
                 outputFile.Write(":");
                 outputFile.Write(remObj._alarmTime.Minute.ToString());
                 outputFile.Write("|");
                 for (int i = 0; remObj._weekDays.Count > i; i++)
                 {
                     outputFile.Write(remObj._weekDays[i]);
                     outputFile.Write("|");
                 }

             }
             */





          
            }
        }

        private bool validateSelectedDays()
        {
            if ((bool)mondaybox.IsChecked || (bool)tuesdaybox.IsChecked || (bool)wednesdaybox.IsChecked || (bool)thursdaybox.IsChecked || (bool)fridaybox.IsChecked || (bool)saturdaybox.IsChecked || (bool)sundaybox.IsChecked)
                return true;
            else return false;

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
                if(validateSelectedDays())
                createReminder.IsEnabled = true;

            }
            else createReminder.IsEnabled = false; 
        }
   
    }
}

