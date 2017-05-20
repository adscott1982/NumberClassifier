using AndyTools.Utilities;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    class InputNode : Node
    {
        private List<Connection> connections;

        public InputNode(List<Node> connectionNodes, double strengthDeviation, Random random)
        {
            this.connections = new List<Connection>();

            foreach(Node node in connectionNodes)
            {
                var strength = random.NextDouble().Clamp(0.5 - strengthDeviation, 0.5 + strengthDeviation);
                this.connections.Add(new Connection(this, node, strength));
            }
        }
    }
}
