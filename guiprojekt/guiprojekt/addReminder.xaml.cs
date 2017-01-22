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
        
        public addReminder()
        {
            InitializeComponent();
 
    
        }
        public void addReminderToFile(){
            


        }
        /*private void mondaybox_CheckedChanged(object sender, EventArgs e)
        {
            if ((bool)mondaybox.IsChecked)
            { }

            else
                mondaybox.Foreground = Color.Red;
        }
    */
        private void createReminder_Click(object sender, RoutedEventArgs e)
        {
            string reminderTitle = titleForReminder.Text;
            

        }

        
    
    
    }
    








}
