using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPrinciples.OpenClosed
{
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

    class After
    {
        public int DecimalNumber { get; set; }
        public Logger Logger { get; set; } = new Logger();
        public Reader Reader { get; set; } = new Reader();

        public void Convert()
        {
            Logger.Log("Program is starting...");

            Logger.Log("Enter the number to convert:");
            DecimalNumber = Reader.ReadInteger();

            Logger.Log("Enter the base type (Ex: 2,8, 16):");
            BaseType baseType = (BaseType)Reader.ReadInteger();

            string result;
            Converter converter;

            switch (baseType)
            {
                case BaseType.Binary:
                    converter = new BinaryConverter(DecimalNumber);
                    result = converter.Convert();
                    break;
                case BaseType.Octal:
                    converter = new OctalConverter(DecimalNumber);
                    result = converter.Convert();
                    break;
                case BaseType.Hexadecimal:
                    converter = new HexadecimalConverter(DecimalNumber);
                    result = converter.Convert();
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
