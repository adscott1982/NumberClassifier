namespace NeuralNetwork
{
    class Link
    {
        /// <summary>
        /// Create a link.
        /// </summary>
        /// <param name="origin">The origin node.</param>
        /// <param name="target">The target node.</param>
        /// <param name="weight">The weight of the link - between 0.0 and 1.0.</param>
        public Link(Node origin, Node target, double weight)
        {
            this.Origin = origin;
            this.Target = target;
            this.Weight = weight;

            // Add link to target node's incoming link list
            this.Target.AddInputLink(this);
        }

        /// <summary>
        /// The node which originates the link.
        /// </summary>
        public Node Origin { get; }

        /// <summary>
        /// The node which is the target of the link.
        /// </summary>
        public Node Target { get; }

        /// <summary>
        /// The weight of the link - between 0.0 and 1.0.
        /// </summary>
        public double Weight { get; }

        public void Fire(double outputValue)
        {
            this.Target.Input(outputValue * this.Weight);
        }

        public void BackPropagateError(double error, double proportion)
        {
            // Update weight based on the error

            // Update any upstream objects
        }
    }
}
