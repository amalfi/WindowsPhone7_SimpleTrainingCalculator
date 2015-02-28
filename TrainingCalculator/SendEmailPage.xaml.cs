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

namespace TrainingCalculator
{
    public partial class SendEmailPage : PhoneApplicationPage
    {
        public SendEmailPage()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Przycisk wysylajacy e-meile
            var emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "message subject";
            emailComposeTask.Body = "message body";
            emailComposeTask.To = "mberendt546@gmail.com";
            emailComposeTask.Cc = "mberendt546@gmail.com";
            emailComposeTask.Bcc = "mberendt546@gmail.com";

            emailComposeTask.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SummaryPage.xaml", UriKind.Relative));
        }
    }
}