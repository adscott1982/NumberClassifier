using AndyTools.Utilities;
using System;
using System.Collections.Generic;

namespace NeuralNetworks
{
    class Node
    {
        private List<Link> outputLinks;
        private List<Link> inputLinks;

        private double inputSum;

        public Node()
        {
            this.outputLinks = new List<Link>();
            this.inputLinks = new List<Link>();
        }

        public void GenerateDownstreamLinks(List<Node> linkNodes, double strengthDeviation, Random random)
        {
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

        /// <summary>
        /// Add a Link to the input links collection.
        /// </summary>
        /// <param name="link">The input link.</param>
        public void AddInputLink(Link link)
        {
            this.inputLinks.Add(link);
        }

        /// <summary>
        /// Add an input to the node.
        /// </summary>
        /// <param name="input"></param>
        public void Input(double input)
        {
            this.inputSum += input;
        }

        /// <summary>
        /// Determine the sigma output value based on the sum of inputs, then output to all links.
        /// </summary>
        public void GenerateOutput(double? output = null)
        {
            // If output was not passed as parameter, calculate based on sigma value
            this.Output = output.HasValue ? (double)output : 1 / (1 + Math.Exp(-this.inputSum));
            
            // Output to any links
            foreach(var link in this.outputLinks)
            {
                link.Fire(this.Output);
            }

            // Clear sum ready for next query
            this.inputSum = 0;
        }

        public void BackPropagateError(double? outputError = null)
        {
            // Sum the total incoming link weights
            var totalLinkWeight = 0d;
            foreach(var link in this.inputLinks)
            {
                totalLinkWeight += link.Weight;
            }

            if (!outputError.HasValue)
            {
                outputError = 0;
                foreach(var link in this.outputLinks)
                {
                    outputError += link.Error;
                }
            }

            var totalError = outputError.Value;

            // Squash total link weight with Sigmoid function
            //totalLinkWeight = 1 / (1 + Math.Exp(-totalLinkWeight));

            // Backpropagate the errors propertionally to the link weights
            foreach (var link in this.inputLinks)
            {
                var proportion = link.Weight / totalLinkWeight;
                link.BackPropagateError(totalError * proportion);
            }
        }
    }
}
