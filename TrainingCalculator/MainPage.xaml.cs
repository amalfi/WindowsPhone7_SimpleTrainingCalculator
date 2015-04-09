using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Collections;
using TrainingCalculator.Tools;
using System.Text;
using TrainingCalculator.Classes.TemporarySet;


namespace TrainingCalculator
{
    public partial class FirstPage : PhoneApplicationPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void createNewDatabase(object sender, RoutedEventArgs e)
        {
            DatabaseTools dbTools = new DatabaseTools();
            dbTools.createNewDB();
        }

        private void createNewTrainingSchema(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SecondMainPage.xaml", UriKind.Relative));
        }

        private void showAllPreviousTrainings(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PreviouslySavedWorkout.xaml", UriKind.Relative));
        }
    }
}