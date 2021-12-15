using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace class_library
{
    public class FilePrinter:IPrinter
    {
        private string fileName;
        public FilePrinter(string fileName)
        {
            this.fileName = fileName;
        }
        public void Print(Weather[] weathers)
        {
            using (StreamWriter sw = new StreamWriter(this.fileName))
            {
                foreach(Weather weather in weathers)
                {
                    sw.WriteLine(weather.ToString());
                }
            }

        }

    }
}
