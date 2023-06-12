using App4.Models;
using Newtonsoft.Json.Linq;
using SelectionCommittee.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SelectionCommittee.ViewModels
{
    public class StudyingProgramsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        IStudyingProgramsServices _rest = DependencyService.Get<IStudyingProgramsServices>();

        public StudyingProgramsViewModel()
        {
            GetProgram();
        }

        public async void GetProgram()
        {
           var result = await _rest.getProgram();        
            if (result !=  null)
            {               
                StudyingPrograms = result;
            }            
        }

        private ObservableCollection<StudyingPrograms> studyingPrograms;

        public ObservableCollection<StudyingPrograms> StudyingPrograms
        {
            get 
            {
                //JToken token = studyingPrograms SelectToken("$.1[?(@.tv.img != null)]");
                return studyingPrograms;
            }
            set 
            { 
                studyingPrograms = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StudyingPrograms"));
            }
        }

    }
}
