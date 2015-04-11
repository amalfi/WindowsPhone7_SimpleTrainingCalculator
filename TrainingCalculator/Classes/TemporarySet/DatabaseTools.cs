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

namespace TrainingCalculator.Classes.TemporarySet
{
    public class DatabaseTools
    {
        string strConnectionString = @"isostore:/SetsDB.sdf";

        public int getLastIdFromDatabase()
        {
            string strConnectionString = @"isostore:/SetsDB.sdf";

            List<int> listOfSetsIds = new List<int>();
            int lastIdNumber = 0;

            IList<SetModel> SetsList = null;
            using (SetModelContext Empdb = new SetModelContext(strConnectionString))
            {
                try
                {
                    IQueryable<SetModel> SetQuery = from Set in Empdb.SetsForDB select Set;
                    SetsList = SetQuery.ToList();
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.StackTrace.ToString());
                    MessageBox.Show("Error during listing records from database");
                }
            }

            foreach (SetModel currentSetFromList in SetsList)
            {
                String currentID = currentSetFromList.SetID;
                int currentIdInt = Convert.ToInt32(currentID);
                listOfSetsIds.Add(currentIdInt);
            }
            int[] sortedIds = listOfSetsIds.ToArray();
            Array.Sort(sortedIds);
            if (sortedIds.Length != 0)
            {
                lastIdNumber = sortedIds[sortedIds.Length-1];
            }


            return lastIdNumber;
        }
        public int getLastWorkoutIdFromDatabase()
        {
            string strConnectionString = @"isostore:/SetsDB.sdf";

            List<int> listOfSetsIds = new List<int>();
            int lastIdNumber = 0;
            //--------------------------------------------------------------------
            IList<SetModel> SetsList = null;
            using (SetModelContext Empdb = new SetModelContext(strConnectionString))
            {
                IQueryable<SetModel> SetQuery = from Set in Empdb.SetsForDB select Set;
                SetsList = SetQuery.ToList();
            }

            foreach (SetModel currentSetFromList in SetsList)
            {
                String currentID = currentSetFromList.WorkoutID;
                int currentIdInt = Convert.ToInt32(currentID);
                listOfSetsIds.Add(currentIdInt);
            }
            int[] sortedIds = listOfSetsIds.ToArray();
            Array.Sort(sortedIds);
            if (sortedIds.Length != 0)
            {
                lastIdNumber = sortedIds[sortedIds.Length - 1];
            }
            return lastIdNumber;
        }
        public void createNewDB()
        {
           
            using (SetModelContext setdb = new SetModelContext(strConnectionString))
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

        public bool? checkDB()
        {
            bool? validation = true;
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
                    validation = false;
                    Debug.WriteLine(exception.StackTrace.ToString());
                    // MessageBox.Show(exception.StackTrace.ToString());
                }

            }

            return validation;
        }

    }
}
