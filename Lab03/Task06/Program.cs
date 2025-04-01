using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class LightHTML
    {
        private StringBuilder htmlContent;

        public LightHTML()
        {
            htmlContent = new StringBuilder();
        }

        public void AddElement(string tag, string content)
        {
            htmlContent.AppendLine($"<{tag}>{content}</{tag}>");
        }

        public string GenerateHtml(string text)
        {
            var lines = text.Split(new[] { '\n' }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (i == 0)  
                {
                    AddElement("h1", line);
                }
                else if (lines[i].StartsWith(" "))  
                {
                    AddElement("blockquote", lines[i].TrimStart());
                }
                else if (line.Length < 20)  
                {
                    AddElement("h2", line);
                }
                else  
                {
                    AddElement("p", line);
                }
            }

            return htmlContent.ToString();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var lighthtml = new LightHTML();

            string bookText = "Це заголовок\n   Це цитата\nТекст з більше ніж 20 символів\nІ ще один текст\n";

            long memoryBefore = GC.GetTotalMemory(true);

            string htmlOutput = lighthtml.GenerateHtml(bookText);

            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine("Generated HTML:\n" + htmlOutput);
            Console.WriteLine($"Memory used: {memoryAfter - memoryBefore} bytes");
            Console.ReadKey();
        }
    }


}
