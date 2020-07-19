using System;

namespace CodingPrinciples.LiskovSubstitution
{
    public enum BaseType
    {
        None = 0,
        Binary = 2,
        Octal = 8,
        Hexadecimal = 16
    }
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
    public abstract class Converter
    {
        public int DecimalNumber { get; set; }
        public Converter(int decimalNumber)
        {
            DecimalNumber = decimalNumber;
        }
        public abstract string Convert();
    }

    public class BinaryConverter : Converter
    {
        public BinaryConverter(int decimalNumber)
        : base(decimalNumber)
        { }
        public override string Convert()
        {
            return $"The result is: {System.Convert.ToString(DecimalNumber, 2)}";
        }
    }

    public class OctalConverter : Converter
    {
        public OctalConverter(int decimalNumber)
        : base(decimalNumber)
        { }
        public override string Convert()
        {
            return $"The result is: {System.Convert.ToString(DecimalNumber, 8)}";
        }
    }

    public class HexadecimalConverter : Converter
    {
        public HexadecimalConverter(int decimalNumber) : base(decimalNumber)
        { }
        public override string Convert()
        {
            return $"The result is: {DecimalNumber.ToString("X")}";
        }
    }

    public class ConverterFactoryV1
    {
        public static Converter Create(BaseType baseType, int decimalNumber)
        {
            if (baseType == BaseType.Binary)
            {
                return new BinaryConverter(decimalNumber);
            }
            else if (baseType == BaseType.Octal)
            {
                return new OctalConverter(decimalNumber);
            }
            else if (baseType == BaseType.Hexadecimal)
            {
                return new HexadecimalConverter(decimalNumber);
            }
            else
            {
                return null;
            }
        }
    }

    public class ConverterFactory
    {
        public static Converter Create(BaseType baseType, int decimalNumber)
        {
            try
            {
                return (Converter)
                    Activator.CreateInstance(Type.GetType($"CodingPrinciples.OpenClosed.{baseType}Converter"),
            new object[] { decimalNumber });
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    class Before
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

            Converter type = ConverterFactory.Create(baseType, DecimalNumber);

            string result = type.Convert();

            Logger.Log(result);

            Logger.Log("Program is ending..");
        }
    }

}
