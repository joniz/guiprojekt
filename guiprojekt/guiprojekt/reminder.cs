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
        private int _value;

                
        public reminder(string title, DateTime startTime, DateTime alarmTime, DayOfWeek days)
        {
            _title = title;
            _startTime = startTime;
            _alarmTime = alarmTime;
            _value = (int)days;
            
            

        }




     



    
    
    }
}
