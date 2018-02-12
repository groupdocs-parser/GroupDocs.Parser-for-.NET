using GroupDocs.Text;
using GroupDocs.Text.Extractors.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET
{
    class WordStatistic
    {
        public WordStatistic(string fileName, int maxWordLength)
        {
            //ExStart:WordStatistic
            ExtractorFactory factory = new ExtractorFactory();
            Dictionary<string, int> statistic = new Dictionary<string, int>();

            TextExtractor extractor = factory.CreateTextExtractor(fileName);
            if (extractor == null)
            {
                Console.WriteLine("The document's format is not supported");
                return;
            }

            try
            {
                string line = null;
                do
                {
                    line = extractor.ExtractLine();
                    if (line != null)
                    {
                        string[] words = line.Split(' ', ',', ';', '.');
                        foreach (string w in words)
                        {
                            string word = w.Trim().ToLower();
                            if (word.Length > maxWordLength)
                            {
                                if (!statistic.ContainsKey(word))
                                {
                                    statistic[word] = 0;
                                }

                                statistic[word]++;
                            }
                        }
                    }
                }
                while (line != null);
            }
            finally
            {
                extractor.Dispose();
            }

            Console.WriteLine("Top words:");

            for (int i = 0; i < 10; i++)
            {
                int count = -1;
                string maxKey = null;
                foreach (string key in statistic.Keys)
                {
                    if (statistic[key] > count)
                    {
                        count = statistic[key];
                        maxKey = key;
                    }
                }

                if (maxKey == null)
                {
                    break;
                }

                Console.WriteLine("{0}: {1}", maxKey, count);
                statistic.Remove(maxKey);
            }
            //ExEnd:WordStatistic
        }
        public static void FindMaxWordLength(string fileOne, string fileTwo)
        {
            //ExStart:FindMaxWordLength
            String firstFile = Common.GetFilePath(fileOne);
            String secondFile = Common.GetFilePath(fileTwo);
            string[] arguments = new string[] { firstFile, secondFile};
           
            int maxWordLength;
            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i].Length == 1 || !int.TryParse(arguments[i], out maxWordLength))
                {
                    maxWordLength = 5;
                }
                WordStatistic ws = new WordStatistic(arguments[i], maxWordLength);
                Console.WriteLine("__________________");
            }
            //ExEnd:FindMaxWordLength
        }
    }
}
