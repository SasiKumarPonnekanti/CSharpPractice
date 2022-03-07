using System;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;

namespace homework_2
{
    
    internal class Program
    {
        static void Main(string[] args)

        {
            do {

                string str = @"Historically, the world of data and the world of objects" +
              @" have not been well integrated. Programmers work in C# or Visual Basic" +
              @" and also in SQL or XQuery. On the one side are concepts such as classes," +
              @" objects, fields, inheritance, and .NET APIs. On the other side" +
              @" are tables, columns, rows, nodes, and separate languages for dealing with" +
              @" them. Data types often require translation between the two worlds; there are" +
              @" different standard functions. Because the object world has no notion of query, a" +
              @" query can only be represented as a string without compile-time type checking or" +
              @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
              @" objects in memory is often tedious and error-prone.This got popular in january and march";
                Console.WriteLine("================================================");
                Console.WriteLine("Enter your choice from 1 to 14");
                Console.WriteLine("1 number of 'Blank Spaces' ");
                Console.WriteLine("2 No of words");
                Console.WriteLine("3 No of '.'");
                Console.WriteLine("4 No of Statements");
                Console.WriteLine("5 No of Digits");
                Console.WriteLine("6 No of words starting with vowels");
                Console.WriteLine("7 Count of This  is to and their indexes");
                Console.WriteLine("8 count and psitions of comma ");
                Console.WriteLine("9 Reverse each word in string");
                Console.WriteLine("10Reverse entirre string");
                Console.WriteLine("11 each statement in separate line on console from the above string");
                Console.WriteLine("12 All words decorated ");
                Console.WriteLine("13 Convert first character of each word in upper case");
                Console.WriteLine("14 month names");
                Console.WriteLine("");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        
                         getCount( str,' ',out int counOfBlanks,out string str2 );
                        Console.WriteLine($"The count of blank spaces is{counOfBlanks}");
                        break;
                    case 2:

                        getCount(str, ' ', out int counOfWords, out  str2);
                        Console.WriteLine($"the no of words in string are {counOfWords+1}");
                        break;
                    case 3:                      
                        getCount(str, '.', out int counOfDots, out str2);
                        Console.WriteLine($"the count of . in string is{counOfDots}");
                        break;
                    case 4:
                       
                        getCount(str, '.', out  counOfWords, out str2);
                        Console.WriteLine($"There are {counOfWords} sentences in given String ");
                        break;
                    case 5:
                        int count = 0;
                        foreach (char c in str)
                        {
                            if ((c >= '0') && (c <= '9'))
                            {
                                count++;
                            }
                        }
                        Console.WriteLine("the count of digits is {0}", count);
                        break;
                    case 6:
                        string vowel = "aeiouAEIOU";
                        foreach (string s in str.Split(' '))
                        {
                            if (vowel.Contains(s[0]))
                            {
                                Console.WriteLine(s);
                            }
                        }
                        break;
                    case 7:
                        int countNumber = 0;
                        string[] sample = { "the", "is", "to", "and" };
                        ArrayList index = new ArrayList();
                        foreach (string item in sample)
                        {
                            for (int i = str.IndexOf(item); i >= 0; i = str.IndexOf(item, i + 1))
                            {
                                countNumber++;
                                index.Add(i);
                            }
                            Console.WriteLine($"count of '{item}' in string is {countNumber} and the index position are as follows");
                            foreach (int element in index)
                            {
                                Console.WriteLine(element);
                            }
                            index.Clear();
                        }
                        break;
                        int count1 = 0;
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] == ',')
                            {
                                Console.WriteLine($"found at {i}");
                                count1++;
                            }
                        }
                        Console.WriteLine($"Total number of comma\'s are {count1}");
                        break;
                    case 9:
                        string k = " ";
                        foreach (string s in str.Split(' '))
                        {
                            getCount(s, ' ', out count1, out string restr);
                            k = k + " " + restr;

                        }
                        Console.WriteLine(k);

                        break;
                    case 10:
                        string p = " ";
                        foreach (string s in str.Split('.'))
                        {
                            //p = p + " " + ReverseString(s);
                            getCount(s,' ',out count1,out string restr);
                            p = p + " " + restr;

                        }
                        Console.WriteLine(p);
                        break;
                    case 11:
                        foreach (string i in str.Split('.'))
                        {
                            Console.WriteLine(i);
                        }
                        break;
                    case 12:
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(str);
                        foreach (var item in matches)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 13:
                        string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
                        Console.WriteLine(titleCase);
                        Console.WriteLine("=====================================================");
                        string[] word = str.Split(' ');
                        foreach (string item in word)
                        {
                            Console.Write(char.ToUpper(item[0]) + item.Substring(1) + " ");
                        }
                        break;
                    case 14:
                        string[] months = { "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december" };
                        foreach (string item in months)
                        {
                            if (str.Contains(item))
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;


                }
            }
            while(true);         
          void getCount(string str ,char c ,out int CharCount,out string rstr)
            {
                CharCount = 0;
                foreach (char ch in str)
                {
                    if (ch == c)
                    {
                        CharCount++;
                    }
                }              
                char[] array = str.ToCharArray();
                Array.Reverse(array);
                rstr = new string(array);
            }
            
           
            

        }
    }
}
