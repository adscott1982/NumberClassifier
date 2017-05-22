using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    public class TrainingItem
    {
        public List<double> Inputs { get; set; }

        public List<double> CorrectOutputs { get; set; }

        public int CorrectNumber { get; set; }
    }
}
