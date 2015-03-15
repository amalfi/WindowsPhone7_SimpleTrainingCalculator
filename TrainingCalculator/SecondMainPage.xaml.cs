using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.Phone.Shell;
using TrainingCalculator;
using TrainingCalculator.Tools;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.IO;


namespace TrainingCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {

        private const string strConnectionString = @"isostore:/SetsDB.sdf";
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
            squatCheckBox.IsChecked = false;
            deadliftCheckBox.IsChecked = false;
        }

        private void squat_checked(object sender, RoutedEventArgs e)
        {
            squatChecked = squatCheckBox.IsChecked;
            deadliftCheckBox.IsChecked = false;
            benchPressCheckBox.IsChecked = false;
        }

        private void deadlift_checked(object sender, RoutedEventArgs e)
        {
            deadliftChecked = deadliftCheckBox.IsChecked;
            squatCheckBox.IsChecked = false;
            benchPressCheckBox.IsChecked = false;
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e) //5x5 schema checked
        {
            fiveFiveChecked = checkBox1.IsChecked;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
        }

        private void checkBox3_Checked(object sender, RoutedEventArgs e) //6x6 schema checked
        {
            sixSixChecked = checkBox3.IsChecked;
            checkBox2.IsChecked = false;
            checkBox1.IsChecked = false;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e) //3x3 schema checked
        {
            threeThreeChecked = checkBox2.IsChecked;
            checkBox1.IsChecked = false;
            checkBox3.IsChecked = false;
        }

        private void nextStepButtonHandler(object sender, RoutedEventArgs e)
        {
            bool validationDoneProperly = true;
            String excersiseName = "";
            String repSchema = "";
            TrainingWeightsGeneratorService trainingWeightsGeneratorService = new TrainingWeightsGeneratorService();
            Dictionary<string, bool?> checkboxesDictionary = new Dictionary<string, bool?>();
            //In this moment we add all of checkboxex boolean values do proper dictionary
            checkboxesDictionary.Add("squatChecked", squatChecked);
            checkboxesDictionary.Add("deadliftChecked", deadliftChecked);
            checkboxesDictionary.Add("benchPressChecked", benchPressChecked);
            checkboxesDictionary.Add("fiveFiveChecked", fiveFiveChecked);
            checkboxesDictionary.Add("sixSixChecked", sixSixChecked);
            checkboxesDictionary.Add("threeThreeChecked", threeThreeChecked);

            foreach (var item in checkboxesDictionary)
            {
                Debug.WriteLine(item.Key);
                Debug.WriteLine(item.Value);
            }

            SetDAO setDAO = new SetDAO();
            setDAO.setExcersiseNameAndRepetitionSchema(checkboxesDictionary); //It can be used for saving to database in the future

            Dictionary<string, string> settedSchema = new Dictionary<string,string>();
            settedSchema = setDAO.settedExcersiseNameAndRepetitionSchema;
            try
            {    
               excersiseName = settedSchema["excersiseName"];
               repSchema = settedSchema["repSchema"];
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please, select excersise name and repetition schema");
                validationDoneProperly = false;

                Debug.WriteLine(exception.StackTrace.ToString());
            }

            PhoneApplicationService.Current.State["excersiseName"] = excersiseName;
            PhoneApplicationService.Current.State["repSchema"] = repSchema;
            if (validationDoneProperly)
            {
                NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
            }
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e) //DbTest button
        {
         
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }


       
    }
}