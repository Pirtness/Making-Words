using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MakingWords
{
    public class MakeWords
    {
        public string output { get; private set; }
        string indexes = "", 
            word = "";
        char[] chars;
        string[] dict;

        public MakeWords(char[] chars)
        {
            this.chars = chars;
        }

        public void CreateWords(int wordLength)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (indexes.Length == 0 || Check(indexes, i))
                {
                    indexes += i;
                    word += chars[i];
                }
                else
                    continue;
                if (word.Length == wordLength)
                {
                    output += word + "\n";
                }
                else
                    CreateWords(wordLength);
                word = word.Substring(0, word.Length - 1);
                indexes = indexes.Substring(0, indexes.Length - 1);

            }
        }

        public void CreateRealWords(int wordLength)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (indexes.Length == 0 || Check(indexes, i))
                {
                    indexes += i;
                    word += chars[i];
                }
                else
                    continue;
                if (word.Length == wordLength)
                {
                    if (Array.IndexOf(dict, word) >= 0)
                        output += word + "\n";
                }
                else
                    CreateRealWords(wordLength);
                word = word.Substring(0, word.Length - 1);
                indexes = indexes.Substring(0, indexes.Length - 1);

            }
        }

        public void ReadFile(string path)
        {
            //string path = Path.Combine(Path.)
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                dict = new string[file.Length];
                using (StreamReader reader = new StreamReader(path))
                {
                    for (int i = 0; i < dict.Length; i++)
                    {
                        if (dict != null)
                            dict[i] = reader.ReadLine();
                    }
                }
            }
        }

        bool Check(string indexes, int a)
        {
            int b;
            foreach (char memb in indexes)
            {
                b = int.Parse(memb.ToString());
                if (a == b)
                    return false;
            }
            return true;
        }
    }
}
