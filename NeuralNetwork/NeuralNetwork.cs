namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        private int inputNodes;
        private int hiddenNodes;
        private int outputNodes;
        private double learningRate;

        public NeuralNetwork(int inputNodes, int hiddenNodes, int outputNodes, double learningRate)
        {
            this.inputNodes = inputNodes;
            this.hiddenNodes = hiddenNodes;
            this.outputNodes = outputNodes;
            this.learningRate = learningRate;
        }
    }
}
