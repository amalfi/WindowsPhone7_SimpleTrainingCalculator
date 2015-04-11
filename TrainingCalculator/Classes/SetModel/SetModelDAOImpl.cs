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
using TrainingCalculator.Classes.TemporarySet;
namespace TrainingCalculator.Tools
{
    public class SetModelDAOImpl : SetModelDAO
    {
        private const string strConnectionString = @"isostore:/SetsDB.sdf";
        
        public void saveWorkoutToDB()
        {

            Dictionary<int, TemporarySetModel> allSets = (Dictionary<int, TemporarySetModel>)PhoneApplicationService.Current.State["allSets"];
            DatabaseTools dbTools = new DatabaseTools();

            int lastIdNumber = dbTools.getLastIdFromDatabase();
            int lastWorkoutIdNumber = dbTools.getLastWorkoutIdFromDatabase();
       
            using (SetModelContext setdb = new SetModelContext(strConnectionString))
            {
                lastWorkoutIdNumber += 1;
                foreach (var item in allSets)
                {
                    int numberOfSet = item.Key;
                    TemporarySetModel currentSet = item.Value;
                    double currentWeight = currentSet.weight;
                    int currentReps = currentSet.reps;
                    String  asistanceExcersises = (String)PhoneApplicationService.Current.State["assistanceExcersises"];

                    SetModel set = new SetModel
                    {
                        WorkoutID = lastWorkoutIdNumber.ToString(),
                        SetID =  (lastWorkoutIdNumber + lastIdNumber).ToString(),
                        Reps = currentReps.ToString(),
                        Weight = currentWeight.ToString(),
                        SetNumber = numberOfSet.ToString(),
                        AdditionalExcersises = asistanceExcersises.ToString()
                    };
                    try
                    {
                        setdb.SetsForDB.InsertOnSubmit(set);
                        setdb.SubmitChanges();

                        lastIdNumber += 1;
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.StackTrace.ToString());
                        MessageBox.Show(exception.StackTrace.ToString());
                    }
                }
                MessageBox.Show("Workout Plan Added Successfully!!!");
            }

        }
 

        public IList<SetModel> getAllSetsFromDB()
        {
            IList<SetModel> SetsList = null;
            using (SetModelContext setdb = new SetModelContext(strConnectionString))
            {
                IQueryable<SetModel> EmpQuery = from SetForDB in setdb.SetsForDB select SetForDB;
                try
                {
                    SetsList = EmpQuery.ToList();
                }
                catch (Exception exception)
                {

                    Debug.WriteLine(exception.StackTrace.ToString());
                   // MessageBox.Show(exception.StackTrace.ToString());
                }
                  
            }

            return SetsList;
        }

      
    }

  
}
