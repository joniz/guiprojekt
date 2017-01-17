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
        private int _valueOfWeekDay;

                
        public reminder(string title, DateTime startTime, DateTime alarmTime, DayOfWeek days)
        {
            _title = title;
            _startTime = startTime;
            _alarmTime = alarmTime;
            _valueOfWeekDay = (int)days;
            
            

        
        
        }

<<<<<<< HEAD

=======
>>>>>>> 701bc6a501cb0fe36be5c20491f52cdfc50638b3
        public void saveToFile()
        {



        }
       



     



    

    
    }
}
 
