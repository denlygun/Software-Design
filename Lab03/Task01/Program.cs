using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Emit;

namespace Task01
{
    class Logger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LOG: " + message);
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + message);
            Console.ResetColor();
        }

        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARNING: " + message);
            Console.ResetColor();
        }
    }

    class FileWriter
    {
        private string filePath;

        public FileWriter(string path)
        {
            filePath = path;
        }

        public void Write(string message)
        {
            File.AppendAllText(filePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }

    class FileLoggerAdapter : Logger
    {
        private FileWriter fileWriter;

        public FileLoggerAdapter(string filePath)
        {
            fileWriter = new FileWriter(filePath);
        }

        public new void Log(string message)
        {
            fileWriter.WriteLine("LOG: " + message);
        }

        public new void Error(string message)
        {
            fileWriter.WriteLine("ERROR: " + message);
        }

        public new void Warn(string message)
        {
            fileWriter.WriteLine("WARNING: " + message);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Logger consoleLogger = new Logger();
            consoleLogger.Log("Це інформаційне повідомлення.");
            consoleLogger.Warn("Це попередження.");
            consoleLogger.Error("Це помилка.");

            FileLoggerAdapter fileLogger = new FileLoggerAdapter("D:\\КПЗ\\labs\\Lab03\\Task01\\log.txt");
            fileLogger.Log("Це інформаційне повідомлення у файл.");
            fileLogger.Warn("Це попередження у файл.");
            fileLogger.Error("Це помилка у файл.");

            Console.WriteLine("Логування завершено. Перевірте файл log.txt");
            Console.ReadKey();
        }
    }

}
