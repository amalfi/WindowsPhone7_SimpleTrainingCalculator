using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCalculator.Tools
{
    interface SetModelDAO
    {
        void saveWorkoutToDB();
        IList<SetModel> getAllSetsFromDB();
    }
}
