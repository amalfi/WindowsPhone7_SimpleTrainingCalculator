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

namespace TrainingCalculator
{
    public partial class PreviouslySavedWorkout : PhoneApplicationPage
    {

        public PreviouslySavedWorkout()
        {
            InitializeComponent();
        }

        private void previouslySavedTextAreaHandler(object sender, RoutedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void button1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseTools databaseTools = new DatabaseTools();
            IList<SetForDB> SetsList = databaseTools.getAllSetsFromDB();
            StringBuilder strBuilder = new StringBuilder();
                foreach (SetForDB currentSet in SetsList)
                {
                    strBuilder.AppendLine("Workout ID : " + currentSet.WorkoutID + " \n SetID :" + currentSet.SetID + "Amount of reps :" + currentSet.Reps + "Weight :" + currentSet.Weight + "\n");
                }

                previouslySavedWorkoutTextArea.Text = strBuilder.ToString();
           
        }
    }
}