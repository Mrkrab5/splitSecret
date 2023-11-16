using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splitSecret
{
    internal class Shamir
    {

        public Shamir() { }

        //метод для формирования простых чисел
        static private int Simple(int a)
        {
            int n = 0;

            Random rnd = new Random();

            bool good = false;

            while (!good)
            {
                //Ограничение в целях рациональности
                n = rnd.Next(a, 1000);

                int count = 0;

                for (int i = 2; i < n / 2; i++)
                {
                    if (n % i == 0)
                        count++;
                }

                if (count == 0)
                    good = true;
            }

            return n;
        }

        static public string Check(string massenge)
        {
            string bigReg = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ", result = "";
            int S = bigReg.IndexOf(massenge.ToUpper().Substring(0, 1)), p, a1, a2;
            Random rnd = new Random();
            int[,] array = new int[5, 2];

            a1 = rnd.Next(0, 1000); a2 = rnd.Next(0, 1000);

            p = Simple(Math.Max(S, 5));

            for(int i = 0; i < 5; i++)
            {
                array[i, 0] = i + 1;
                array[i, 1] = (int)((a2 * Math.Pow(i + 1, 2) + a1 * (i + 1)) % p);
                result += $"({array[i, 0]}, {array[i, 1]}) ";
            }

            return "The result of receiving the ciphertext: " + result;
        }
    }
}
