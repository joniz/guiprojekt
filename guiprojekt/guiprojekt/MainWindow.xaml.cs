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


        Style buttonStyle = new Style(typeof(Control));

        public List<reminder> _reminderListForThreads = new List<reminder>(); //ska funka som vector, då vector i c# är en matematisk vektor

        int _page = 0;

        string _alarms;
        
        string[] _allAlarms = new string[20];
        string[] _allStartAlarms = new string[20];
        string[] _allAlarmDays = new string[20];

        int _idCount = 0;

        System.Windows.Media.Brush _brush = new SolidColorBrush(Color.FromRgb(245, 245, 220));
        System.Windows.Media.Brush _brush2 = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        System.Windows.Media.Brush _brush3 = new SolidColorBrush(Color.FromRgb(38, 38, 38));
        System.Windows.Media.Brush _brush4 = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        System.Windows.Thickness _thick = new Thickness(1);

        public MainWindow()
        {

            readFromFile();
            string env = Environment.UserName;
            string path = @"C:\Users\" + env + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\startupreminder.bat";
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
            aTimer = new System.Timers.Timer(3000);
            aTimer.Start();

         
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
            }
        }
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
                newReminder.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (page == 9)
            {
                showEditReminder.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void alarm(object source, System.Timers.ElapsedEventArgs e)
        {
            bool ok = false;
            for (int x = 0; x < _listWithAllReminders.Count; x++)
            {
                DateTime currentTime = DateTime.Now;
                string time = currentTime.Hour + ":" + currentTime.Minute;
                string test = _listWithAllReminders[x]._alarmTime.Hour + ":" + _listWithAllReminders[x]._alarmTime.Minute;
                if (_listWithAllReminders[x]._weekDays == currentTime.DayOfWeek.ToString() && time == test)
                {
                    System.Diagnostics.Debug.WriteLine("alarm");
                    ok = true;
                }
            }
            if (ok)
            {
                MyNotifyIcon.BalloonTipTitle = "ALARM";
                MyNotifyIcon.BalloonTipText = "Du har ett alarm";
                MyNotifyIcon.ShowBalloonTip(400);
            }

        }

        private void addLabel(StackPanel panel,String day)
        {
            //Sätt annars till 285
                                 
            //Thickness marginLeft = deleteButton.Margin;
            //Thickness marginTop = deleteButton.Margin;
            //Thickness marginRight = deleteButton.Margin;
            //Thickness marginBottom = deleteButton.Margin;

            //marginLeft.Left = 0;
            //marginLeft.Top = 0;
            //marginLeft.Right = 0;
            //marginLeft.Bottom = 0;

            //deleteButton.Margin = marginLeft;

            buttonStyle.Setters.Add(new Setter(BackgroundProperty, null));
            buttonStyle.Setters.Add(new Setter(BorderBrushProperty, null));
            //deleteButton.Style = this.Resources["tabortStyle"] as Style;
            //editButton.Style = this.Resources["redigeraStyle"] as Style;

            //panel.Name = "reminderAndButtonStackPanel";

            for (int x = 0; x < _listWithAllReminders.Count; x++)
            {
                string test = _listWithAllReminders[x]._weekDays;
                if (test == day)
                {
                    Label text = new Label();
                    Button deleteButton = new Button();
                    Button editButton = new Button();
                    //StackPanel stack = new StackPanel();
                    StackPanel stack = new StackPanel();
                    deleteButton.Name = "deleteButton";
                    editButton.Name = "editButton";
                    stack.Orientation = Orientation.Horizontal;
                    deleteButton.Content = "Ta bort";
                    editButton.Content = "Redigera";

                    deleteButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(deleteButton_Click));
                    editButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(editButton_Click));

                    //text.Width = 325;      
                    text.Background = _brush;
                    text.BorderBrush = _brush2;
                    text.BorderThickness = _thick;
                    text.Content = "Titel: " + _listWithAllReminders[x]._title + " Starttid: " + _listWithAllReminders[x]._startTime.Hour + ":" + _listWithAllReminders[x]._startTime.Minute + " Alarmtid: " + _listWithAllReminders[x]._alarmTime.Hour + ":" + _listWithAllReminders[x]._alarmTime.Minute;
                    text.Name = "r" + _listWithAllReminders[x]._idNum.ToString();
                    editButton.Name = "r" + _listWithAllReminders[x]._idNum.ToString();
                    deleteButton.Name = "r" + _listWithAllReminders[x]._idNum.ToString();
                    stack.Children.Add(text);
                    stack.Children.Add(editButton);
                    stack.Children.Add(deleteButton);
                   
                    panel.Children.Add(stack);
                }
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

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Endast detta som krävs, Vi behöver inte göra någon Children.Remove med tanke på C#:s GC.

            FrameworkElement parentOfButton = (FrameworkElement)((Button)sender).Parent;
            
            Button test = (Button)sender as Button;
            System.Diagnostics.Debug.WriteLine(test.Name);
            for (int i = 0; i < _listWithAllReminders.Count; i++)
            {
                if (test.Name == "r" + _listWithAllReminders[i]._idNum)
                {
                    parentOfButton.Visibility = Visibility.Collapsed;
                    _listWithAllReminders.RemoveAt(i);
                    writeToFile(_listWithAllReminders);
                }
            }
            //var test = ((Button)sender).Parent;
            //var test2 = ((StackPanel)parentOfButton).Parent;

            //Control control = (Button)sender;
            //StackPanel hideStackPanel = (StackPanel)control.Parent;


            //string name = control.Name;
            //var test3 = control.Parent;

            ////stackpanelReminder är stackpanelen som innehåller labeln samt delete-knappen
            //string stackpanelReminder = parentOfButton.Name;

            ////parentOfStackpanelReminder är stackpanelen som innehåller stackpanelen som innehåller labeln och knappen
            //string parentOfStackpanelReminder = parentOfStackPanel.Name;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (showEditReminder.Visibility == System.Windows.Visibility.Collapsed)
            {
                showEditReminder.Visibility = System.Windows.Visibility.Visible;
                _page = 9;
            }
            FrameworkElement parentOfButton = (FrameworkElement)((Button)sender).Parent;

            Button test = (Button)sender as Button;
            System.Diagnostics.Debug.WriteLine(test.Name);
            for (int i = 0; i < _listWithAllReminders.Count; i++)
            {
                if (test.Name == "r" + _listWithAllReminders[i]._idNum)
                {
                    _listWithAllReminders[i]._editing = true;
                    editReminder.titleForReminder.Text = _listWithAllReminders[i]._title;
                    editReminder.starttid.Text = _listWithAllReminders[i]._startTime.Hour.ToString() + ":" + _listWithAllReminders[i]._startTime.Minute.ToString();
                    editReminder.alarmtid.Text = _listWithAllReminders[i]._alarmTime.Hour.ToString() + ":" + _listWithAllReminders[i]._alarmTime.Minute.ToString();
                    if (_listWithAllReminders[i]._weekDays == "Monday")
                    {
                        editReminder.mondaybox.IsChecked = true;
                    }
                    else if (_listWithAllReminders[i]._weekDays == "Tuesday")
                    {
                        editReminder.tuesdaybox.IsChecked = true;
                    }
                    else if (_listWithAllReminders[i]._weekDays == "Wednesday")
                    {
                        editReminder.wednesdaybox.IsChecked = true;
                    }
                    else if (_listWithAllReminders[i]._weekDays == "Thursday")
                    {
                        editReminder.thursdaybox.IsChecked = true;
                    }
                    else if (_listWithAllReminders[i]._weekDays == "Friday")
                    {
                        editReminder.fridaybox.IsChecked = true;
                    }
                    else if (_listWithAllReminders[i]._weekDays == "Saturday")
                    {
                        editReminder.saturdaybox.IsChecked = true;
                    }
                    else if (_listWithAllReminders[i]._weekDays == "Sunday")
                    {
                        editReminder.sundaybox.IsChecked = true;
                    }                    
                    //writeToFile(_listWithAllReminders);
                }
            }
        }


  

        public void readFromFile()
        {
            _idCount = 0;
            if (File.Exists(@"remindersBin.bin"))
            {
                using (Stream stream = File.Open(@"remindersBin.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    
                    _listWithAllReminders = (List<reminder>)bin.Deserialize(stream);
                    for (int x = 0; x < _listWithAllReminders.Count; x++)
                    {
                        _listWithAllReminders[x]._idNum = _idCount + 1;
                        _idCount++;
                    }
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
            addLabel(infoMonday,"Monday");
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
            readFromFile();
            addLabel(infoTuesday,"Tuesday");
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
            readFromFile();
            addLabel(infoWednesday,"Wednesday");
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
            readFromFile();
            addLabel(infoThursday,"Thursday");
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
            readFromFile();
            addLabel(infoFriday,"Friday");
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
            readFromFile();
            addLabel(infoSaturday,"Saturday");
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
            infoSunday.Children.Clear();
            readFromFile();
            addLabel(infoSunday,"Sunday");
        }



        private void reminder_Click(object sender, RoutedEventArgs e)
        {
            CheckWeekday(_page);
            if (newReminder.Visibility == System.Windows.Visibility.Collapsed)
            {
                newReminder.Visibility = System.Windows.Visibility.Visible;
                _page = 8;
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
