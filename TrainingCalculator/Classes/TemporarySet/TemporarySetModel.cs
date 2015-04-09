using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Diagnostics;

namespace TrainingCalculator.Tools
{
    public class TemporarySetModel
    {
        public double weight { get; set; }
        public int reps { get; set; }
        public int setNumber { get; set; }

        public TemporarySetModel(double weight, int reps, int setNumber)
        {
            this.weight = weight;
            this.reps = reps;
            this.setNumber = setNumber;
        }

    }
}
