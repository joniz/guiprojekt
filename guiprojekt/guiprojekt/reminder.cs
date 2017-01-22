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
    [Serializable()]
    class reminder : ISerializable
    {
        private string _title;
        private DateTime _startTime;
        private DateTime _alarmTime;
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
        {
            _title = title;
            _startTime = startTime;
            _alarmTime = alarmTime;
            _value = day;
            
            

        }




     



    
    
    }
}
