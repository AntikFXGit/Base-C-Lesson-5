
using System;
using System.Collections.Generic;
using System.Linq;

namespace Base_C_Lesson_5
{
    public class CompareString
    {

        public static bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            bool result = true;
            // 1. разбиваем на символы и считаем сколько раз каждый встречается в первой строке
            var letsStr1 = StringToChars(str1);
            var letsStr2 = StringToChars(str2);

            // 2. считаем в другой строке каждый символ, чтобы соответствовал по количеству с исходной строкой
            foreach (KeyValuePair<char, int> val in letsStr1)
            {
                if (!letsStr2.ContainsKey(val.Key)) { result = false; break; }
                if (val.Value != letsStr2[val.Key]) { result = false; break; }
            }
            return result;
        }


        public static bool IsAnagramBase(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;
            char[] letsStr1 = str1.ToLower().ToCharArray();
            char[] letsStr2 = str2.ToLower().ToCharArray();
            Array.Sort(letsStr1);
            Array.Sort(letsStr2);
            return Enumerable.SequenceEqual(letsStr1, letsStr2);
        }


        private static Dictionary<char, int> StringToChars(string str)
        {
            var lets = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!lets.ContainsKey(str[i])) lets[str[i]] = 0;
                lets[str[i]]++;
            }
            return lets;
        }
    }
}