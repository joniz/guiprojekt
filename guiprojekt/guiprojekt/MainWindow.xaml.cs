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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<reminder> _listWithAllReminders =  new List<reminder>();
        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private static System.Timers.Timer aTimer;

        
        int _weekday = 1;
        
        public List<reminder> _reminderListForThreads = new List<reminder>(); //ska funka som vector, då vector i c# är en matematisk vektor

        int _page = 0;
        string _alarms;
        
        string[] _allAlarms = new string[20];
        string[] _allStartAlarms = new string[20];
        string[] _allAlarmDays = new string[20];
        System.Windows.Media.Brush _brush = new SolidColorBrush(Color.FromRgb(245, 245, 220));
        System.Windows.Media.Brush _brush2 = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        System.Windows.Media.Brush _brush3 = new SolidColorBrush(Color.FromRgb(38, 38, 38));
        System.Windows.Media.Brush _brush4 = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        System.Windows.Thickness _thick = new Thickness(1);

        public MainWindow()
        {

            readFromFile();
            
            string env = Environment.UserName;
            string path="";
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 2)
                path += @"C:\Users\" + env + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\startupreminder.bat";

            else
                path += @"C:\Users\Hugoqqqq\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\startupreminder.bat";
            string batStart = "cd \"";
            batStart += Directory.GetCurrentDirectory();
            string batContinue = "Start guiprojekt.exe startup";
            using (StreamWriter sw = File.CreateText(path)) 
            {
                    sw.WriteLine(batStart);
                    sw.WriteLine(batContinue);
            }
            

            string[] args = Environment.GetCommandLineArgs();

            

            
            InitializeComponent();

            MyNotifyIcon = new System.Windows.Forms.NotifyIcon();
            MyNotifyIcon.Icon = new System.Drawing.Icon(@"ReminderIcon.ico", 16, 16);
            MyNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MyNotifyIcon_MouseDoubleClick);
            MyNotifyIcon.BalloonTipClicked += CheckAlarm;
            aTimer = new System.Timers.Timer(5000);
            aTimer.Start();
            aTimer.Elapsed += OnTimedEvent;

            if(args.Length > 1)
            {
                 if(args[1] == "startup")
                 {
                 this.WindowState = System.Windows.WindowState.Minimized;
                 Window_Deactivated();                
                 }
            }
        }



        void MyNotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            this.WindowState = WindowState.Normal;

            MyNotifyIcon.Visible = false;
            this.ShowInTaskbar = true;
            this.Focus();
        }
      
        private void monthPicker_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void CheckAlarm(object sender, EventArgs e)
        {
            //för att bocka av alarm typ

        }

        private void saveAlarms()
        {
            if (File.Exists(@"reminders.txt"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"reminders.txt");
                int count = checkNumberOfLines();
                for (int x = 0; x < count; x++)
                {
                    string read = file.ReadLine();
                    if (read != "")
                    {
                        string alarm = read.Split('|')[2];
                        string startAlarm = read.Split('|')[1];
                        string days = "";
                        int y = 3;
                        while (read.Split('|')[y] != "")
                        {
                            days += read.Split('|')[y] + "|";
                            y++;
                        }
                        _allAlarms[x] = alarm;
                        _allStartAlarms[x] = startAlarm;
                        _allAlarmDays[x] = days;
                    }
                }
            }
        }


        

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            /*bool ok = false;*/
            /*System.Diagnostics.Debug.WriteLine(System.DateTime.Now.DayOfWeek);
            System.Diagnostics.Debug.WriteLine(DateTime.Now.Minute);*/

           // DateTime currentTime = DateTime.Now;
            
            int x = 1;
            string time = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            string day = DateTime.Now.DayOfWeek.ToString();
            while (_allAlarms[x] != null)
            {
                int y = 0;
                while (_allAlarmDays[x].Split('|')[y] != "")
                {
                    string checkDay = _allAlarmDays[x].Split('|')[y];
                    if (checkDay == day && _allAlarms[x] == time)
                    {
                        System.Diagnostics.Debug.WriteLine(_allAlarms[x]);
                    }
                    y++;
                }
                x++;

                /*if (_reminderListForThreads.Count != 0)
                    {
                        for (int i = 0; i < _reminderListForThreads.Count; i++)
                        {
                            if (_reminderListForThreads[i]._alarmTime.Hour == DateTime.Now.Hour && _reminderListForThreads[i]._alarmTime.Minute == DateTime.Now.Minute && _reminderListForThreads[i]._weekDays[i] == System.DateTime.Now.DayOfWeek)
                            {

                                ok = true;
                                System.Diagnostics.Debug.WriteLine("Hej");                        
                        }
                    }
                }

                if (ok)
                {                
                    //System.Windows.Forms.MessageBox.Show("ALARM!!!");
                    MyNotifyIcon.ShowBalloonTip(4000);
                    MyNotifyIcon.BalloonTipTitle = "Daily reminder";
                    MyNotifyIcon.BalloonTipText = "Du har ett alarm som kan stängas av";
                }
                 * */
            }
        }
 //--------------------------------------------------------------------------------------------
/*
        public void createReminder_Click(object sender, RoutedEventArgs e)
        {
           

            List<DayOfWeek> weekDays = new List<DayOfWeek>();

            string reminderTitle = testeet.titleForReminder.Text;
            string startTime = testeet.starttid.Text;
            string alarmTime = testeet.alarmtid.Text;

            if ((bool)testeet.mondaybox.IsChecked)
            {
                weekDays.Add(DayOfWeek.Monday);
            }
            if ((bool)testeet.tuesdaybox.IsChecked)
            {
                weekDays.Add(DayOfWeek.Tuesday);
            }
            if ((bool)testeet.wednesdaybox.IsChecked)
            {
                weekDays.Add(DayOfWeek.Wednesday);
            }
            if ((bool)testeet.thursdaybox.IsChecked)
            {
                weekDays.Add(DayOfWeek.Thursday);
            }
            if ((bool)testeet.fridaybox.IsChecked)
            {
                weekDays.Add(DayOfWeek.Friday);
            }
            if ((bool)testeet.saturdaybox.IsChecked)
            {
                weekDays.Add(DayOfWeek.Saturday);
            }
            if ((bool)testeet.sundaybox.IsChecked)
            {
                weekDays.Add(DayOfWeek.Sunday);
            }
            checkTextFile();

            reminder reminderObj = new reminder(reminderTitle, startTime, alarmTime, weekDays);




<<<<<<< HEAD

            _reminderListForThreads.Add(reminderObj) ;

            testeet.titleForReminder.Text = "";
            testeet.alarmtid.Text = "";
            testeet.starttid.Text = "";
            testeet.mondaybox.IsChecked = false;
            testeet.tuesdaybox.IsChecked = false;
            testeet.wednesdaybox.IsChecked = false;
            testeet.thursdaybox.IsChecked = false;
            testeet.fridaybox.IsChecked = false;
            testeet.saturdaybox.IsChecked = false;
            testeet.sundaybox.IsChecked = false;
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
            
            string titel = testeet.titleForReminder.Text;
            if (isValidTime(testeet.starttid.Text) && isValidTime(testeet.alarmtid.Text) && !titel.Contains("|") && !(titel.Length > 20) && !(string.IsNullOrWhiteSpace(titel)) && !(titel.Length < 3))
            {
                testeet.createReminder.IsEnabled = true;

            }
            else testeet.createReminder.IsEnabled = false;
        }


=======

            _reminderListForThreads.Add(reminderObj) ;

            testeet.titleForReminder.Text = "";
            testeet.alarmtid.Text = "";
            testeet.starttid.Text = "";
            testeet.mondaybox.IsChecked = false;
            testeet.tuesdaybox.IsChecked = false;
            testeet.wednesdaybox.IsChecked = false;
            testeet.thursdaybox.IsChecked = false;
            testeet.fridaybox.IsChecked = false;
            testeet.saturdaybox.IsChecked = false;
            testeet.sundaybox.IsChecked = false;
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
            
            string titel = testeet.titleForReminder.Text;
            if (isValidTime(testeet.starttid.Text) && isValidTime(testeet.alarmtid.Text) && !titel.Contains("|") && !(titel.Length > 20) && !(string.IsNullOrWhiteSpace(titel)) && !(titel.Length < 3))
            {
                testeet.createReminder.IsEnabled = true;

            }
            else testeet.createReminder.IsEnabled = false;
        }


>>>>>>> 9be84ccead9592e1081c80a8ac687a1a534b5617

        */
        //------------------------------------------------------------------------------------------------------
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

        private void addLabel(StackPanel day, Label text)
        {
            
            text.Background = _brush;
            text.BorderBrush = _brush2;
            text.BorderThickness = _thick;
            day.Children.Add(text);
        }

        private int checkNumberOfLines()
        {
            int count = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"reminders.txt");
            while ((line = file.ReadLine()) != null)
            {
                count++;
            }
            return count;
        }

        public void NewReminder(reminder obj)
        {
            

            
        }

        public void readFromFile()
        {
            if (File.Exists(@"remindersBin.bin"))
            {
                using (Stream stream = File.Open(@"remindersBin.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    _listWithAllReminders = (List<reminder>)bin.Deserialize(stream);
                         
                    
                 }




            }

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
            infoMonday.Children.Clear();
            readFromFile();
            saveAlarms();
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
            infoTuesday.Children.Clear();
            //readFromFile("Tuesday", infoTuesday);
            saveAlarms();
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
            infoWednesday.Children.Clear();
            //readFromFile("Wednesday", infoWednesday);
            saveAlarms();
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
            infoThursday.Children.Clear();
            //readFromFile("Thursday", infoThursday);
            saveAlarms();
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
            infoFriday.Children.Clear();
            //readFromFile("Friday", infoFriday);
            saveAlarms();
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
            infoSaturday.Children.Clear();
            //readFromFile("Saturday", infoSaturday);
            saveAlarms();
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



        private void reminder_Click(object sender, RoutedEventArgs e)
        {
            if (newReminder.Visibility == System.Windows.Visibility.Collapsed)
            {
                newReminder.Visibility = System.Windows.Visibility.Visible;
            }


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Deactivated(object sender=null, EventArgs e=null)
        {
            if (this.WindowState == System.Windows.WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                MyNotifyIcon.Visible = true;
                MyNotifyIcon.BalloonTipTitle = "Minimize Sucessful";
                MyNotifyIcon.BalloonTipText = "Minimized the app ";
                MyNotifyIcon.ShowBalloonTip(400);
            }
        }


    }
}
