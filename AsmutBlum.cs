using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splitSecret
{
    internal class AsmutBlum
    {

        public AsmutBlum() { }

        //метод для формирования простых чисел
        static private int Simple(int a)
        {
            int n = 0;

            Random rnd = new Random();

            bool good = false;

            while (!good)
            {
                //Ограничение в целях рациональности
                n = rnd.Next(a, 50);

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

        public static bool IsCoprime(int a, int b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }

        static public string Check(string massenge)
        {
            string bigReg = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ", result = "";
            int S = bigReg.IndexOf(massenge.ToUpper().Substring(0, 1)), p = Simple(S), 
                umnPrav = p, umnLev = 1, r = 0, tmpInt;
            int[,] array = new int[5, 2];
            bool good = false;
            Random rnd = new Random();

            do
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                        array[i, 0] = Simple(p);
                    else
                    {
                        tmpInt = rnd.Next(array[i - 1, 0], array[i - 1, 0] + 500);

                        //Для составления взаимно простого числа с предыдущим элементов
                        while (!IsCoprime(array[i - 1, 0], tmpInt))
                            tmpInt++;

                        array[i, 0] = tmpInt;

                        if (i < 3)
                            umnLev *= array[i, 0];
                        else
                            umnPrav *= array[i, 0];
                    }

                    array[i, 1] = 0;
                }

                if (umnLev < umnPrav)
                    good = true;
                else
                {
                    umnLev = 1;
                    umnPrav = p;
                }

            } while (!good);

            int a = 1, S1;

            for (int i = 0; i < 3; i++)
            {
                a *= array[i, 0];

                if (i == 2)
                    r = rnd.Next(0, (a - S) / p);
            }

            S1 = S + r * p;

            for (int i = 0; i < 5; i++)
            {
                array[i, 1] = S1 % array[i, 0];
                result += $"({array[i, 0]}, {array[i, 1]}) ";
            }

            return "The result of receiving the ciphertext: " + result;
        }
    }
}
