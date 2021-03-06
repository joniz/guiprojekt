﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace guiprojekt
{
    [Serializable]
    public class reminder
    {
        public string _title { get; set; }
        public DateTime _startTime { get; set; }
        public DateTime _alarmTime { get; set; }
        public int _idNum;
        public string _weekDays { get; set; }
        public bool _editing { get; set; }
        public bool _isEnabled;
        public int _alarmStatus { get; set; }


                
        public reminder(string title, string startTime, string alarmTime, string day)

        {
            _title = title;
            _startTime = Convert.ToDateTime(startTime);
            _alarmTime = Convert.ToDateTime(alarmTime);
            _weekDays = day;
            _editing = false;
            _isEnabled = false;
            
            _alarmStatus = 0; // 0 = ingenting, 1 = checkad, 2 = alarm
        
        }
        public static void writeToFile(List<reminder> reminderList)
        {

            using (Stream stream = File.Open("C:\\Users\\" + Environment.UserName + "\\remindersBin.bin", FileMode.Create))
            {

                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, reminderList);
            }

            /*  outputFile.WriteLine("");
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
               */
        }
        public List<reminder> readFromFile()
        {
            if (File.Exists(@"C:\Users\" + Environment.UserName + "\\remindersBin.bin"))
            {
                using (Stream stream = File.Open(@"C:\Users\" + Environment.UserName + "\\remindersBin.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    List<reminder> _listWithAllReminders = (List<reminder>)bin.Deserialize(stream);
                    return _listWithAllReminders;
                    
                }
               



            }
            return null;
        }
















        }
    }
 
