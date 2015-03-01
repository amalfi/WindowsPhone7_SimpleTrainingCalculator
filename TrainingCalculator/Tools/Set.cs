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
    public class Set
    {
        double weight { get; set; }
        int reps { get; set; }
        int setNumber { get; set; }

        public Set(double weight, int reps, int setNumber)
        {
            this.weight = weight;
            this.reps = reps;
            this.setNumber = setNumber;
        }

    }
}
