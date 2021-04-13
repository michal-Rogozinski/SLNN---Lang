using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNN___Lang
{
    class Perceptron
    {
        public string lang { get; set; }
        public double[] weights = new double[27];
        public double[] Weights { get => weights; }
        public Perceptron(string langIn,double initBias)
        {
            lang = langIn;
            InitWeigts();
            weights[26] = initBias;
        }
        public void InitWeigts()
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            for(int i = 0;i < weights.Length - 1; i++)
            {
                weights[i] = rng.NextDouble();
            }
        }
        public double sign(double i)
        {
            return i >= 0 ? 1 : 0;
        }
        public double sigmoid(double i)
        {
            return 1 / (Math.Pow(Math.E, -i));
        }
        public double getNet(double[] input)
        {
            double result = 0.0d;
            for(int i = 0;i < weights.Length; i++)
            {
                result += weights[i] * input[i];
            }
            return sign(result);
        }
        public double getNetSigmoid(double[] input)
        {
            double result = 0.0d;
            for(int i = 0;i < weights.Length; i++)
            {
                result += weights[i] * input[i];
            }
            return sigmoid(result);
        }
        public void setWeights(double[] input,string InputLang,double alpha)
        {
            double d = InputLang.Equals(lang) ? 1 : 0;
            double y = getNet(input);
            
            for(int i = 0;i < input.Length; i++)
            {
                weights[i] = weights[i] + alpha * (d - y) * input[i];
            }
        }
    }
}
