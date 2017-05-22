namespace NumberClassifier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNetworks;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Creating neural network...");
            var neuralNetwork = new NeuralNetwork(784, 100, 10, 0.1, 0.4);
            Console.WriteLine("done.");

            Console.Write("Loading training data... ");
            var trainingSet = LoadImageTrainingData(@"D:\Datasets\mnist_dataset\mnist_train_700.csv");
            Console.WriteLine("done.");

            Console.WriteLine("Training neural network...");
            neuralNetwork.Train(trainingSet);
            Console.WriteLine("Finished training neural network.");

            Console.Write("Loading test data... ");
            var testSet = LoadImageTrainingData(@"D:\Datasets\mnist_dataset\mnist_test_10.csv");
            Console.WriteLine("done.");

            Console.WriteLine("Testing...");
            foreach(var testItem in testSet)
            {
                var result = neuralNetwork.Query(testItem.Inputs);
                var correctAnswer = testItem.CorrectNumber;

                Console.WriteLine($"Expected: {correctAnswer}, Got: {result}");
            }

            Console.ReadKey();
        }

        private static List<TrainingItem> LoadImageTrainingData(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var trainingSet = new List<TrainingItem>();

            foreach (var line in lines)
            {
                var values = line.Split(',');

                // Populate the input list for the training set, scaling the data from 0-255 to 0.01-0.99
                var inputList = new List<double>();
                for (var i = 1; i < values.Length; i++)
                {
                    var value = (double.Parse(values[i]) / 255d) * 0.99d + 0.01d;
                    inputList.Add(value);
                }

                // Populate the correct output values in the output list;
                var correctAnswer = int.Parse(values[0]);
                var outputList = new List<double>();
                for (var i = 0; i <= 9; i++)
                {
                    var value = i == correctAnswer ? 0.99d : 0.01d;
                    outputList.Add(value);
                }

                trainingSet.Add(new TrainingItem { Inputs = inputList, CorrectOutputs = outputList, CorrectNumber = correctAnswer });
            }

            return trainingSet;
        }
    }
}
