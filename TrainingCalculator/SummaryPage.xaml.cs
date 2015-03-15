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


namespace TrainingCalculator
{
    public partial class SummaryPage : PhoneApplicationPage
    {
        private const string strConnectionString = @"isostore:/SetsDB.sdf";

        public SummaryPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) //onReady event on SummaryPage.xaml
        {
            Dictionary<int, Set> allSets = (Dictionary<int, Set>)PhoneApplicationService.Current.State["allSets"];
            string valueOfsetsWithDescriptionTextArea = setTextInSetsDescriptionArea(allSets);
            setsWithDescriptionTextArea.Text = valueOfsetsWithDescriptionTextArea;

            PhoneApplicationService.Current.State["setsWithDescriptionTextArea"] = setsWithDescriptionTextArea;
        }

        private string setTextInSetsDescriptionArea(Dictionary<int, Set> allSets)
        {
            string textToSetInComponent = "";

            foreach (var item in allSets)
            {
                int numberOfSet = item.Key;
                Set currentSet = item.Value;
                string currentLine = "Set " + numberOfSet + " : " + currentSet.weight + " x " + currentSet.reps + " reps \n";
                textToSetInComponent = textToSetInComponent + currentLine;
            }

            string asistanceExcersises = (String)PhoneApplicationService.Current.State["assistanceExcersises"];

            return textToSetInComponent + " \n \n" + asistanceExcersises;
        }

        private void sendEmailWithCalculationsHandler(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SendEmailPage.xaml", UriKind.Relative));
        }

        private void saveWorkoutToDB(object sender, RoutedEventArgs e)
        {
            DatabaseTools databseTools = new DatabaseTools();
            databseTools.saveWorkoutToDB();
        }
    }

}