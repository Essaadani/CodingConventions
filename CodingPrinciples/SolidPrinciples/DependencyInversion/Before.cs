using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPrinciples.DependencyInversion
{
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Reader
    {
        public int ReadInteger()
        {
            return int.Parse(Console.ReadLine());
        }
    }

    class Before
    {
        public Logger Logger { get; set; } = new Logger();
        public Reader Reader { get; set; } = new Reader();
    }
}
