using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            char[] separators = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            string[] sentences = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var sentence in sentences)
            {
                if (sentence.Any(c => char.IsLetter(c)) || sentence.Contains('\''))
                {
                    sentencesList.Add(GetListWord(sentence));
                }
            }
            return sentencesList;
        }

        private static List<string> GetListWord(string sentence)
        {
            var word = new StringBuilder();
            var allWord = new List<string>();
            for (var i = 0; i < sentence.Length; i++)
            {
                if (char.IsLetter(sentence[i]) || sentence[i] == '\'')
                {
                    word.Append(sentence[i]);
                }
                if (!(char.IsLetter(sentence[i]) || sentence[i] == '\'') || i == sentence.Length - 1)
                {
                    if (word.Length > 0)
                        allWord.Add(word.ToString());
                    word.Clear();
                }
            }
            return allWord;
        }
    }
}