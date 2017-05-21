using System;
using System.Linq;

namespace NumberClassifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating neural network...");
            var neuralNetwork = new NeuralNetwork.NeuralNetwork(784, 100, 10, 0.1, 0.4);

            var inputList = new double[784];
            
            for (var i = 0; i < inputList.Length; i++)
            {
                inputList[i] = 0.99d;
            }

            neuralNetwork.Query(inputList.ToList());
            Console.ReadKey();
        }
    }
}
