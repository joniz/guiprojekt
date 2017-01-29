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
using System.Threading;

namespace guiprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //addReminder reminder = new addReminder();

        

        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private static System.Timers.Timer aTimer;

        
        int _weekday = 1;
       




        List<reminder> _reminderListForThreads = new List<reminder>(); //ska funka som vector, då vector i c# är en matematisk vektor
        int _page = 0;
        string _alarms;
        string _alarms2; //testvariabel for now, tas bort senare om det går annars döps om
        System.Windows.Media.Brush _brush = new SolidColorBrush(Color.FromRgb(245, 245, 220));
        System.Windows.Media.Brush _brush2 = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        System.Windows.Media.Brush _brush3 = new SolidColorBrush(Color.FromRgb(38, 38, 38));
        System.Windows.Media.Brush _brush4 = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        System.Windows.Thickness _thick = new Thickness(1);
        
        public MainWindow()
        {
            InitializeComponent();
            MyNotifyIcon = new System.Windows.Forms.NotifyIcon();
            MyNotifyIcon.Icon = new System.Drawing.Icon(@"ReminderIcon.ico", 16, 16);
            MyNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MyNotifyIcon_MouseDoubleClick);
            MyNotifyIcon.BalloonTipClicked += CheckAlarm;
            aTimer = new System.Timers.Timer(1000);
            aTimer.Start();
            aTimer.Elapsed += OnTimedEvent;
            
            //Thread aalarms = new Thread(new ThreadStart(AlarmThread)); //skapar threaden med funktionen AlarmThread, men startar den inte
            //aalarms.Start();
        }
        void MyNotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            this.WindowState = WindowState.Normal;
            
            MyNotifyIcon.Visible = false;
            this.ShowInTaskbar = true;
            this.Focus();
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.ShowInTaskbar = false;
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
            bool ok = false;
           
            System.Diagnostics.Debug.WriteLine(System.DateTime.Now.DayOfWeek);
            System.Diagnostics.Debug.WriteLine(DateTime.Now.Minute);
            if (_reminderListForThreads.Count != 0)
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

        private void readFromFile(string day, StackPanel panel)
        {
            _reminderListForThreads.Clear();
            if (File.Exists(@"reminders.txt"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"reminders.txt");
                _alarms = "";
                _alarms2 = "";
                int count = checkNumberOfLines();

                for (int x = 0; x < count; x++)
                {
                    List<DayOfWeek> days = new List<DayOfWeek>(); //listan med vilka dagar en viss reminder ska vara på
                    string read = file.ReadLine();
                    if (read != "")
                    {
                        string title = read.Split('|')[0];
                        string start = read.Split('|')[1];
                        string alarm = read.Split('|')[2];
                        _alarms2 = read.Split('|')[2];

                        
                        int y = 3;

                        while (read.Split('|')[y] != "")
                        {
                            if (read.Split('|')[y] == day)
                            {
                                Label label = new Label();
                                label.Content ="Titel: "  + title + " Starttid: " + start + " Alarmtid: " + alarm;
                                addLabel(panel, label);
                                
                                alarm = alarm + "|";
                                _alarms += alarm;
                                
                                
                            }
                            days.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), read.Split('|')[y])); // lägger till dagen i en lista
                            y++;
                            
                            
                        }
                        _reminderListForThreads.Add(new reminder(title,start,_alarms2,days)); //lägger till remindern i en lista med reminders
                    }
                }
            }
        }

        private void alarm(string alarms)
        {
            if (File.Exists(@"reminders.txt"))
            {
                DateTime currentTime = DateTime.Now;
                string time = currentTime.Hour + ":" + currentTime.Minute;
                int x = 0;
                while (alarms.Split('|')[x] != "")
                {
                    string alarm = alarms.Split('|')[x]; //samma variabelnamn som funktion
                    if (alarm == time)
                    {
                        System.Windows.Forms.MessageBox.Show("ALARM!!!");
                    }
                    x++;
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
            readFromFile("Monday", infoMonday);
            alarm(_alarms);
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
            readFromFile("Tuesday", infoTuesday);
            alarm(_alarms);
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
            readFromFile("Wednesday", infoWednesday);
            alarm(_alarms);
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
            readFromFile("Thursday", infoThursday);
            alarm(_alarms);
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
            readFromFile("Friday", infoFriday);
            alarm(_alarms);
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
            readFromFile("Saturday", infoSaturday);
            alarm(_alarms);
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

        private void Window_Deactivated(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                MyNotifyIcon.Visible = true;
                MyNotifyIcon.BalloonTipTitle = "Minimize Sucessful";
                MyNotifyIcon.BalloonTipText = "Minimized the app ";
                MyNotifyIcon.ShowBalloonTip(400);
                

                infoSunday.Children.Clear();
                readFromFile("Sunday", infoSunday);
                //alarm(_alarms);
            }
        }


    }
}