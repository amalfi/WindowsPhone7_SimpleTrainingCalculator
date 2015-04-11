using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;

namespace TrainingCalculator.Tools
{
    public class SetModelContext : DataContext
    {
        public SetModelContext(string connectionString) : base(connectionString)
        {
        }
        public Table<SetModel> SetsForDB
        {
            get
            {
                return this.GetTable<SetModel>();
            }
        }
    }
}
