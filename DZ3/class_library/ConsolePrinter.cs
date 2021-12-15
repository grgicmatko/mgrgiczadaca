using System;
using System.Collections.Generic;
using System.Text;


namespace class_library
{
    public class ConsolePrinter:IPrinter
    {
        ConsoleColor consoleColor = new ConsoleColor();
        public ConsolePrinter(ConsoleColor consoleColor)
        {
            this.consoleColor = consoleColor;
        }
        public void Print(Weather[] weathers)
        {
            Console.ForegroundColor = consoleColor;
            foreach(Weather weather in weathers)
            {
                Console.WriteLine(weather.ToString());
            }     
        }

        


    }
}
