using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Collections;
using TrainingCalculator.Tools;
using System.Text;


namespace TrainingCalculator
{
    public partial class FirstPage : PhoneApplicationPage
    {
        private const string strConnectionString = @"isostore:/SetsDB.sdf";
        public FirstPage()
        {
            InitializeComponent();
        }


        private void createNewDatabase(object sender, RoutedEventArgs e)
        {
            string strConnectionString = @"isostore:/SetsDB.sdf";

            using (SetForDBContext setdb = new SetForDBContext(strConnectionString))
            {
                if (setdb.DatabaseExists() == false)
                {
                    setdb.CreateDatabase();
                    MessageBox.Show("Sets Database Created Successfully!!!");
                }
                else
                {
                    MessageBox.Show("Sets Database already exists!!!");
                }
            }
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