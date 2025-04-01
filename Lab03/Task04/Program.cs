using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using GSF.IO;

namespace Task04
{

    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class SmartTextReader
    {
        public string FilePath { get; private set; }

        public SmartTextReader(string filePath)
        {
            FilePath = filePath;
        }
        public virtual char[][] ReadFile()
        {
            var lines = File.ReadAllLines(FilePath);
            char[][] result = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }
            return result;
        }
    }

    public class SmartTextChecker : SmartTextReader
    {
        private SmartTextReader _realReader;

        public SmartTextChecker(SmartTextReader realReader) : base(realReader.FilePath)
        {
            _realReader = realReader;
        }

        public override char[][] ReadFile()
        {
            Console.WriteLine("Opening file...");
            var result = _realReader.ReadFile();
            Console.WriteLine($"File read successfully. Total lines: {result.Length}, Total characters: {GetTotalCharacters(result)}");
            Console.WriteLine("File closed.");
            return result;
        }

        private int GetTotalCharacters(char[][] data)
        {
            int totalChars = 0;
            foreach (var line in data)
            {
                totalChars += line.Length;
            }
            return totalChars;
        }
    }

    public class SmartTextReaderLocker : SmartTextReader
    {
        private Regex _accessRegex;

        public SmartTextReaderLocker(string filePath, string pattern) : base(filePath)
        {
            _accessRegex = new Regex(pattern);
        }
        public override char[][] ReadFile()
        {
            if (_accessRegex.IsMatch(FilePath))
            {
                Console.WriteLine("Access denied!");
                return null;
            }
            else
            {
                return base.ReadFile();
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            string filePath = "D:\\КПЗ\\labs\\Lab03\\Task04\\test.txt"; 

            SmartTextReader realReader = new SmartTextReader(filePath);

            SmartTextChecker checker = new SmartTextChecker(realReader);
            var result1 = checker.ReadFile();

            SmartTextReaderLocker locker = new SmartTextReaderLocker(filePath, "restricted");
            var result2 = locker.ReadFile();

            Console.ReadKey();
        }
    }


}
