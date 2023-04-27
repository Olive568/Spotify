using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();
            string[] start = new string[4];
            List<string> starter = new List<string>();
            bool cont = true;
            string newsti = "";
            bool breaker = false;


            using (StreamReader sr = new StreamReader("top10000songs.csv"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    int t = 0;
                    start = line.Split(",");
                    for (int i = 1; i <= 3; i++)
                    {
                        string info = start[i];

                        info = info.ToUpper();
                        starter.Add(info);
                        t++;
                    }
                    int num = int.Parse(start[0]);
                    map.Add(int.Parse(start[0]), starter);
                }
            }
            Console.WriteLine("search for the name of the song");
            while (cont)
            {
                breaker = false;
                string input = Console.ReadLine();
                input = input.ToUpper();
                foreach (KeyValuePair<int, List<string>> kvp in map)
                {
                    if (breaker)
                        break;
                    foreach (string info in kvp.Value)
                    {
                        if (breaker)
                            break;
                        if (input == info)
                        {
                            Console.Write(kvp.Key + "\t");
                            for (int j = 0; j < kvp.Value.Count; j++)
                            {
                                Console.Write(kvp.Value[j] + "\t");
                            }
                            Console.WriteLine();
                            breaker = true;
                            break;
                        }
                    }
                }


                //display
                //foreach (KeyValuePair<int, List<string>> kvp in map)
                //{
                //    Console.Write(kvp.Key + "\t");
                //    foreach (string s in kvp.Value)
                //    {
                //        Console.Write(s + "\t");
                //    }
                //    Console.WriteLine("");
                //}
                //Console.ReadKey();
            }
        }
    }
}
