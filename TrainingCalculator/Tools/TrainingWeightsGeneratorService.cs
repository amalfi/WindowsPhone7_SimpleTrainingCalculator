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

namespace TrainingCalculator
{
    public class TrainingWeightsGeneratorService
    {
        //Function which get collection of all checboxes from first view and return selected excersise and selected rep schema
        public void setTypeOfExcersiseAndRepSchema(Dictionary<string,bool?> mapOfCheckboxValues)
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
                    if (currentKey.Equals("repSchema"))
                    {
                        checkedBoxesValues.Add("excersiseName", item.Key.ToString());

                    }      
                }
            }
            setDao.setExcersiseNameAndRepetitionSchema(checkedBoxesValues);
        }

        public void setMapOfSetsWithWeightForGivenExcersiseAndRepSchema(Dictionary<string, string> checkboxesDictionary, int maximumWeightForChoosedExcersise)
        {
            String excersiseName = checkboxesDictionary["excersiseName"];
            String repSchema = checkboxesDictionary["repSchema"];
            

            Dictionary<int,int> mapOfSetsWithWeighForEachSet = new Dictionary<int,int>(); 


        }
    }
}
