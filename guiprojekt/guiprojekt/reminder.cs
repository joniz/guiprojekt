using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace guiprojekt
{
    
    class reminder
    {
        private string _title;
        private DateTime _startTime;
        private DateTime _alarmTime;
<<<<<<< HEAD
        private WeekDays _value;
        public enum WeekDays
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday


        }        
        public reminder(string title, DateTime startTime, DateTime alarmTime, WeekDays day)
=======
        private int _valueOfWeekDay;

                
        public reminder(string title, DateTime startTime, DateTime alarmTime, DayOfWeek days)
>>>>>>> c66dc99b726efa331c82c94810b4773bd6b0349d
        {
            _title = title;
            _startTime = startTime;
            _alarmTime = alarmTime;
<<<<<<< HEAD
            _value = day;
=======
            _valueOfWeekDay = (int)days;
>>>>>>> c66dc99b726efa331c82c94810b4773bd6b0349d
            
            

        
        
        }


        public void saveToFile()
        {



        }
       



     



    

    
    }
}
 
