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
using TrainingCalculator.Classes.Other_Tools;

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
            if (!checkIfGivenValueIsNumber())
            {
                MessageBox.Show("Entered value is NOT a number !");
            }
        }

        private bool checkIfGivenValueIsNumber()
        {
            string valueFromTextBox = maximumWeight.Text.ToString();
            double n;
            bool isNumeric = double.TryParse(valueFromTextBox, out n);

            return isNumeric;
        }

        private void button1_Click(object sender, RoutedEventArgs e) //next page handler
        {
            bool validationDoneProperly = true;
            String maxWeightString = maximumWeight.Text.ToString();
            bool? assistanceExcersiseChecked = assistanceExcersisesCheckbox.IsChecked;

            if (maxWeightString.Equals(""))
            {
                MessageBox.Show("Please, put value in maximum weight textbox");
                validationDoneProperly = false;
            }
          
            ViewsTools viewsTools = new ViewsTools();
            viewsTools.handleDataFromSecondView(maxWeightString, assistanceExcersiseChecked);
            
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
         
        }
    }
}