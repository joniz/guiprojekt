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
    class reminder
    {
        public string _title { get; set; }
        public DateTime _startTime { get; set; }
        public DateTime _alarmTime { get; set; }

        public List<DayOfWeek> _weekDays { get; set; }
       


                
        public reminder(string title, string startTime, string alarmTime, List<DayOfWeek> days)

        {
            _title = title;
            _startTime = Convert.ToDateTime(startTime);
            _alarmTime = Convert.ToDateTime(alarmTime);
            _weekDays = days;

            
                 
        
        }



    public void saveToFile()
        {


        }


        
       



     



    

    
    }
}
 
