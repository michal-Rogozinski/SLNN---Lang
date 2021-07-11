using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace SLNN___Lang
{
    class Program
    {
        static void Main(string[] args)
        {
            var filesDir = Directory.GetCurrentDirectory() + "\\Files";
            List<string> listDir = new List<string>();
            if (!Directory.Exists(filesDir))
            {
                Directory.CreateDirectory(filesDir);
            }
            string[] list = Directory.GetDirectories(filesDir);
            if (list.Length == 0)
            {
                throw new Exception("Training files directory cannot be empty!");
            }
            else
            {
                foreach (string i in list)
                {
                    listDir.Add(i.Substring(i.Length - 2, 2));
                }
                Perceptron perceptron1 = new Perceptron(listDir[0], 0.0);
                Perceptron perceptron2 = new Perceptron(listDir[1], 0.0);
                Perceptron perceptron3 = new Perceptron(listDir[2], 0.0);

                for (int i = 0; i < 500; i++)
                {
                    Methods.Train(list[0], perceptron1);
                    Methods.Train(list[1], perceptron2);
                    Methods.Train(list[2], perceptron3);
                }

                Console.WriteLine("Enter text to match");
                string input = Console.ReadLine();

                double[] output = new double[3];
                output[0] = perceptron1.getNetSigmoid(Methods.parseString(input));
                output[1] = perceptron2.getNetSigmoid(Methods.parseString(input));
                output[2] = perceptron3.getNetSigmoid(Methods.parseString(input));

                var maxVal = output.Max();
                int maxIndex = output.ToList().IndexOf(maxVal);

                for (int i = 0; i < output.Length; i++)
                {
                    Console.WriteLine("Output for sigmoid: " + listDir[i] + " : " + String.Format("{0:0.###}", output[i]));
                }
                Console.WriteLine("Maximum value at : " + listDir[maxIndex]);
                Console.WriteLine("Identified language : " + listDir[maxIndex]);
            }
        }
    }
}
