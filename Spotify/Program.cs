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
            string line = "";
            Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();
            string[] start = new string[4];
            List<int> ID = new List<int>();
            List<string> artist = new List<string>(); 
            bool cont = true;
            int count = 0;
            string command = "";
            bool end = false;
            Random rnd = new Random();
            Dictionary<int, List<string>> shuffle = new Dictionary<int, List<string>>();


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
                Console.WriteLine("commands: SEARCH, CLEAR, SHUFFLE, END, PLAY, RESET");
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
                    case "SHUFFLE":
                        int y = 0;
                        Console.WriteLine("how many songs do you want in the shuffle playlist?");
                        int Shufnum = int.Parse(Console.ReadLine());
                        for(int x =0; x < Shufnum; x++)
                        {
                            int index = rnd.Next(map.Count);
                            KeyValuePair<int, List<string>> kvp = map.ElementAt(index);
                            int ID1 = kvp.Key;
                            string artists = kvp.Value[0];
                            if (!ID.Contains(ID1))
                            {
                                if(y == 10)
                                {
                                    y = 0;
                                    artist.Clear();
                                    shuffle.Add(kvp.Key, kvp.Value);
                                    ID.Add(ID1);

                                }
                                else if(!artist.Contains(artists))
                                {
                                    y++;
                                    artist.Add(artists);
                                    ID.Add(ID1);
                                    shuffle.Add(kvp.Key, kvp.Value);
                                }
                                else
                                {
                                    y--;
                                    x--;
                                }
                            }
                            else
                            {
                                x--;
                            }
                        }
                        Console.WriteLine("Shuffled playlist created, type PLAY to show");
                        break;

                    case "PLAY":
                        foreach (KeyValuePair < int,List<string>> kvp in shuffle)
                        {
                            Console.Write(kvp.Key + "\t");
                            foreach(string s in kvp.Value)
                            {
                                Console.Write(s + "\t");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "RESET":
                        shuffle.Clear();
                        Console.WriteLine("shuffle playlist has been cleared");
                        break;
                    default:
                        Console.WriteLine("That is not a command");
                            break;
                }

                
            }
        }
    }
}

