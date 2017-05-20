using AndyTools.Utilities;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    class Node
    {
        private List<Link> outputLinks;
        private List<Link> inputLinks;

        private double inputSum;

        public Node(List<Node> linkNodes, double strengthDeviation, Random random)
        {
            this.outputLinks = new List<Link>();
            this.inputLinks = new List<Link>();

            foreach (Node node in linkNodes)
            {
                var weight = random.NextDouble().Clamp(0.5 - strengthDeviation, 0.5 + strengthDeviation);
                this.outputLinks.Add(new Link(this, node, weight));
            }
        }

        /// <summary>
        /// The output value for the node.
        /// </summary>
        public double Output { get; private set; }

        public void AddInput(double input)
        {
            this.inputSum += input;
        }

        /// <summary>
        /// Determine the sigma output value based on the sum of inputs, then output to all links.
        /// </summary>
        public void GenerateOutput(double output = -100d)
        {
            // If output was not passed as parameter, calculate based on sigma value
            output = output == -100d ? 1 / (1 + Math.Exp(-this.inputSum)) : output;
            
            // Output to any links
            foreach(var link in this.outputLinks)
            {
                link.Fire(output);
            }

            // Clear sum ready for next query
            this.inputSum = 0;
        }

        public void BackPropagateError(double targetOutput)
        {
            // Modify the weights of incoming links based on the error between the output and target output
        }
    }
}
