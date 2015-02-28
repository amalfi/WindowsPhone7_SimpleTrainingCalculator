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

namespace TrainingCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool? benchPressChecked; //bool? variable can take three values - true, false and null (main difference between bool and bool?)
        bool? squatChecked;
        bool? deadliftChecked;

        bool? fiveFiveChecked;
        bool? sixSixChecked;
        bool? threeThreeChecked;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void benchPress_checked(object sender, RoutedEventArgs e)
        {
            benchPressChecked = benchPressCheckBox.IsChecked;
        }

        private void squat_checked(object sender, RoutedEventArgs e)
        {
            squatChecked = squatCheckBox.IsChecked;
        }

        private void deadlift_checked(object sender, RoutedEventArgs e)
        {
            deadliftChecked = deadliftCheckBox.IsChecked;
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e) //5x5 schema checked
        {
            fiveFiveChecked = checkBox1.IsChecked;
        }

        private void checkBox3_Checked(object sender, RoutedEventArgs e) //6x6 schema checked
        {
            sixSixChecked = checkBox3.IsChecked;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e) //3x3 schema checked
        {
            threeThreeChecked = checkBox2.IsChecked;
        }

        private void nextStepButtonHandler(object sender, RoutedEventArgs e)
        {
            TrainingWeightsGeneratorService trainingWeightsGeneratorService = new TrainingWeightsGeneratorService();
            Dictionary<string, bool?> checkboxesDictionary = new Dictionary<string, bool?>();
            //In this moment we add all of checkboxex boolean values do proper dictionary
            checkboxesDictionary.Add("squatChecked", squatChecked);
            checkboxesDictionary.Add("deadliftChecked", deadliftChecked);
            checkboxesDictionary.Add("benchPressChecked", benchPressChecked);
            checkboxesDictionary.Add("fiveFiveChecked", fiveFiveChecked);
            checkboxesDictionary.Add("sixSixChecked", sixSixChecked);
            checkboxesDictionary.Add("threeThreeChecked", threeThreeChecked);

            trainingWeightsGeneratorService.setTypeOfExcersiseAndRepSchema(checkboxesDictionary);


            NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
        }

        
       /*
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
            //generating list of trainings sets based on :
        }
        */

       
    }
}