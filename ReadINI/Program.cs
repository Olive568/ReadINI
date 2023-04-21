using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dic = new string[] {};
            string line = "";
            string[] start = new string[] {};
            string[] setting = new string[8];
            int forcount = 0;
            bool indent = true;

            using (StreamReader sr = new StreamReader("Setup.ini"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    start = line.Split("=");
                    for(int i = 0; i < 2; i++)
                    {
                        
                        setting[forcount] = start[i];
                        forcount++;
                    }
                }
            }
            int charper = int.Parse(setting[1]);
            if (int.Parse(setting[3]) == 1)
            {
                indent = true;
            }
            else
            {
                indent = false;
            }
            string inside = setting[5];
            string outside = setting[7];

            using (StreamReader sr = new StreamReader(inside))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    dic = line.Split(" ");
                }
            }
            int charpiece = 0;
            using (StreamWriter sw = new StreamWriter(outside))
            {
                if (indent)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        sw.Write(" ");
                        charpiece++;
                    }
                }
                for (int x = 0; x < dic.Length; x++)
                {
                    if (charpiece + dic[x].Length >= charper)
                    {
                        sw.WriteLine();
                        sw.Write(dic[x] + " ");
                        charpiece = dic[x].Length + 1;
                    }
                    else
                    {
                        sw.Write(dic[x] + " ");
                        charpiece += dic[x].Length + 1;
                    }
                }
            }
            Console.WriteLine("The task is Complete. Format now applied in the notepad");
            Console.ReadKey();
        }
    }
}