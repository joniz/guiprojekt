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
    class ReminderList
    {
        List<reminder> _reminderList = new List<reminder>();

        public void addReminder()
        {

        }


        public void writeToFile(reminder remObj)
        {
            using (Stream stream = File.Open("remindersBin.bin", FileMode.Create))
            {

                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, remObj);


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
    }
}
