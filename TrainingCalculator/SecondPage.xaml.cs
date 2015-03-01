﻿using System;
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
            SetDAO setDAO = new SetDAO();
            string typedMaximumWeightString = maximumWeight.Text;
            double typedMaximumWeightDouble;
            Double.TryParse(typedMaximumWeightString, out typedMaximumWeightDouble);
            setDAO.setAllSets(typedMaximumWeightDouble);

            NavigationService.Navigate(new Uri("/SummaryPage.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}