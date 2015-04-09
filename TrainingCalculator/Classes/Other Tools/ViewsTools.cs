using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Shell;
using System.Collections;
using TrainingCalculator.Tools;
using System.Diagnostics;
using System.Text;
using TrainingCalculator.Classes.Other_Tools;
namespace TrainingCalculator.Classes.Other_Tools
{
    public class ViewsTools
    {
        public String generatePreviouslySavedWorkoutsText()
        {
            String previouslySavedWorkoutsText = "";
            SetModelDAOImpl databaseTools = new SetModelDAOImpl();
            IList<SetModel> SetsList = databaseTools.getAllSetsFromDB();
            StringBuilder strBuilder = new StringBuilder();
            //SetModel currentSet in SetsList
            for (int i = 0; i < SetsList.Count; i++)
            {
                SetModel currentSet = SetsList[i];
                strBuilder.AppendLine("Workout ID : " + currentSet.WorkoutID + " \n SetID :" + currentSet.SetID + " Amount of reps :" + currentSet.Reps + " Weight :" + currentSet.Weight + "\n");
                if (i == SetsList.Count - 1)
                {
                    strBuilder.AppendLine(" \n Additional Excersises : " + currentSet.AdditionalExcersises);
                }
            }
            previouslySavedWorkoutsText = strBuilder.ToString();
            return previouslySavedWorkoutsText;
        }
        public string setTextInSetsDescriptionArea(Dictionary<int, TemporarySetModel> allSets)
        {
            string textToSetInComponent = "";

            foreach (var item in allSets)
            {
                int numberOfSet = item.Key;
                TemporarySetModel currentSet = item.Value;
                string currentLine = "TemporartySetData " + numberOfSet + " : " + currentSet.weight + " x " + currentSet.reps + " reps \n";
                textToSetInComponent = textToSetInComponent + currentLine;
            }

            string asistanceExcersises = (String)PhoneApplicationService.Current.State["assistanceExcersises"];

            return textToSetInComponent + " \n \n" + asistanceExcersises;
        }
    }
}
