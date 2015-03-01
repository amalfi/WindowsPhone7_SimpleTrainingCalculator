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
    public class TrainingWeightsGeneratorService
    {
        //Function which get collection of all checboxes from first view and return selected excersise and selected rep schema
        public Dictionary<string, string> setTypeOfExcersiseAndRepSchema(Dictionary<string, bool?> mapOfCheckboxValues)
        {
            Dictionary<string,string> checkedBoxesValues = new Dictionary<string,string>();
            SetDAO setDao = new SetDAO();
            foreach (var item in mapOfCheckboxValues)
            {
                if (item.Value == true)
                {
                    String currentKey = item.Key;
                    //-----------------------------------------------------------Excersise Names
                    if (currentKey.Equals("squatChecked"))
                    {
                        checkedBoxesValues.Add("excersiseName", item.Key.ToString());
                    }
                    if (currentKey.Equals("deadliftChecked"))
                    {
                        checkedBoxesValues.Add("excersiseName", item.Key.ToString());
                    }
                    if (currentKey.Equals("benchPressChecked"))
                    {
                        checkedBoxesValues.Add("excersiseName", item.Key.ToString());
                    }
                    //-----------------------------------------------------------Rep schemas
                    if (currentKey.Equals("fiveFiveChecked"))
                    {
                        checkedBoxesValues.Add("repSchema", item.Key.ToString());
                    }
                    if (currentKey.Equals("sixSixChecked"))
                    {
                        checkedBoxesValues.Add("repSchema", item.Key.ToString());
                    }
                    if (currentKey.Equals("threeThreeChecked"))
                    {
                        checkedBoxesValues.Add("repSchema", item.Key.ToString());

                    }      
                }
            }
            return checkedBoxesValues;
                
        }

        public Dictionary<int, Set> setMapOfSetsWithWeightForGivenExcersiseAndRepSchema(Dictionary<string, string> checkboxesDictionary, double maximumWeightForChoosedExcersise)
        {
            Dictionary<int, Set> generatedSet = new Dictionary<int, Set>();

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

            return generatedSet;
        }

        private Dictionary<int, Set> generateListOfSetsFor55(double maximumWeightForChoosedExcersise)
        {
            //Addidtional info : after every weeke you add 2% of your maximum RPM to every working set
            Dictionary<int, Set> listOfSets = new Dictionary<int, Set>();
            //1.Od wagi zadanej odejmujesz 12 %
            //Waga zadana -12 % - ostatnia seria robocza danego cwiczenia
            //Od ostatniej serii roboczej danego cwiczenia odejmujesz po 10% az bedziesz mial 5 serii roboczych
            double percentValueFromMaximumWeight = 0.12 * maximumWeightForChoosedExcersise;

            double lastWorkingSet = maximumWeightForChoosedExcersise - percentValueFromMaximumWeight;
            Set fifthSet = new Set(lastWorkingSet, 5, 5);
            double fourthWorkingSet = lastWorkingSet-0.1*maximumWeightForChoosedExcersise;
            Set fourthSet = new Set(fourthWorkingSet, 5, 5);
            double thirdWorkingSet = fourthWorkingSet - 0.1 * maximumWeightForChoosedExcersise;
            Set thirdSet = new Set(thirdWorkingSet, 5, 5);
            double secondWorkingSet = thirdWorkingSet - 0.1 * maximumWeightForChoosedExcersise;
            Set secondSet = new Set(secondWorkingSet, 5, 5);
            double firstWorkingSet = secondWorkingSet - 0.1 * maximumWeightForChoosedExcersise;
            Set firstSet = new Set(firstWorkingSet, 5, 5);

            listOfSets.Add(1, firstSet);
            listOfSets.Add(2, secondSet);
            listOfSets.Add(3, thirdSet);
            listOfSets.Add(4, fourthSet);
            listOfSets.Add(5, fifthSet);

            return listOfSets;
        }

        private Dictionary<int, Set> generateListOfSetsFor66(double maximumWeightForChoosedExcersise)
        {
            //if you are able to do 6x6 sets with 30 seconds rest, you add 2% to your working sets
            Dictionary<int, Set> listOfSets = new Dictionary<int, Set>();
            double workingSetValue = 0.7 * maximumWeightForChoosedExcersise;
            for (int i = 0; i < 5; i++)
            {
                Set currentSet = new Set(workingSetValue, 6, i);
                listOfSets.Add(i, currentSet);
            }

            return listOfSets;
        }

        private Dictionary<int, Set> generateListOfSetsFor33(double maximumWeightForChoosedExcersise)
        {
            Dictionary<int, Set> listOfSets = new Dictionary<int, Set>();
            double workingSetValue = 0.9 * maximumWeightForChoosedExcersise;
            for (int i = 0; i < 3; i++)
            {
                Set currentSet = new Set(workingSetValue, 3, 3);
                listOfSets.Add(i,currentSet);
            }

            return listOfSets;
        }
    }
}
