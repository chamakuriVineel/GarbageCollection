using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using System.IO;

namespace MyApp
{ 
    #region Classes
    class Program
    {
        #region methods
        static void Main(string[] args)
        {
            String filePath = "C:\\Users\\Vineel_Chamakuri\\Documents\\DataBaseLog.txt";
            Log Mylog = new Log(filePath);
            String message = "Hi!,This is vineel chamakuri ";
            Mylog.logIt(message);
            Mylog = new Log("sample");
            GC.Collect();
            Console.WriteLine("Press Any key to run using block");
            Console.ReadLine();
            StreamReader streamReader;
            using (streamReader = new StreamReader(filePath))
            {
                String data = streamReader.ReadLine();
                Console.WriteLine("Accesing streamReader insideside the using block.....");
                Console.WriteLine("The data from the file: " + filePath + " is\n" + data);
            }
            Console.WriteLine("Accesing streamReader outside the using block.....");
            try
            {
                Console.WriteLine(streamReader.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR Occured\n" + e.ToString());
            }
            Console.ReadLine();
        }
        #endregion methods
    }
    #endregion Classes
}
