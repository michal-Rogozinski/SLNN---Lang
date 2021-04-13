using System;

namespace SLNN___Lang
{
    class Program
    {
        static void Main(string[] args)
        {
            const string instrument1 = "Jest pewna procedura, nie można sobie wybrać płci\" - stwierdził minister Michał Wójcik w TVN24.A minister Przemysław Czarnek w RMF FM przekonywał: \"Szkoła nie jest od tego, by zmieniać płeć kogokolwiek. Od tego są pewne procedury\".Jednak w Polsce nie ma opisanej prawnej procedury dotyczącej korekty płci. A mimo to w naszym kraju, pod określonymi warunkami, można to przeprowadzić";
            Perceptron perceptron1 = new Perceptron("en", 0.0);
            Perceptron perceptron2 = new Perceptron("pl", 0.0);
            Perceptron perceptron3 = new Perceptron("fr", 0.0);

            for (int i = 0; i < 500; i++)
            {
                Methods.Train(@"C:\Users\rogo9\source\repos\SLNL - Lang\Files\EN", perceptron1);
                Methods.Train(@"C:\Users\rogo9\source\repos\SLNL - Lang\Files\PL", perceptron2);
                Methods.Train(@"C:\Users\rogo9\source\repos\SLNL - Lang\Files\FR", perceptron3);
            }
            Console.WriteLine("eng "+perceptron1.getNetSigmoid(Methods.parseString(instrument1)));
            Console.WriteLine("pl " +perceptron2.getNetSigmoid(Methods.parseString(instrument1)));
            Console.WriteLine("fr " +perceptron3.getNetSigmoid(Methods.parseString(instrument1)));
        }
    }
}
