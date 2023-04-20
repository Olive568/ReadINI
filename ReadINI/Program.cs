using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dic = new string[] {};
            string[] word = new string[] { };
            string line = "";
            string[] start = new string[] {};
            string[] setting = new string[8];
            List<string> letter1 = new List<string>();
            int[] settingnum = new int[] {};
            int forcount = 0;

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
            int indent = int.Parse(setting[3]);
            string inside = setting[5];
            string outsie = setting[7];

            using (StreamReader sr = new StreamReader(inside))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    dic = line.Split(" ");
                }
            }
            int charpiece = 0;
            for (int x =0; x <dic.Length; x++)
            {
               if(charpiece + dic[x].Length>= charper -1)
                {
                    charpiece = 0;
                    Console.WriteLine(dic[x] + " ");
                    charpiece += dic[x].Length + 1;                                       
                }
               else
                {
                    charpiece += dic[x].Length + 1;
                    Console.Write(dic[x] + " ");
                }
            }
            
       
            Console.ReadKey();
        }
    }
}