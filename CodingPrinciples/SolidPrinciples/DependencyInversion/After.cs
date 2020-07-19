using System;
using System.IO;

namespace CodingPrinciples.DependencyInversion.After
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IReader
    {
        int ReadInteger();
    }

    public class Reader : IReader
    {
        public int ReadInteger()
        {
            return int.Parse(Console.ReadLine());
        }
    }

    public class TextFileLogger : ILogger
    {
        public void Log(string message)
        {
            using (StreamWriter writer = File.AppendText("logFile.txt"))
            {
                writer.WriteLine(message);
            }
        }
    }
    class After
    {
        public ILogger Logger { get; set; }
        public IReader Reader { get; set; }

        public After(ILogger logger, IReader reader)
        {
            Logger = logger;
            Reader = reader;
        }
    }

    class Client
    {
        void Main()
        {
            var converter = new After(new Logger(), new Reader());
            var converterWithLogger = new After(new TextFileLogger(), new Reader());
        }
    }
}
