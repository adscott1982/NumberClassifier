namespace NeuralNetwork
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A neural network.
    /// </summary>
    public class NeuralNetwork
    {
        private List<Node> inputNodes;
        private List<Node> hiddenNodes;
        private List<Node> outputNodes;
        private double learningRate;
        private Random random;

        /// <summary>
        /// Create a neural network.
        /// </summary>
        /// <param name="inputNodeCount">The number of input nodes.</param>
        /// <param name="hiddenNodeCount">The number of hidden nodes.</param>
        /// <param name="outputNodeCount">The number of output nodes.</param>
        /// <param name="learningRate">The learning rate.</param>
        public NeuralNetwork(int inputNodeCount, int hiddenNodeCount, int outputNodeCount, double learningRate)
        {
            this.random = new Random(DateTime.Now.Millisecond * DateTime.Now.Minute);
            this.learningRate = learningRate;

            // The order of the creation of the node layers is important, they must go from output to input
            this.InitializeOutputNodes(outputNodeCount);
            this.InitializeHiddenNodes(hiddenNodeCount);
            this.InitializeInputNodes(inputNodeCount);
        }

        private void InitializeInputNodes(int inputNodeCount)
        {
            this.inputNodes = new List<Node>();

            for (var i = 0; i < inputNodeCount; i++)
            {
                this.inputNodes.Add(new InputNode(this.hiddenNodes, 0.4d, this.random));
            }
        }

        private void InitializeHiddenNodes(int hiddenNodeCount)
        {
            this.hiddenNodes = new List<Node>();
        }

        private void InitializeOutputNodes(int outputNodeCount)
        {
            this.outputNodes = new List<Node>();
            
        }
    }
}
