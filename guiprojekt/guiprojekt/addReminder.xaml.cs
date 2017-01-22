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
            
            reminder reminderObj = new reminder(reminderTitle,startTime, alarmTime,weekDays);
            _reminderList.Add(reminderObj);
            System.Diagnostics.Debug.WriteLine(reminderObj._title);
            System.Diagnostics.Debug.WriteLine(reminderObj._startTime);
            for (int i = 0; reminderObj._weekDays.Count > i; i++)
            {
                System.Diagnostics.Debug.WriteLine(reminderObj._weekDays[i]);


            }
        }
        public bool isValidTime(string time)
        {
            DateTime testVariable;
            return DateTime.TryParse(time, out testVariable);
            

        }
        public void testTimeInput(object sender, TextChangedEventArgs e)
        {
            if (isValidTime(starttid.Text) && isValidTime(alarmtid.Text))
            {
                createReminder.IsEnabled = true;

            }
            else createReminder.IsEnabled = false;


        }
        
    
    
    }
    








}
