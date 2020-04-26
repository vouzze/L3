using System;
using System.IO;

namespace L3
{
    public class Program
    {
        static void Main()
        {
            Program p = new Program();
            string task;
            do
            {
                Console.WriteLine("\nWhat task do you need?\nPrint '0' to exit.");
                task = Console.ReadLine();
                switch (task)
                {
                    case "0": break;
                    case "1": p.first(); break;
                    case "2": p.second(); break;
                    case "3": p.third(); break;
                    default: Console.WriteLine("Try again. (tasks '1', '2', '3' are available and '0' to exit)"); break;
                }
            } while (task != "0");

        }
        public void first()
        {
            Console.WriteLine("\n\t\t1\n\n");
            string sen = "";
            while (sen.Length == 0)
            {
                Console.WriteLine("Enter a sentence:");
                sen = Console.ReadLine();
            }
            int n = sen.Length;
            char[] s = sen.ToCharArray();
            string[] se = sen.Split();
            int m = se.Length;
            string sens = "";
            Console.Write("Edited sentence:  ");
            for (int i = 0; i < n; i++)
            {
                if (char.IsUpper(s[i])) s[i] = char.ToLower(s[i]);
                Console.Write(s[i]);

            }
            int l = 0;
            for (int i = 0; i < m; i++)
            {
                string for_temp = "";
                char[] temp = se[i].ToCharArray();
                for (int j = 0; j < se[i].Length; j++)
                {
                    if ((char.IsLetter(temp[j])) || (char.IsNumber(temp[j]))) for_temp = for_temp + temp[j];
                }
                if (for_temp.Length > l)
                {
                    l = for_temp.Length;
                    sens = new string(for_temp);
                }
                else if(for_temp.Length == l) sens = sens + ", " + for_temp;
            }
            Console.WriteLine("\nThe longest word(s):  " + sens);
            Console.WriteLine("______________________________________________________________________________\n");
        }
        public void second()
        {
            Console.WriteLine("\n\n\n\t\t2\n\n");
            var fileName = @"C:\Users\User\source\repos\L3\1.txt";
            using var f = new StreamReader(fileName);
            string mains = f.ReadLine();
            Console.WriteLine(mains);
            char[] temps = mains.ToCharArray();
            int l = mains.Length;
            int check = 0;
            int i = 0;
            int j = 0;
            bool even = false;
            while (i < l)
            {
                if (!char.IsWhiteSpace(temps[i]))
                {
                    if (j < 2)
                    {
                        if (char.IsNumber(temps[i])) check++;
                        if (check == 2)
                        {
                            if (temps[i] % 2 == 0) even = true;
                        }
                    }
                    j++;
                }
                i++;
            }
            if (even) Console.WriteLine("First two symbols (except white spaces) are numeric. Found number is even.");
            else
            {
                if ((check == 2) & (!even)) Console.WriteLine("First two symbols (except white spaces) are numeric. Found number is odd.");
                else Console.WriteLine("First two symbols (except white spaces) aren't numeric.");
            }
            f.Close();
            Console.WriteLine("______________________________________________________________________________\n");
        }
        public void third()
        {
            Console.WriteLine("\n\n\n\t\t3\n\n");
            var fileName = @"C:\Users\User\source\repos\L3\input.txt";
            using var f = new StreamReader(fileName);
            StreamWriter p = new StreamWriter("output.txt");
            string mains = f.ReadLine();
            p.WriteLine(mains + "\n");
            char[] temps = mains.ToCharArray();
            int l = mains.Length;
            bool word = false;
            int w = 0;
            int dot = 0;
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < l)
            {
                if ((temps[i] == '.')||(temps[i] == temps[l-1])) dot++;
                i++;
            }
            int[] ww = new int[dot];
            while (j < dot)
            {
                while (k < l)
                {
                    if ((char.IsLetter(temps[k])) || (char.IsNumber(temps[k]))|| (temps[k] == '\''))
                    {
                        word = true;
                    }
                    else
                    {
                        if (word) w++;
                        word = false;
                    }
                    if ((temps[k] == '.') || (temps[k] == temps[l - 1]))
                    {
                        k++;
                        break;
                    }
                    k++;
                }
                ww[j] = w;
                w = 0;
                j++;
            }
            j = 0;
            while (j < dot)
            {
                p.WriteLine("{0:G} word(s) in {1:G} sentence.\n", ww[j], j+1);
                j++;
            }
            int[] sen = new int[dot];
            j = 0;
            int max = 0;
            k = 0;
            while (j < dot)
            {
                while (k < l)
                {
                    if ((temps[k] == '.') || (temps[k] == temps[l - 1]))
                    {
                        k++;
                        break;
                    }
                    if ((char.IsLetter(temps[k])) || (char.IsNumber(temps[k])))
                    {
                        w++;
                    }
                    k++;
                }
                sen[j] = w;
                if (sen[j] > max)
                {
                    max = sen[j];
                }
                w = 0;
                j++;
            }
            j = 0;
            string[] tempc = new string[dot];
            k = 0;
            while (j < dot)
            {

                while (k < l)
                {

                    tempc[j] = tempc[j] + temps[k];
                    if ((temps[k] == '.') || (temps[k] == temps[l - 1]))
                    {
                        k++;
                        break;
                    }

                    k++;
                }
                j++;
            }
            j = 0;
            p.WriteLine("The longest sentence(s): ");
            while (j < dot)
            {

                if (sen[j] == max) p.WriteLine(tempc[j] + "(" + sen[j] + " letters)");
                j++;
            }
            Console.WriteLine("Open \"output.txt\" in L3/bin/Debug/netcoreapp3.1.");
            f.Close();
            p.Close();
            Console.WriteLine("______________________________________________________________________________\n");
        }
    }
}
