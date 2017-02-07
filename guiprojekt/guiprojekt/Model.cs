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


    }




    }

