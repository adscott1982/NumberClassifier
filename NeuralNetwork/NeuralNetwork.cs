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

            this.CreateNodesInCollection(out this.inputNodes, inputNodeCount);
            this.CreateNodesInCollection(out this.hiddenNodes, hiddenNodeCount);
            this.CreateNodesInCollection(out this.outputNodes, outputNodeCount);

            this.CreateLinksBetweenNodeLayers(this.inputNodes, this.hiddenNodes, startingOutputVariance);
            this.CreateLinksBetweenNodeLayers(this.hiddenNodes, this.outputNodes, startingOutputVariance);
        }

        private void CreateLinksBetweenNodeLayers(List<Node> firstNodeLayer, List<Node> secondNodeLayer, double startingOutputVariance)
        {
            foreach(var node in firstNodeLayer)
            {
                node.GenerateDownstreamLinks(secondNodeLayer, startingOutputVariance, this.random);
            }
        }

        public int Query(List<double> inputList)
        {
            // Parallelize
            // Put inputs into InputNodes, and cause them to generate outputs
            for (var i = 0; i < inputList.Count; i++)
            {
                this.inputNodes[i].GenerateOutput(inputList[i]);
            }

            // Hidden node process inputs - generate outputs
            foreach (var hiddenNode in this.hiddenNodes)
            {
                hiddenNode.GenerateOutput();
            }

            // Get node index with correct value
            int answerIndex = -1;
            var currentMax = double.MinValue;

            for (var i = 0; i < this.outputNodes.Count; i++)
            {
                this.outputNodes[i].GenerateOutput();

                if (this.outputNodes[i].Output > currentMax)
                    answerIndex = i;
            }
            
            return answerIndex;
        }

        private void CreateNodesInCollection(out List<Node> collection, int count)
        {
            collection = new List<Node>();

            for (var i = 0; i < count; i++)
            {
                collection.Add(new Node());
            }
        }
    }
}
