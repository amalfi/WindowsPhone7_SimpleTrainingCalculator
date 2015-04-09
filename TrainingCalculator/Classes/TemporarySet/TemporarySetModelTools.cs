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
    public class TemporarySetModelTools
    {
        public Dictionary<int, TemporarySetModel> sets = new Dictionary<int, TemporarySetModel>();
        public Dictionary<string, string> settedExcersiseNameAndRepetitionSchema = new Dictionary<string, string>();

        public Dictionary<string, TemporarySetModel> getexcersiseNameAndRepetitionSchema(Dictionary<string, TemporarySetModel> excersiseNameAndRepetitionSchema)
        {
            return excersiseNameAndRepetitionSchema;
        }

        public void setExcersiseNameAndRepetitionSchema(Dictionary<string, bool?> checkboxesDictionary)
        {
            TrainingWeightsGenerationTools trainingWeightGeneratorService = new TrainingWeightsGenerationTools();
            settedExcersiseNameAndRepetitionSchema = trainingWeightGeneratorService.setTypeOfExcersiseAndRepSchema(checkboxesDictionary);
        }

        public Dictionary<int, TemporarySetModel> getAllSets(Dictionary<int,TemporarySetModel> introData)
        {
            return sets;
        }

        public void setAllSets(double maximumWeightForGivenExcersise)
        {
            TrainingWeightsGenerationTools twss = new TrainingWeightsGenerationTools();
            foreach (var item in settedExcersiseNameAndRepetitionSchema)
            {
                Debug.WriteLine(item.Key);
                Debug.WriteLine(item.Value);
            }
            sets = twss.setMapOfSetsWithWeightForGivenExcersiseAndRepSchema(settedExcersiseNameAndRepetitionSchema, maximumWeightForGivenExcersise);
        }
    }
}
