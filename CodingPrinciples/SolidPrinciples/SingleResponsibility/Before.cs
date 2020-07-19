using System;

namespace CodingPrinciples.SingleResponsibility
{
    public enum BaseType
    {
        None = 0,
        Binary = 2,
        Octal = 8
    }

    // Class with the following responsibilities:
        // Writing
        // Reading
        // Logging
        // Converting
    public class Before
    {
        public int DecimalNumber { get; set; }
        public void Convert()
        {
            Console.WriteLine("Program is starting...");

            Console.WriteLine("Enter the number to convert:");
            DecimalNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the base type (Ex: 2,8):");
            BaseType baseType = (BaseType)int.Parse(Console.ReadLine());

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

            Console.WriteLine($"The result is: {result} ");

            Console.WriteLine("Program is ending..");
        }
    }
}
