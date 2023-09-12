using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Hjemme_Opgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System system = new System();
            while (true) {
                system.start();
            }
        }
    }

    class System {
        
        private string OrderPath = Directory.GetCurrentDirectory();

        public void start()
        {
            int billetPris = 130;
            Console.Clear();
            Console.WriteLine("1 Billet Koster 130KR\n");
            Console.WriteLine("Indtast Venligst hvor mange penge du har til billetter!");
            int.TryParse(Console.ReadLine(), out int antalPenge);
            Console.WriteLine("Indtast Venligst hvor mange billetter du ønsker!");
            int.TryParse(Console.ReadLine(), out int billetter);
            if (billetPris * billetter <= antalPenge)
            {
                int pris = billetPris * billetter;
                int Rpenge = antalPenge - pris;
                int Abilletter = billetter;
                string OrdereNr = CreateOrder(pris, Rpenge, Abilletter);
                Console.WriteLine("\nDit Ordere Nr: " + OrdereNr);
                Console.WriteLine("\nPris: " + pris + "\nResterende penge: " + Rpenge + "\nAntal billetter købt: " + Abilletter);
                Console.WriteLine("\nDin ordre er nu bestilt!");
            } else {
                Console.WriteLine("\nBeløb overskredet!");
            }
            Console.ReadKey();
        }

        private string CreateOrder(int pris, int Rpenge, int Abilletter)
        {
            string orderN = orderNumber();
            var OFile = File.Create(Path.Combine(OrderPath, orderN));
            OFile.Close();
            string[] addData = new string[] { "Pris: " + pris + "\nResterende penge: " + Rpenge + "\nAntal billetter købt: " + Abilletter};
            File.AppendAllLines(Path.Combine(OrderPath, orderN), addData);
            return orderN;
        }

        private string orderNumber()
        {
            bool notExists = true;
            Random rnd = new Random();
            do
            {
                int num = rnd.Next(100000, 1000000);
                if (!File.Exists(OrderPath + "order_" + num + ".txt"))
                {
                    return "order_" + num + ".txt";
                }
            } while (notExists);
            return "";
        }

    }
}
