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

namespace TrainingCalculator.Tools
{
    public class SetDAO
    {
        private Dictionary<string, Set> sets = new Dictionary<string, Set>();
        private Dictionary<string, string> excersiseNameAndRepetitionSchema = new Dictionary<string, string>();

        public Dictionary<string, Set> getexcersiseNameAndRepetitionSchema(Dictionary<string, Set> excersiseNameAndRepetitionSchema)
        {
            return excersiseNameAndRepetitionSchema;
        }

        public void setExcersiseNameAndRepetitionSchema(Dictionary<string, string> excersiseNameAndRepetitionSchema)
        {
            //function body
        }

        public Dictionary<string, Set> getAllSets(Dictionary<string,Set> introData)
        {
            return sets;
        }

        public void setAllSets()
        {
              //function body
        }
    }
}
