using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splitSecret
{
    internal class thirdMember
    {

        public thirdMember() 
        {
        
        }

        static public string Check(string massenge)
        {
            String tmpString = massenge.ToUpper().Replace(" ", ""), bigReg = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ",
                result = "", gammaFirst, gammaSecond, gammaThird, kod = tmpString.Substring(0, 3);

            Random rnd = new Random();

            gammaFirst = $"{bigReg[rnd.Next(0, 33)]}{bigReg[rnd.Next(0, 33)]}{bigReg[rnd.Next(0, 33)]}";
            gammaSecond = $"{bigReg[rnd.Next(0, 33)]}{bigReg[rnd.Next(0, 33)]}{bigReg[rnd.Next(0, 33)]}";
            gammaThird = $"{bigReg[rnd.Next(0, 33)]}{bigReg[rnd.Next(0, 33)]}{bigReg[rnd.Next(0, 33)]}";

            for (int i = 0; i < 3; i++)
            {
                result += kod[i] ^ gammaFirst[i] ^ gammaSecond[i] ^ gammaThird[i];
                result += " ";
            }

            return "The result of receiving the ciphertext: " + result;
        }
    }
}
