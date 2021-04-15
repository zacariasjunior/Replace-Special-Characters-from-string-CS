using System;

namespace Replace_Special_Characters_from_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Replace áéíóú to {ReplaceSpecialCharacters("áéíóú")}");
        }

        public static string ReplaceSpecialCharacters(string value)
        {

            string[] encodeCharacters = {"\n","`",
                "á","ã","à","Á","Ã","À","Â",
                "é","è","ê","ë","É","Ê","Ë",
                "í","ì","Í","Ì",
                "ó","õ","ô","Ó","Õ","Ô",
                "ü","ú","ù","Ü","Ú","Ù",
                "ç","Ç"};

            string[] encodedCharacters = {" "," ",
                "a","a","a","A","A","A","A",
                "e","e","e","e","E","E","E",
                "i","i","I","I",
                "o","o","o","O","O","O",
                "u","u","u","U","U","U",
                "c","C"};

            bool[] encodeBools = new bool[encodeCharacters.Length];

            for (int i = 0; i < encodeCharacters.Length; i++)
            {
                encodeBools[i] = true;
            }

            int x = 0;
            int length = encodeCharacters.Length;
            while (x < length)
            {
                while (encodeBools[x] == true)
                {
                    encodeBools[x] = value.Contains(encodeCharacters[x]);
                    if (encodeBools[x] == true)
                    {
                        int index = value.IndexOf(encodeCharacters[x], StringComparison.Ordinal);
                        if (index >= 0)
                        {
                            value = value.Remove(index, 1);
                            value = value.Insert(index, encodedCharacters[x]);
                        }

                    }
                    encodeBools[x] = value.Contains(encodeCharacters[x]);
                }
                x++;
            }
            return value;
        }
    }
}
