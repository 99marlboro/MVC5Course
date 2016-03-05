using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course
{
    public class Class1 : IDisposable
    {
        public Class1()
        {
            try
            {
                if (true)
                {
                    string kk = string.Empty;

                    ConsoleColor a = new ConsoleColor();
                    
                    switch (a)
                    {
                        case ConsoleColor.Black:
                            break;
                        case ConsoleColor.Blue:
                            break;
                        case ConsoleColor.Cyan:
                            break;
                        case ConsoleColor.DarkBlue:
                            break;
                        case ConsoleColor.DarkCyan:
                            break;
                        case ConsoleColor.DarkGray:
                            break;
                        case ConsoleColor.DarkGreen:
                            break;
                        case ConsoleColor.DarkMagenta:
                            break;
                        case ConsoleColor.DarkRed:
                            break;
                        case ConsoleColor.DarkYellow:
                            break;
                        case ConsoleColor.Gray:
                            break;
                        case ConsoleColor.Green:
                            break;
                        case ConsoleColor.Magenta:
                            break;
                        case ConsoleColor.Red:
                            break;
                        case ConsoleColor.White:
                            break;
                        case ConsoleColor.Yellow:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}