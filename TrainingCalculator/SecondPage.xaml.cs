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
using TrainingCalculator.Tools;
using System.Diagnostics;
using Microsoft.Phone.Shell;

namespace TrainingCalculator
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e) //next page handler
        {
            bool validationDoneProperly = true;
            SetDAO setDAO = new SetDAO();
            string typedMaximumWeightString = maximumWeight.Text.ToString();
            if (typedMaximumWeightString.Equals(""))
            {
                MessageBox.Show("Please, put value in maximum weight textbox");
                validationDoneProperly = false;
            }
            double typedMaximumWeightDouble;
            Double.TryParse(typedMaximumWeightString, out typedMaximumWeightDouble);

            string excersiseName = PhoneApplicationService.Current.State["excersiseName"].ToString();
            string repSchema = PhoneApplicationService.Current.State["repSchema"].ToString();
            Dictionary<string, string> excersiseAndRepetitionSchema = new Dictionary<string, string>();
            excersiseAndRepetitionSchema.Add("excersiseName", excersiseName);
            excersiseAndRepetitionSchema.Add("repSchema", repSchema);

            setDAO.settedExcersiseNameAndRepetitionSchema = excersiseAndRepetitionSchema;
            setDAO.setAllSets(typedMaximumWeightDouble);

            try
            {
                string asistanceExcersises = (String)PhoneApplicationService.Current.State["assistanceExcersises"];
                
                PhoneApplicationService.Current.State["allSets"] = setDAO.sets;
                //dodanie informacji o cwiczeniach asystujacych jezeli byl zaznaczony checkbox
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.StackTrace.ToString());
            }

            if (validationDoneProperly)
            {
                NavigationService.Navigate(new Uri("/SummaryPage.xaml", UriKind.Relative));
            }
         }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void assistanceExcersisesChecked(object sender, RoutedEventArgs e) //turn assistance excersises checked
        {
            string assistanceExcersises = "";
            string excersiseName = PhoneApplicationService.Current.State["excersiseName"].ToString();
          
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

            PhoneApplicationService.Current.State["assistanceExcersises"] = assistanceExcersises;
        }
    }
}