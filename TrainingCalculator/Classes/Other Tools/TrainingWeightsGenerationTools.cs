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
using TrainingCalculator.Tools;
using System.Diagnostics;

namespace TrainingCalculator
{
    public class TrainingWeightsGenerationTools
    {
        //Function which get collection of all checboxes from first view and return selected excersise and selected rep schema
        public Dictionary<string, string> setTypeOfExcersiseAndRepSchema(Dictionary<string, bool?> mapOfCheckboxValues)
        {
            Dictionary<string,string> checkedBoxesValues = new Dictionary<string,string>();
            foreach (var item in checkedBoxesValues)
            {
                Debug.WriteLine(item.Key);
                Debug.WriteLine(item.Value);
            }

            TemporarySetModelTools setDao = new TemporarySetModelTools();
            foreach (var item in mapOfCheckboxValues)
            {
                if (item.Value == true)
                {
                    String currentKey = item.Key;
                    //-----------------------------------------------------------Excersise Names
                    switch (currentKey)
                    {
                        case "squatChecked":
                            checkedBoxesValues.Add("excersiseName", item.Key.ToString());
                            break;
                        case "deadliftChecked":
                            checkedBoxesValues.Add("excersiseName", item.Key.ToString());
                            break;
                        case "benchPressChecked":
                            checkedBoxesValues.Add("excersiseName", item.Key.ToString());
                            break;
                        case "fiveFiveChecked":
                            checkedBoxesValues.Add("repSchema", item.Key.ToString());
                            break;
                        case "sixSixChecked":
                            checkedBoxesValues.Add("repSchema", item.Key.ToString());
                            break;
                        case "threeThreeChecked":
                            checkedBoxesValues.Add("repSchema", item.Key.ToString());
                            break;
                    }
                }
            }
            return checkedBoxesValues;
                
        }

        public Dictionary<int, TemporarySetModel> setMapOfSetsWithWeightForGivenExcersiseAndRepSchema(Dictionary<string, string> checkboxesDictionary, double maximumWeightForChoosedExcersise)
        {
            Dictionary<int, TemporarySetModel> generatedSet = new Dictionary<int, TemporarySetModel>();
            //checkboxes dictionary jest puste
            Debug.WriteLine("Size of checkboxesDictionary :" + checkboxesDictionary.Count);
            foreach (var item in checkboxesDictionary)
            {
                Debug.WriteLine(item.Key);
                Debug.WriteLine(item.Value);
            }

            String excersiseName = checkboxesDictionary["excersiseName"];
            String repSchema = checkboxesDictionary["repSchema"];
            if (repSchema == "fiveFiveChecked")
            {
                generatedSet = generateListOfSetsFor55(maximumWeightForChoosedExcersise);
            }
            if (repSchema == "sixSixChecked")
            {
                generatedSet = generateListOfSetsFor66(maximumWeightForChoosedExcersise);
            }
            if (repSchema == "threeThreeChecked")
            {
                generatedSet = generateListOfSetsFor33(maximumWeightForChoosedExcersise);
            }

            foreach (var item in generatedSet)
            {
                Debug.WriteLine(item.Key);
                Debug.WriteLine(item.Value);
            }
            return generatedSet;
        }

        private Dictionary<int, TemporarySetModel> generateListOfSetsFor55(double maximumWeightForChoosedExcersise)
        {
            //Addidtional info : after every weeke you add 2% of your maximum RPM to every working set
            Dictionary<int, TemporarySetModel> listOfSets = new Dictionary<int, TemporarySetModel>();
            double percentValueFromMaximumWeight = 0.12 * maximumWeightForChoosedExcersise;

            double lastWorkingSet = maximumWeightForChoosedExcersise - percentValueFromMaximumWeight;
            TemporarySetModel fifthSet = new TemporarySetModel(lastWorkingSet, 5, 5);
            double fourthWorkingSet = lastWorkingSet-0.1*maximumWeightForChoosedExcersise;
            TemporarySetModel fourthSet = new TemporarySetModel(fourthWorkingSet, 5, 5);
            double thirdWorkingSet = fourthWorkingSet - 0.1 * maximumWeightForChoosedExcersise;
            TemporarySetModel thirdSet = new TemporarySetModel(thirdWorkingSet, 5, 5);
            double secondWorkingSet = thirdWorkingSet - 0.1 * maximumWeightForChoosedExcersise;
            TemporarySetModel secondSet = new TemporarySetModel(secondWorkingSet, 5, 5);
            double firstWorkingSet = secondWorkingSet - 0.1 * maximumWeightForChoosedExcersise;
            TemporarySetModel firstSet = new TemporarySetModel(firstWorkingSet, 5, 5);

            listOfSets.Add(1, firstSet);
            listOfSets.Add(2, secondSet);
            listOfSets.Add(3, thirdSet);
            listOfSets.Add(4, fourthSet);
            listOfSets.Add(5, fifthSet);

            return listOfSets;
        }

        private Dictionary<int, TemporarySetModel> generateListOfSetsFor66(double maximumWeightForChoosedExcersise)
        {
            //if you are able to do 6x6 sets with 30 seconds rest, you add 2% to your working sets
            Dictionary<int, TemporarySetModel> listOfSets = new Dictionary<int, TemporarySetModel>();
            double workingSetValue = 0.7 * maximumWeightForChoosedExcersise;
            for (int i = 0; i < 5; i++)
            {
                TemporarySetModel currentSet = new TemporarySetModel(workingSetValue, 6, i);
                listOfSets.Add(i, currentSet);
            }

            return listOfSets;
        }

        private Dictionary<int, TemporarySetModel> generateListOfSetsFor33(double maximumWeightForChoosedExcersise)
        {
            Dictionary<int, TemporarySetModel> listOfSets = new Dictionary<int, TemporarySetModel>();
            double workingSetValue = 0.9 * maximumWeightForChoosedExcersise;
            for (int i = 0; i < 3; i++)
            {
                TemporarySetModel currentSet = new TemporarySetModel(workingSetValue, 3, 3);
                listOfSets.Add(i,currentSet);
            }

            return listOfSets;
        }
    }
}
