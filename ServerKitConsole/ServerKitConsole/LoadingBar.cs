using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerKitConsole
{
    class LoadingBar
    {
        public static void LoadWorking(string text,int count)
        {
            int i = 0;
            ConsoleSpiner spin = new ConsoleSpiner();
            Console.Write(text+" ...");
            while (i<count)
            {
                Task.Delay(100).Wait();
                spin.Turn();
                i++;
            }
        }
    }
    public class ConsoleSpiner
    {
        int counter;
        public ConsoleSpiner()
        {
            counter = 0;
        }
        public void Turn()
        {
            counter++;
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }


    }
}
