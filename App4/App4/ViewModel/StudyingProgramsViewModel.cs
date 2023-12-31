﻿using App4.Models;
using App4.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App4.ViewModels
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
