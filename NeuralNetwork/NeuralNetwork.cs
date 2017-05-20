namespace NeuralNetwork
{
    using System;
    using System.Linq;
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
        public NeuralNetwork(int inputNodeCount, int hiddenNodeCount, int outputNodeCount, double learningRate, double startingOutputVariance)
        {
            this.random = new Random(DateTime.Now.Millisecond * DateTime.Now.Minute);
            this.learningRate = learningRate;

            // The order of the creation of the node layers is important, they must go from output to input
            // so that the nodes are created ready for the connections from the preceding layer as they are
            // created.
            this.InitializeOutputNodes(outputNodeCount, startingOutputVariance);
            this.InitializeHiddenNodes(hiddenNodeCount, startingOutputVariance);
            this.InitializeInputNodes(inputNodeCount, startingOutputVariance);
        }

        public void Query(List<double> inputList)
        {
            // Parallelize
            for (var i = 0; i < inputList.Count; i++)
            {
                this.inputNodes[i].GenerateOutput(inputList[i]);
            }
        }

        private void InitializeInputNodes(int inputNodeCount, double startingOutputVariance)
        {
            this.inputNodes = new List<Node>();

            for (var i = 0; i < inputNodeCount; i++)
            {
                this.inputNodes.Add(new Node(this.hiddenNodes, 0.4d, this.random));
            }
        }

        private void InitializeHiddenNodes(int hiddenNodeCount, double startingOutputVariance)
        {
            this.hiddenNodes = new List<Node>();

            for (var i = 0; i < hiddenNodeCount; i++)
            {
                this.hiddenNodes.Add(new Node(this.outputNodes, 0.4d, this.random));
            }
        }

        private void InitializeOutputNodes(int outputNodeCount, double startingOutputVariance)
        {
            this.outputNodes = new List<Node>();
            
            for (var i = 0; i < outputNodeCount; i++)
            {
                this.outputNodes.Add(new Node(new List<Node>(), 0.0d, this.random));
            }
        }
    }
}
