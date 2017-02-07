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
        public System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private static System.Timers.Timer aTimer;

       Style buttonStyle = new Style(typeof(Control));

        
        int _idCount = 0;
        int _page = 0;



       // System.Windows.Media.Brush lawl = new SolidColorBrush(Color.FromRgb(78, 194, 231));
        System.Windows.Media.Brush _brush = new SolidColorBrush(Color.FromRgb(245, 245, 220));
        System.Windows.Media.Brush _brush2 = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        System.Windows.Media.Brush _brush3 = new SolidColorBrush(Color.FromRgb(38, 38, 38));
        System.Windows.Media.Brush _brush4 = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        System.Windows.Thickness _thick = new Thickness(1);
        Brush[] alarmColors = new Brush[3]
        {
            Brushes.Yellow, Brushes.Green, Brushes.Red

        };

        public MainWindow()
        {

            readFromFile();
            
            string user = Environment.UserName;
            string path = @"C:\Users\" + user + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\startupreminder.bat";
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
            MyNotifyIcon.Icon = new System.Drawing.Icon("C:\\Users\\Jonathan\\Documents\\GitHub\\guiprojekt\\guiprojekt\\guiprojekt\\ReminderIcon.ico", 16, 16);
            MyNotifyIcon.MouseClick += MyNotifyIcon_MouseDoubleClick;
            MyNotifyIcon.BalloonTipClicked += showAlarm;
            aTimer = new System.Timers.Timer(10000);
            aTimer.Start();
            aTimer.Elapsed += alarm;
            loadCurrentDay();
         
            if(args.Length > 1)
            {
                 if(args[1] == "startup")
                 {
                 this.WindowState = System.Windows.WindowState.Minimized;
                 Window_Deactivated();                
                 }

            } 
        }
        void MyNotifyIcon_MouseDoubleClick(object sender, EventArgs e)
        {
            
            this.WindowState = WindowState.Normal;
            
            MyNotifyIcon.Visible = false;
            this.ShowInTaskbar = true;
            this.Focus();
        }
      
        

        public void showAlarm(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;

            MyNotifyIcon.Visible = false;
            this.ShowInTaskbar = true;
            this.Focus();
            
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            Button checkButton = (Button)sender as Button;

            int pos = 0;
            for (int i = 0; i < _listWithAllReminders.Count; i++)
            {
                if ("r" + _listWithAllReminders[i]._idNum.ToString() == checkButton.Name)
                {
                    pos = i;
                }
            }
            DateTime test = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _listWithAllReminders[pos]._alarmTime.Hour, _listWithAllReminders[pos]._alarmTime.Minute, 0);
            _listWithAllReminders[pos]._alarmTime = test;
            _listWithAllReminders[pos]._alarmStatus = 1;
            
            Model.writeToFile(_listWithAllReminders);
            //loadCurrentDay();



        }

        private void newReminder_Click(object sender, RoutedEventArgs e)
        {
            scrollBar.Visibility = Visibility.Hidden;
            header.FontSize = 40;
            header.Content = "Lägg till påminnelse";
            hidePreviousDay(_page);
            _page = 8;
            newReminder.Visibility = System.Windows.Visibility.Visible;
        }

        private void hidePreviousDay(int page)
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
            int value = 0;
            for (int x = 0; x < _listWithAllReminders.Count; x++)
            {
                DateTime currentTime = DateTime.Now;
                
                
                
                if (_listWithAllReminders[x]._startTime.Hour == DateTime.Now.Hour && _listWithAllReminders[x]._startTime.Minute == DateTime.Now.Minute)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        loadCurrentDay();
                    });

                }
                if(_listWithAllReminders[x]._weekDays == currentTime.DayOfWeek.ToString() && currentTime.Hour >= _listWithAllReminders[x]._alarmTime.Hour && currentTime.Minute >= _listWithAllReminders[x]._alarmTime.Minute && _listWithAllReminders[x]._alarmStatus == 0)

                {
                    
                    _listWithAllReminders[x]._alarmStatus = 2; //alarmstatus
                    Model.writeToFile(_listWithAllReminders);
                    this.Dispatcher.Invoke(() =>
                    {
                        loadCurrentDay();
                    });
                    
                    ok = true;
                    value = x;
                }
            }
            if (ok)
            {
                this.Dispatcher.Invoke(() =>
                {

                    if (this.WindowState == System.Windows.WindowState.Minimized)
                    {
                        MyNotifyIcon.BalloonTipTitle = "ALARM";
                        MyNotifyIcon.BalloonTipText = "Du har ett alarm";
                        MyNotifyIcon.ShowBalloonTip(400);
                    }
                    else
                    {
                        this.Focus();
                        System.Windows.Forms.MessageBox.Show("Du har ett alarm");


                    }

                });
            }

           
        }

        private void loadCurrentDay()
        {
            if (_page != 8 && _page != 9)
            {
                switch (Convert.ToInt32(DateTime.Now.DayOfWeek))
                {
                    case 0: sunday_Click(); break;
                    case 1: monday_Click(); break;
                    case 2: tuesday_Click(); break;
                    case 3: wednesday_Click(); break;
                    case 4: thursday_Click(); break;
                    case 5: friday_Click(); break;
                    case 6: saturday_Click(); break;
                }
            }
                
        }

        private void addLabel(StackPanel panel,String day)
        {
           
            buttonStyle.Setters.Add(new Setter(BackgroundProperty, null));
            buttonStyle.Setters.Add(new Setter(BorderBrushProperty, null));
           
            for (int x = 0; x < _listWithAllReminders.Count; x++)
            {
                
                string test = _listWithAllReminders[x]._weekDays;
                if (test == day)
                {
                    System.Windows.Media.Brush lawl = new SolidColorBrush(Color.FromRgb(78, 194, 231));
                    Label text = new Label();
                    CheckBox checkBox = new CheckBox();
                    Button deleteButton = new Button();
                    Button editButton = new Button();
                    Button checkButton = new Button();
                    checkButton.IsEnabled = false;
                    
                    StackPanel stack = new StackPanel();
                    
                    stack.Orientation = Orientation.Horizontal;
                    checkButton.Content = "Checka av";
                    deleteButton.Content = "Ta bort";
                    editButton.Content = "Redigera";
                   
                    deleteButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(deleteButton_Click));
                    editButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(editButton_Click));

                    checkButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(CheckBox_Checked));

                    text.FontSize = 15;
                    text.Background =  alarmColors[_listWithAllReminders[x]._alarmStatus];
                    text.Width = 257;
                    text.FontFamily = new FontFamily("Rockwell Bold");
                    text.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    text.BorderThickness = _thick;
                    text.Content = "Titel: " + _listWithAllReminders[x]._title + Environment.NewLine + "Starttid: " + _listWithAllReminders[x]._startTime.ToShortTimeString() + Environment.NewLine + "Alarmtid: " + _listWithAllReminders[x]._alarmTime.ToShortTimeString();
                    text.Name = "r" + _listWithAllReminders[x]._idNum.ToString();
                    checkButton.Name = "r" + _listWithAllReminders[x]._idNum.ToString();
                    editButton.Name = "r" + _listWithAllReminders[x]._idNum.ToString();
                    deleteButton.Name = "r" + _listWithAllReminders[x]._idNum.ToString();

                    if (_listWithAllReminders[x]._startTime.Hour <= DateTime.Now.Hour && _listWithAllReminders[x]._startTime.Minute <= DateTime.Now.Minute && _listWithAllReminders[x]._alarmStatus == 0 || _listWithAllReminders[x]._alarmStatus == 2 && _listWithAllReminders[x]._weekDays == DateTime.Now.DayOfWeek.ToString())
                    {
                        checkButton.IsEnabled = true;


                    }
                    


                    stack.Children.Add(text);
                    
                    stack.Children.Add(editButton);
                    stack.Children.Add(deleteButton);

                    stack.Children.Add(checkButton);


                    panel.Children.Add(stack);
                    
                }
            }
        }
     

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Endast detta som krävs, Vi behöver inte göra någon Children.Remove med tanke på C#:s GC.

            FrameworkElement parentOfButton = (FrameworkElement)((Button)sender).Parent;
            
            Button test = (Button)sender as Button;
            
            for (int i = 0; i < _listWithAllReminders.Count; i++)
            {
                if (test.Name == "r" + _listWithAllReminders[i]._idNum)
                {
                    parentOfButton.Visibility = Visibility.Collapsed;
                    _listWithAllReminders.RemoveAt(i);
                    Model.writeToFile(_listWithAllReminders);
                }
            }

          }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            
            hidePreviousDay(_page);
            if (showEditReminder.Visibility == System.Windows.Visibility.Collapsed)
            {
                scrollBar.Visibility = Visibility.Hidden;
                showEditReminder.Visibility = System.Windows.Visibility.Visible;
                _page = 9;
                

            }
            FrameworkElement parentOfButton = (FrameworkElement)((Button)sender).Parent;

            Button test = (Button)sender as Button;
            

            for (int i = 0; i < _listWithAllReminders.Count; i++)
            {
                if (test.Name == "r" + _listWithAllReminders[i]._idNum)
                {
                   

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
                    _listWithAllReminders[i]._editing = true;
                    editReminder.titleForReminder.Text = _listWithAllReminders[i]._title;

                    editReminder.starttid.Text = _listWithAllReminders[i]._startTime.ToShortTimeString();
                    editReminder.alarmtid.Text = _listWithAllReminders[i]._alarmTime.ToShortTimeString();


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
                        if (_listWithAllReminders[x]._alarmTime.Date != DateTime.Now.Date)
                        {
                            _listWithAllReminders[x]._alarmStatus = 0;
                        }
                    }
                 }
            }
        }


        private void monday_Click(object sender = null, RoutedEventArgs e = null)

        {
            hidePreviousDay(_page);
           
                infoMonday.Visibility = System.Windows.Visibility.Visible;
                _page = 1;
                scrollBar.Visibility = Visibility.Visible;
                scrollBar.ScrollToTop();
                header.FontSize = 50;
                header.Content = "Måndag";
            infoMonday.Children.Clear();
            readFromFile();
            addLabel(infoMonday,"Monday");
        }

        private void tuesday_Click(object sender = null, RoutedEventArgs e = null)
        {
            hidePreviousDay(_page);
            if (infoTuesday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoTuesday.Visibility = System.Windows.Visibility.Visible;
                _page = 2;
                scrollBar.Visibility = Visibility.Visible;
                scrollBar.ScrollToTop();
                header.FontSize = 50;
                header.Content = "Tisdag";
            }
            else
            {
                infoTuesday.Visibility = System.Windows.Visibility.Hidden;
            }
            infoTuesday.Children.Clear();
            readFromFile();
            addLabel(infoTuesday,"Tuesday");
        }

        private void wednesday_Click(object sender = null, RoutedEventArgs e = null)
        {
            hidePreviousDay(_page);
            if (infoWednesday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoWednesday.Visibility = System.Windows.Visibility.Visible;
                _page = 3;
                scrollBar.Visibility = Visibility.Visible;
                scrollBar.ScrollToTop();
                header.FontSize = 50;
                header.Content = "Onsdag";
            }
            else
            {
                infoWednesday.Visibility = System.Windows.Visibility.Hidden;
            }
            infoWednesday.Children.Clear();
            readFromFile();
            addLabel(infoWednesday,"Wednesday");
        }

        private void thursday_Click(object sender = null, RoutedEventArgs e = null)
        {
            hidePreviousDay(_page);
            if (infoThursday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoThursday.Visibility = System.Windows.Visibility.Visible;
                _page = 4;
                scrollBar.Visibility = Visibility.Visible;
                scrollBar.ScrollToTop();
                header.FontSize = 50;
                header.Content = "Torsdag";
            }
            else
            {
                infoThursday.Visibility = System.Windows.Visibility.Hidden;
            }
            infoThursday.Children.Clear();
            readFromFile();
            addLabel(infoThursday,"Thursday");
        }

        private void friday_Click(object sender = null, RoutedEventArgs e = null)
        {
            hidePreviousDay(_page);
            if (infoFriday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoFriday.Visibility = System.Windows.Visibility.Visible;
                _page = 5;
                scrollBar.Visibility = Visibility.Visible;
                scrollBar.ScrollToTop();
                header.FontSize = 50;
                header.Content = "Fredag";
            }
            else
            {
                infoFriday.Visibility = System.Windows.Visibility.Hidden;
            }
            infoFriday.Children.Clear();
            readFromFile();
            addLabel(infoFriday,"Friday");
        }

        private void saturday_Click(object sender = null, RoutedEventArgs e = null)
        {
            hidePreviousDay(_page);
            if (infoSaturday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoSaturday.Visibility = System.Windows.Visibility.Visible;
                _page = 6;
                scrollBar.Visibility = Visibility.Visible;
                scrollBar.ScrollToTop();
                header.FontSize = 50;
                header.Content = "Lördag";
            }
            else
            {
                infoSaturday.Visibility = System.Windows.Visibility.Hidden;
            }
            infoSaturday.Children.Clear();
            readFromFile();
            addLabel(infoSaturday,"Saturday");
        }

        private void sunday_Click(object sender = null, RoutedEventArgs e = null)
        {
            hidePreviousDay(_page);
            if (infoSunday.Visibility == System.Windows.Visibility.Hidden)
            {
                infoSunday.Visibility = System.Windows.Visibility.Visible;
                _page = 7;
                scrollBar.Visibility = Visibility.Visible;
                scrollBar.ScrollToTop();
                header.FontSize = 50;
                header.Content = "Söndag";
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
            hidePreviousDay(_page);
            if (newReminder.Visibility == System.Windows.Visibility.Collapsed)
            {
                newReminder.Visibility = System.Windows.Visibility.Visible;
                _page = 8;
            }
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
