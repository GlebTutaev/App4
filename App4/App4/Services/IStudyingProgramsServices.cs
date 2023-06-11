using SelectionCommittee.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Text;
using System.Threading.Tasks;

namespace SelectionCommittee.Services
{
    public interface IStudyingProgramsServices
    {
        Task<ObservableCollection<StudyingPrograms>> getProgram();
    }
}
