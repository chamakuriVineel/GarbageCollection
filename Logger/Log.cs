using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    
    public class Log: IDisposable
    {
        //managed resource reference variable;
        private String filePath;
        //unmanged object reference variable;
        private StreamWriter streamWriter;
        public Log(String filePath)
        {
            this.filePath = filePath;
            streamWriter = new StreamWriter(filePath);
        }
        public bool logIt(String message)
        {
            try
            {
                streamWriter.Flush();
                streamWriter.WriteLine(message);
                Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()+ "Can't write the message to the log file");
                return false;
            }
            return true;
        }
        public void Dispose()
        {
            DisposeHelper(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void DisposeHelper(bool disposing)
        {
            Console.WriteLine("DisposeHelper called with "+disposing+" argument");
            if (disposing)
            {
                Console.WriteLine("managed resources are disposed");
            }
            streamWriter.Close();
            Console.WriteLine("unmanaged resources are disposed"); 
        }
        ~Log()
        {
            Console.WriteLine("Call from the finalize method");
            DisposeHelper(false);
        }

        
    }
}
