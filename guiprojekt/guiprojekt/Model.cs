using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace guiprojekt
{
   public class Model
    {
        public static void writeToFile(List<reminder> reminderList)
        {
            
        
            using (Stream stream = File.Open("remindersBin.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, reminderList);
            }
        }
    public Model()
        {


        }
        public static bool timeTest(DateTime startTime, DateTime alarmTime)
        {
            if (startTime.Hour > alarmTime.Hour)
            {
                return false;
            }
            else if (startTime.Hour == alarmTime.Hour)
            {
                if (startTime.Minute >= alarmTime.Minute)
                {
                    return false;
                }
                else
                {

                    return true;
                }
            }


            else return true;


        }
        public static bool checkBoxTest(DateTime startTime)
        {
            if (startTime.Hour > DateTime.Now.Hour)
            {
                return false;
            }
            else if (startTime.Hour == DateTime.Now.Hour)
            {
                if (startTime.Minute > DateTime.Now.Minute)
                {
                    return false;
                }
                else return true;

            }
            else return true;



        }

    }




    }

