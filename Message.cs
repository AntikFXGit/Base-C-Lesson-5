using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
namespace Base_C_Lesson_5
{
    public class Message
    {

        public static List<string> searchWords(string text, int maxLen)
        {
            var words = new List<string>();
            if (maxLen <= 2) maxLen = 3;
            var regex = new Regex("\\b\\w{2," + maxLen + "}\\b", RegexOptions.IgnoreCase);
            var found = regex.Matches(text);
            if (found.Count > 0) foreach (Match match in found) words.Add(match.Value);
            return words;
        }

        public static string clearText(string text, char c)
        {
            var regex = new Regex("\\b\\w+"+c+"\\b", RegexOptions.IgnoreCase);
            text = regex.Replace(text, "").Trim();
            return text;
        }

        public static string biggerWord(string text)
        {
            var words = new List<string>();
            var regex = new Regex("\\b\\w+\\b", RegexOptions.IgnoreCase);
            var found = regex.Matches(text);
            if (found.Count > 0) foreach (Match match in found) words.Add(match.Value);
            
            var biggerWord = words.OrderByDescending(s => s.Length).First();
            return biggerWord;
        }


        public static List<string> biggerWords(string text)
        {
            var words = new List<string>();
            var regex = new Regex("\\b\\w+\\b", RegexOptions.IgnoreCase);
            var found = regex.Matches(text);
            if (found.Count > 0) foreach (Match match in found) words.Add(match.Value);
            var newList = words.OrderByDescending(x => x.Length).ToList();
            return newList;
        }

        public static Dictionary<string, int> muchWords(string text, string[] words)
        {
            Dictionary<string, int> muchWords = new Dictionary<string, int>();

            foreach (string word in words)
            {
                var regex = new Regex("\\b"+ word + "\\b", RegexOptions.IgnoreCase);
                var found = regex.Matches(text);
                muchWords[word] = found.Count;
            }
            return muchWords;
        }



    }
}