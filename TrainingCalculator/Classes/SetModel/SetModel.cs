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
using System.Data.Linq.Mapping;

namespace TrainingCalculator.Tools
{
    /*
        public double weight { get; set; }
        public int reps { get; set; }
        public int setNumber { get; set; } 
    */
  
        [Table]
        public class SetModel
        {
            [Column(IsPrimaryKey = true)]
            public String SetID
            {
                get;
                set;
            }
            [Column(CanBeNull = false)]
            public String Weight
            {
                get;
                set;
            }
            [Column(CanBeNull = false)]
            public String Reps
            {
                get;
                set;
            }
            [Column(CanBeNull = false)]
            public String SetNumber
            {
                get;
                set;
            }
            [Column(CanBeNull = false)]
            public String WorkoutID
            {
                get;
                set;
            }
            [Column(CanBeNull = false)]
            public String AdditionalExcersises
            {
                get;
                set;
            }

          
        }
    
}
