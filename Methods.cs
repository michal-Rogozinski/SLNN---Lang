using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

namespace SLNN___Lang
{
    class Methods
    {
        public static double[] parseFile(string inputPath)
        {
            double[] alphabet = new double[27];
            double counterChar = 0;
            var alphabetMap = new Dictionary<char, int>();

            for(char letter = 'a';letter <= 'z'; letter++)
            {
                alphabetMap.Add(letter,0);
            }
            try
            {
                StreamReader stream = new StreamReader(inputPath);
                char character;
                while (!stream.EndOfStream)
                {
                    character = (char)stream.Read();
                    int f;
                    if (alphabetMap.TryGetValue(character,out f))
                    {
                        alphabetMap[character] = f + 1;
                        counterChar += 1;
                    }
                }
            }catch(IOException exc)
            {
                Console.WriteLine(exc.Message);
            }

            int i = 0;

            foreach(var entry in alphabetMap)
            {
                alphabet[i] = entry.Value / counterChar;
                i++;
            }

            alphabet[26] = -1.0;

            return alphabet;
        }
        public static double[] parseString(string input)
        {
            double[] alphabet = new double[27];
            double counterChar = 0;
            Dictionary<char, int> alphabetMap = new Dictionary<char, int>();

            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                alphabetMap.Add(letter, 0);
            }
            char[] charArr = input.ToCharArray();

            foreach(char c in charArr)
            {
                int f;
                if(alphabetMap.TryGetValue(c,out f))
                {
                    alphabetMap[c] = f + 1;
                    counterChar += 1;
                }
            }

            int i = 0;

            foreach (var entry in alphabetMap)
            {
                alphabet[i] = entry.Value / counterChar;
                i++;
            }

            alphabet[26] = -1.0;

            return alphabet;
        }
        public static void Train(string path,Perceptron perceptron)
        {
            double alpha = 0.3;
            List<string> files = Directory.GetFiles(path).ToList();
            Random rng = new Random(Guid.NewGuid().GetHashCode());

            //Shuffle(files, rng.Next());

            foreach(var i in files)
            {
                FileAttributes attributes = File.GetAttributes(i);
                if (attributes.HasFlag(FileAttributes.Directory))
                {
                    Train(i, perceptron);
                }
                else
                {
                    string langName = i.Substring(0, i.Length - 5);
                    perceptron.setWeights(parseFile(i), langName, alpha);
                }
            }
            
        }
        public static void Shuffle<T>(IList<T> list, int seed)
        {
            Random rng = new Random(seed);
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
