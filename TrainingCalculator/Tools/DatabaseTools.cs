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
namespace TrainingCalculator.Tools
{
    public class DatabaseTools
    {
        private const string strConnectionString = @"isostore:/SetsDB.sdf";

        public void saveWorkoutToDB()
        {

            Dictionary<int, Set> allSets = (Dictionary<int, Set>)PhoneApplicationService.Current.State["allSets"];
            int lastIdNumber = getLastIdFromDatabase();
            int lastWorkoutIdNumber = getLastWorkoutIdFromDatabase();
            //--------------------------------------------------------------------
            
            using (SetForDBContext setdb = new SetForDBContext(strConnectionString))
            {
                lastWorkoutIdNumber += 1;
                foreach (var item in allSets)
                {
                    int numberOfSet = item.Key;
                    Set currentSet = item.Value;
                    double currentWeight = currentSet.weight;
                    int currentReps = currentSet.reps;

                    SetForDB set = new SetForDB
                    {
                        //WorkoutID : pobranie ostatniego workout id z bazy i ustalenie workout id jako X+1 (przed petla)
                        WorkoutID = lastWorkoutIdNumber.ToString(),
                        SetID = lastIdNumber.ToString(),
                        Reps = currentReps.ToString(),
                        Weight = currentWeight.ToString(),
                        SetNumber = numberOfSet.ToString()
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
                        MessageBox.Show("Error during adding workout plan to the database. Probably database doesn't exist");
                    }
                }
                MessageBox.Show("Workout Plan Added Successfully!!!");
            }

        }

        public int getLastIdFromDatabase()
        {
            string strConnectionString = @"isostore:/SetsDB.sdf";

            List<int> listOfSetsIds = new List<int>();
            int lastIdNumber = 0;
            //--------------------------------------------------------------------
            IList<SetForDB> SetsList = null;
            using (SetForDBContext Empdb = new SetForDBContext(strConnectionString))
            {
                try
                {
                    IQueryable<SetForDB> SetQuery = from Set in Empdb.SetsForDB select Set;
                    SetsList = SetQuery.ToList();
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.StackTrace.ToString());
                    MessageBox.Show("Error during listing records from database");
                }
            }

            foreach (SetForDB currentSetFromList in SetsList)
            {
                String currentID = currentSetFromList.SetID;
                int currentIdInt = Convert.ToInt32(currentID);
                listOfSetsIds.Add(currentIdInt);
            }
            int[] sortedIds = listOfSetsIds.ToArray();
            Array.Sort(sortedIds);
            if (sortedIds.Length != 0)
            {
                lastIdNumber = sortedIds[0];
            }


            return lastIdNumber;
        }

        public int getLastWorkoutIdFromDatabase()
        {
            string strConnectionString = @"isostore:/SetsDB.sdf";

            List<int> listOfSetsIds = new List<int>();
            int lastIdNumber = 0;
            //--------------------------------------------------------------------
            IList<SetForDB> SetsList = null;
            using (SetForDBContext Empdb = new SetForDBContext(strConnectionString))
            {
                IQueryable<SetForDB> SetQuery = from Set in Empdb.SetsForDB select Set;
                SetsList = SetQuery.ToList();
            }

            foreach (SetForDB currentSetFromList in SetsList)
            {
                String currentID = currentSetFromList.WorkoutID;
                int currentIdInt = Convert.ToInt32(currentID);
                listOfSetsIds.Add(currentIdInt);
            }
            int[] sortedIds = listOfSetsIds.ToArray();
            Array.Sort(sortedIds);
            if (sortedIds.Length != 0)
            {
                lastIdNumber = sortedIds[0];
            }
            return lastIdNumber;
        }
        public IList<SetForDB> getAllSetsFromDB()
        {
            String strConnectionString = @"isostore:/SetsDB.sdf";
            IList<SetForDB> SetsList = null;
            using (SetForDBContext setdb = new SetForDBContext(strConnectionString))
            {
                IQueryable<SetForDB> EmpQuery = from SetForDB in setdb.SetsForDB select SetForDB;
                try
                {
                    SetsList = EmpQuery.ToList();
                }
                catch (Exception exception)
                {

                    Debug.WriteLine(exception.StackTrace.ToString());
                    MessageBox.Show("Error during select all records from database. Probably database doesn't exist");
                }
                  
            }

            return SetsList;
        }
    }
}
