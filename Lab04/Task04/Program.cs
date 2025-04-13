using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task04
{
    public interface ILoadImageStrategy
    {
        void LoadImage(string href);
    }

    public class FileSystemImageStrategy : ILoadImageStrategy
    {
        public void LoadImage(string href)
        {
            if (File.Exists(href))
            {
                Console.WriteLine($"Завантажено зображення з файлової системи: {href}");
            }
            else
            {
                Console.WriteLine($"Помилка: Файл не знайдено за шляхом {href}");
            }
        }
    }

    public class NetworkImageStrategy : ILoadImageStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Завантажено зображення з мережі за адресою: {href}");
        }
    }

    public class Image
    {
        private ILoadImageStrategy _loadImageStrategy;

        public Image(ILoadImageStrategy loadImageStrategy)
        {
            _loadImageStrategy = loadImageStrategy;
        }

        public void Load(string href)
        {
            _loadImageStrategy.LoadImage(href);
        }

        public void SetStrategy(ILoadImageStrategy loadImageStrategy)
        {
            _loadImageStrategy = loadImageStrategy;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            ILoadImageStrategy fileSystemStrategy = new FileSystemImageStrategy();
            ILoadImageStrategy networkStrategy = new NetworkImageStrategy();

            Image image = new Image(fileSystemStrategy);

            string filePath = "D:\\logo.jpg";
            image.Load(filePath);

            image.SetStrategy(networkStrategy);
            string networkUrl = "https://images.prom.ua/2987667453_w600_h600_2987667453.jpg";
            image.Load(networkUrl);

            Console.ReadKey();
        }
    }
}
