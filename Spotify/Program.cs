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
            bool cont = true;
            int count = 0;
            string command = "";
            bool end = false;


            using (StreamReader sr = new StreamReader("top10000songs.csv"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    int t = 0;
                    start = line.Split(",");
                    List<string> starter = new List<string>();
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
            while (cont)
            {
                if(end) 
                {
                    break; 
                }
                Console.WriteLine("commands: SEARCH, CLEAR, END");
                command = Console.ReadLine();
                command = command.ToUpper();
                switch (command)
                {
                    case "CLEAR":
                        Console.Clear();
                        break;
                    case "SEARCH":
                        count = 0;
                        Console.WriteLine("search for the name of the song");
                        string input = Console.ReadLine();
                        input = input.ToUpper();
                        foreach (KeyValuePair<int, List<string>> kvp in map)
                        {

                            List<string> temp = kvp.Value;
                            if (temp.Contains(input))
                            {
                                count++;
                                Console.Write(kvp.Key + "\t");
                                foreach (string s in kvp.Value)
                                {
                                    Console.Write(s + "\t");
                                }
                                Console.WriteLine();

                            }
                        }
                        Console.WriteLine("there are " + count + " Results");
                        break;
                    case "END":
                        Console.WriteLine("ending the program");
                        end = true;
                        break;
                }

                
            }
        }
    }
}

