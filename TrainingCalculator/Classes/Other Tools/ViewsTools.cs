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
using System.Windows.Navigation;
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

        public void handleDataFromSecondView(String maxWeightString, bool? assistanceExcersiseChecked)
        {
           
            TemporarySetModelTools setDAO = new TemporarySetModelTools();
            string typedMaximumWeightString = maxWeightString;//maximumWeight.Text.ToString();
          
            double typedMaximumWeightDouble;
            Double.TryParse(typedMaximumWeightString, out typedMaximumWeightDouble);

            string excersiseName = PhoneApplicationService.Current.State["excersiseName"].ToString();
            string repSchema = PhoneApplicationService.Current.State["repSchema"].ToString();
            Dictionary<string, string> excersiseAndRepetitionSchema = new Dictionary<string, string>();
            excersiseAndRepetitionSchema.Add("excersiseName", excersiseName);
            excersiseAndRepetitionSchema.Add("repSchema", repSchema);

            setDAO.settedExcersiseNameAndRepetitionSchema = excersiseAndRepetitionSchema;
            setDAO.setAllSets(typedMaximumWeightDouble);

            string assistanceExcersises = "";
            if(assistanceExcersiseChecked==true)
            {
                if (excersiseName.Equals("squatChecked"))
                {
                    assistanceExcersises = "Good Mornings : \n 5 sets x 10 reps  \n Lying Dead Curls : \n 5 sets x 12 reps  \n Leg Extensions : \n 5 sets x 12 reps";
                }
                else if (excersiseName.Equals("deadliftChecked"))
                {
                    assistanceExcersises = "Pull Ups : 5 sets x 10 reps \n One Arm Dumbell Row : 5 sets x 10 reps \n Horizontal Row : 5 sets x 10 reps  \n Biceps Dumbell Curls : 5 sets x 10 reps";
                }
                else if (excersiseName.Equals("benchPressChecked"))
                {
                    assistanceExcersises = "Military Shoulder Press :  5 sets x 10 Reps \n Shoulder lateral raises : 5 sets x 15 reps \n Triceps Pushdowns : 5 sets x 10 reps";
                }
            }
            PhoneApplicationService.Current.State["assistanceExcersises"] = assistanceExcersises;

            try
            {
                // string asistanceExcersises = (String)PhoneApplicationService.Current.State["assistanceExcersises"];

                PhoneApplicationService.Current.State["allSets"] = setDAO.sets;
                //dodanie informacji o cwiczeniach asystujacych jezeli byl zaznaczony checkbox
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.StackTrace.ToString());
            }

           
        } 
    }
}
