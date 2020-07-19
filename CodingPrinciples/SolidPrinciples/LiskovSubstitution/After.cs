using System;

namespace CodingPrinciples.LiskovSubstitution
{
    public class InvalidBaseConverter : Converter
    {
        public InvalidBaseConverter(int decimalNumber) : base(decimalNumber)
        { }
        public override string Convert()
        {
            return $"This base type is not a valid base.";
        }
    }
    public class ConverterFactoryV2
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
                return new InvalidBaseConverter(decimalNumber);
            }
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

            Logger.Log("Enter the base type (Ex: 2,8):");
            BaseType baseType = (BaseType)Reader.ReadInteger();

            Converter type = ConverterFactory.Create(baseType, DecimalNumber);

            string result = type.Convert();

            Logger.Log(result);

            Logger.Log("Program is ending..");
        }
    }
}
