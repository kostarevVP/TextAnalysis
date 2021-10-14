using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            AddKeyWord(result, GetNGramm(text, 2));
            AddKeyWord(result, GetNGramm(text, 3));
            return result;
        }

        private static void AddKeyWord(
            Dictionary<string, string> result,
            Dictionary<string, Dictionary<string, int>> allGramm)
        {
            foreach (var pair in allGramm)
            {
                result.Add(pair.Key, GetOneWord(pair.Value));
            }
        }

        public static string GetOneWord(Dictionary<string, int> dictionary)
        {
            var result = "";
            var count = 0;
            foreach (var pair in dictionary)
            {
                if (pair.Value > count)
                {
                    result = pair.Key;
                    count = pair.Value;
                }
                if (string.CompareOrdinal(pair.Key, result) < 0 && pair.Value == count)
                {
                    result = pair.Key;
                    count = pair.Value;
                }
            }
            return result;
        }

        public static Dictionary<string, Dictionary<string, int>> GetNGramm(List<List<string>> text, int gramm)
        {
            var result = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in text)
            {
                if (sentence.Count > gramm - 1)
                {
                    for (var word = 0; word < sentence.Count - (gramm - 1); word++)
                    {
                        var key = GetStringGrammFromPosition(sentence, gramm, word);
                        var value = sentence[word + gramm - 1];
                        if (!result.ContainsKey(key))
                        {
                            result[key] = new Dictionary<string, int>();
                        }
                        if (!result[key].ContainsKey(value))
                        {
                            result[key][value] = 0;
                        }
                        result[key][value]++;
                    }
                }
            }
            return result;
        }

        public static string GetStringGrammFromPosition(List<string> str, int gramm, int position)
        {
            var result = "";
            for (int i = position; i < gramm - 1 + position; i++)
            {
                result = result + str[i] + " ";
            }
            return result.Remove(result.Length - 1);
        }
    }
}