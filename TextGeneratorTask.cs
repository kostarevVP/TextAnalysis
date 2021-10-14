using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            StringBuilder sentence = new StringBuilder(phraseBeginning);

            for (int i = 0; i < wordsCount; i++)
            {
                if (CountWord(sentence) > 1 && nextWords.ContainsKey(LastWords(sentence, 2)))
                {
                    sentence.Append((" " + nextWords[LastWords(sentence, 2)]));
                    continue;
                }
                if (nextWords.ContainsKey(LastWords(sentence, 1)))
                {
                    sentence.Append((" " + nextWords[LastWords(sentence, 1)]));
                }
            }
            return sentence.ToString();
        }

        public static string LastWords(StringBuilder build, int words)
        {
            var str = build.ToString().Split();
            var result = "";
            for (var i = words; i > 0; i--)
            {
                result += " " + str[str.Length - i];
            }
            return result.Trim();
        }

        public static int CountWord(StringBuilder text)
        {
            return text.ToString().Split().Length;
        }
    }
}