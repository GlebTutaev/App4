using App4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Text;
using System.Threading.Tasks;

namespace App4.Services
{
    public interface IStudyingProgramsServices 
    {
        Task<ObservableCollection<StudyingPrograms>> getProgram();
    }
}
