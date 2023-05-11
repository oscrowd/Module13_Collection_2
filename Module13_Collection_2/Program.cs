using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Module13_Collection_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "d:\\test\\Text1.txt"; // Укажем путь 
            var ListText = new List<String>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string sInput; //= "Hello World, This is a great World. I love this great World Hello World, This is a great great great great World. I love this great World Hello World, This is a great World. I love this great World Hello World, This is a great World. I love this great World Hello World, This is a great World. I love this great World Hello World, This is a great World. I love this great World trolo lo trolo lorer trolo lort trolo lrrro trolo loooo trolo loooo gtrt tyujg ertrete loooo trolo loooo gtrt tyujg ertrete loooo trolo loooo gtrt tyujg ertrete loooo trolo loooo gtrt tyujg ertrete loooo trolo loooo gtrt tyujg ertrete loooo trolo loooo gtrt tyujg ertrete gtrt tyujg ertrete";
            if (File.Exists(filePath)) // Проверим, существует ли файл по данному пути
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null) 
                    {
                        ListText.Add(str);
                    }
                }
                foreach (var str in ListText)
                {
                    sInput = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());
                    string[] arr = sInput.Split(' '); //Create an array of words

                    foreach (string word in arr) //let's loop over the words
                    {
                        if (word.Length >= 3) //if it meets our criteria of at least 3 letters
                        {
                            if (dictionary.ContainsKey(word)) //if it's in the dictionary
                                dictionary[word] = dictionary[word] + 1; //Increment the count
                            else
                                dictionary[word] = 1; //put it in the dictionary with a count 1
                        }
                    }
                }
                var selectedDict = from p in dictionary // промежуточная переменная p 
                                   orderby p.Value descending // сортировка по возрастанию (дефолтная)
                                   select p; // выбираем объект и сохраняем в выборку
                var res = selectedDict.Take(10);

                foreach (var s in res)
                    Console.WriteLine(s.Key + " " + s.Value);
                Console.ReadLine();
            }
        }
    }
}
