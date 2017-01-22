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
        private TimeSpan _startTime;
        private TimeSpan _alarmTime;
        private int _valueOfWeekDay;

                
        public reminder(string title, TimeSpan startTime, TimeSpan alarmTime, DayOfWeek days)
        {
            _title = title;
            _startTime = startTime;
            _alarmTime = alarmTime;
            _valueOfWeekDay = (int)days;
            
            

        
        
        }


        public void saveToFile()
        {



        }
       



     



    

    
    }
}
 
