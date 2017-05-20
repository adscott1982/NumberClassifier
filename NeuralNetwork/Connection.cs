using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Connection
    {
        /// <summary>
        /// Create a connection.
        /// </summary>
        /// <param name="origin">The origin node.</param>
        /// <param name="target">The target node.</param>
        /// <param name="strength">The strength of the connection - between 0.0 and 1.0.</param>
        public Connection(Node origin, Node target, double strength)
        {
            this.Origin = origin;
            this.Target = target;
            this.Strength = strength;
        }

        /// <summary>
        /// The node which originates the connection.
        /// </summary>
        public Node Origin { get; }

        /// <summary>
        /// The node which is the target of the connection.
        /// </summary>
        public Node Target { get; }

        /// <summary>
        /// The strength of the connection - between 0.0 and 1.0.
        /// </summary>
        public double Strength { get; set; }
    }
}
