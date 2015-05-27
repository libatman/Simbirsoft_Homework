using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace TestTask
{
    class FileClass
    {
        public static class WinAPI
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern int MessageBox(int hWnd, String text, String caption, uint type);
        }

        int filecount = 1;
        string filepath; //путь к основному файлу
        public string Filepath

        {
            get
            {
                return filepath;
            }
            set
            {
                filepath = value;
            }
        }
        string dictionarypath; //путь к файлу словаря
        public string Dictionarypath
        {
            get
            {
                return dictionarypath;
            }
            set
            {
                dictionarypath = value;
            }
        }
        int n; // ограничение на количество строк в файле
        public int N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
            }
        }

        string line; //строка в файле

        bool dictionary_check = false;
        public bool Dictionary_check
        {
            get
            {
                return dictionary_check;  
            }
            set
            {
                dictionary_check = value;
            }
        }
        public void ProcessFiles() //обработка файлов
        {

            string[] dictionary = File.ReadAllLines(dictionarypath); //массив слов из словаря
            Array dictionaryArray = Array.CreateInstance(typeof(string), File.ReadAllLines(dictionarypath).Count());
            //System.Collections.ArrayList dictionaryArrayList = new System.Collections.ArrayList();
            //System.Collections.Hashtable dictionaryHashTable = new System.Collections.Hashtable();
            dictionaryArray = File.ReadAllLines(dictionarypath); //вместо обычного массива для словаря можно использовать коллекции Array, Dictionary, List, ArrayList
            //Dictionary<int, string> dictionaryDictionary = new Dictionary<int, string>();
            List<string> dictionaryList = new List<string>();
            for (int i = 0; i < dictionary.Count(); i++)
            {
                dictionaryList.Add(dictionary[i]);
                //dictionaryArrayList.Add(dictionary[i]);
                int count = 0;
                for (int j = 0; j < dictionary.Count(); j++ )
                {
                    if (dictionary[i].Equals(dictionary[j]))
                    {
                        count++;
                    }
                    if (count > 1)
                    {
                        WinAPI.MessageBox(0, "Неверная структура файла словаря. Есть повторяющиеся слова", "Ошибка", 0);
                    }
                }
                //dictionaryDictionary.Add(count, dictionary[i]);
                //dictionaryHashTable.Add(count, dictionary[i]);
            }
            string[] str;
            
            for (int i = 0; i < dictionary.Length; i++) //проверка на структуру словаря
            {
                str = dictionary[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length != 1)
                {
                    WinAPI.MessageBox(0, "Неверная структура файла словаря", "Ошибка", 0);
                    Dictionary_check = false;
                    break;

                }
                else 
                { 
                    Dictionary_check = true;
                } 


            }
            var tupleExampleToCheckSigns = new Tuple<char, char, char, char, char>('!', ':', ';', '?', '.'); //может быть дополнен знаками
            if (Dictionary_check)
            {
                bool check = false;
                int count = 0;
                try
                {

                    using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.Default))
                    {
                        StreamWriter sw = new StreamWriter(@"C:\html-file" + filecount.ToString() + ".html", true, System.Text.Encoding.Default);
                        sw.WriteLine("<html>");
                        char sign = (char)0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] line_array = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string el in line_array)
                            {
                                check = false; 
                                //if (el[el.Length - 1] == ',' || el[el.Length - 1] == '!' || el[el.Length - 1] == '?' || el[el.Length - 1] == '-')
                                //{
                                //    sign = el[el.Length - 1];
                                //}
                                if (el[el.Length - 1] == tupleExampleToCheckSigns.Item1 || el[el.Length - 1] == tupleExampleToCheckSigns.Item2 || el[el.Length - 1] == tupleExampleToCheckSigns.Item3 || el[el.Length - 1] == tupleExampleToCheckSigns.Item4 || el[el.Length - 1] == tupleExampleToCheckSigns.Item5)
                                {
                                    sign = el[el.Length - 1];
                                }
                                string additional = el.TrimEnd(','); //очистка от знаков препинания может быть и такой: string additional = el.TrimEnd(tupleExampleToCheckSigns.Item4);
                                additional = additional.TrimEnd('!');
                                additional = additional.TrimEnd('?');
                                additional = additional.TrimEnd('-');
                                string firstword = additional.ToLower(); 
                                for (int i = 0; i < dictionary.Count(); i++) //поиск совпадающего слова
                                {
                                    string second = dictionary[i].ToLower();
                                    if (firstword == second)
                                    {
                                        check = true;
                                    }
                                }
                                //for (int i = 0; i < dictionaryArray.Length; i++) //поиск совпадающего слова из коллекции Array
                                //{
                                //    string second = dictionaryArray.GetValue(i).ToString().ToLower();
                                //    if (firstword == second)
                                //    {
                                //        check = true;
                                //    }
                                //}
                                //for (int i = 0; i < dictionaryList.Count; i++) //поиск совпадающего слова из коллекции List
                                //{
                                //    string second = dictionaryList[i].ToLower();
                                //    if (firstword == second)
                                //    {
                                //        check = true;
                                //    }
                                //}
                                if (check)
                                {
                                    sw.WriteLine("<b><i>" + additional + "</b></i>" + sign);
                                }
                                else
                                {
                                    sw.WriteLine(el);
                                }
                            }
                            sw.WriteLine("<br>");
                            count++; //счетчик строк написанных в файл
                            if (count == n) //если он равен ограничению, то новый файл
                            {
                                filecount++;
                                sw.WriteLine("</html>");
                                sw.Close();
                                count = 0;
                                sw = new StreamWriter(@"C:\html-file" + filecount.ToString() + ".html", true, System.Text.Encoding.Default);
                            }
                        }
                        sw.WriteLine("</html>");
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    //WinAPI.MessageBox(0, "Ошибка прочтения файлов!", "Важное", 0);
                }
            }
        }
    }
}
