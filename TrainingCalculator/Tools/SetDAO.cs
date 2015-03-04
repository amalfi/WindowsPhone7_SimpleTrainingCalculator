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
    public class SetDAO
    {
        public Dictionary<int, Set> sets = new Dictionary<int, Set>();
        public Dictionary<string, string> settedExcersiseNameAndRepetitionSchema = new Dictionary<string, string>();

        public Dictionary<string, Set> getexcersiseNameAndRepetitionSchema(Dictionary<string, Set> excersiseNameAndRepetitionSchema)
        {
            return excersiseNameAndRepetitionSchema;
        }

        public void setExcersiseNameAndRepetitionSchema(Dictionary<string, bool?> checkboxesDictionary)
        {
            TrainingWeightsGeneratorService trainingWeightGeneratorService = new TrainingWeightsGeneratorService();
            settedExcersiseNameAndRepetitionSchema = trainingWeightGeneratorService.setTypeOfExcersiseAndRepSchema(checkboxesDictionary);
        }

        public Dictionary<int, Set> getAllSets(Dictionary<int,Set> introData)
        {
            return sets;
        }

        public void setAllSets(double maximumWeightForGivenExcersise)
        {
            TrainingWeightsGeneratorService twss = new TrainingWeightsGeneratorService();
            foreach (var item in settedExcersiseNameAndRepetitionSchema)
            {
                Debug.WriteLine(item.Key);
                Debug.WriteLine(item.Value);
            }
            sets = twss.setMapOfSetsWithWeightForGivenExcersiseAndRepSchema(settedExcersiseNameAndRepetitionSchema, maximumWeightForGivenExcersise);
        }
    }
}
