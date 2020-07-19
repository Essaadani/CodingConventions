using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPrinciples.SingleResponsibility
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

    public class After
    {
        public int DecimalNumber { get; set; }
        public Logger Logger { get; set; } = new Logger();
        public Reader Reader { get; set; } = new Reader();
        public void Convert()
        {
            Logger.Log("Program is starting...");

            Logger.Log("Enter the number to convert:");
            DecimalNumber = Reader.ReadInteger();

            Logger.Log("Enter the base type (Ex: 2,8):");
            BaseType baseType = (BaseType)Reader.ReadInteger();

            string result;

            switch (baseType)
            {
                case BaseType.Binary:
                    result = System.Convert.ToString(DecimalNumber, 2);
                    break;
                case BaseType.Octal:
                    result = System.Convert.ToString(DecimalNumber, 8);
                    break;
                default:
                    result = "No base found!";
                    break;
            }

            Logger.Log(result);

            Logger.Log("Program is ending..");
        }
    }
}
