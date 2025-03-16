using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public sealed class Authenticator
    {
        private static readonly object _lock = new object();
        private static Authenticator _instance;

        private Authenticator() { }

        public static Authenticator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Authenticator();
                        }
                    }
                }
                return _instance;
            }
        }

        public bool Login(string username, string password)
        {
            return username == "admin" && password == "password123";
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Authenticator auth1 = Authenticator.Instance;
            Authenticator auth2 = Authenticator.Instance;

            Console.WriteLine("Перевірка, чи це один і той самий екземпляр: " + (auth1 == auth2));

            bool isAuthenticated = auth1.Login("admin", "password123");
            Console.WriteLine("Аутентифікація: " + (isAuthenticated ? "Успішна" : "Неуспішна"));

            Console.ReadKey();
        }
    }
}
