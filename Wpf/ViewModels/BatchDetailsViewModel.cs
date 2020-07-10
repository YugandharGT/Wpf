using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Wpf.Commands;
using Wpf.Services;
using Wpf.Views;

namespace Wpf.ViewModels
{
    public class BatchDetailsViewModel: BaseViewModel 
    {
        public BatchDetailsViewModel()
        {
            //LoadData(); //Not loading after an event
            LoadDataToCombobox();
        }
        public ObservableCollection<Faculty> FacultyDropdown { get; private set; }

        
        private Faculty cmbSelectedItem;
        public Faculty CmbSelectedValue
        {
            get { return cmbSelectedItem; }
            set
            {
                if (value != cmbSelectedItem)
                {
                    cmbSelectedItem = value;
                    OnPropertyChanged("CmbSelectedItem");
                }
            }
        }
        private void LoadDataToCombobox()
        {
            Faculty faculty = new Faculty() { };
            IFaculty facultyObj = new FacultyService(new Data.WpfDbContext());
            FacultyDropdown = new ObservableCollection<Faculty>(facultyObj.GetDetails());
        }

        private void LoadDataToCombobox(int argInt)
        {
            IBatch facultyObj = new BatchService(new Data.WpfDbContext());
            Batch populate = facultyObj.GetBatchDetails(argInt);
            
            IFaculty entity = new FacultyService(new Data.WpfDbContext());
            var facultyList = entity.GetDetails();
            //select from observe collections
            //CmbSelectedValue = populate.FacultyId;
            
            if (facultyList.Any(p => p.Id == populate.FacultyId))
            {
                BatchInstance = populate;
            }
        }

        private Batch batch;

        public Batch BatchInstance
        {
            get { return batch; }
            set { batch = value; OnPropertyChanged("BatchInstance"); }
        }

        private ObservableCollection<Participant> participantDetails;
        public ObservableCollection<Participant> ParticipantDetails
        {
            get
            {
                return participantDetails;
            }
            set
            {
                participantDetails = value;
                OnPropertyChanged("ParticipantDetails");
            }
        }


         private void LoadData()
        {
            Participant faculty = new Participant() { };
            IParticipant facultyObj = new ParticipantService(new Data.WpfDbContext());
            ParticipantDetails = new ObservableCollection<Participant>(facultyObj.GetDetails());
        }


        #region ButtonCommand Event

        //public UICommand AddParticipantCommand
        //{
        //    get { return new UICommand(RedirectToParticipant); }

        //}

        //public void RedirectToParticipant(object parameter)
        //{
        //    Participant participant = new Participant() { Id = id, Name = name, DateOfBirth = dob, Batchid = batchId, CourseRegistered = course, DateOfRegistration = registration };
        //    IParticipant participantObj = new ParticipantService(new Data.WpfDbContext());
        //    participantObj.AddParticipant(participant);
        //}

        UICommand textChangedCommand;
        public UICommand TextChangedCommand
        {
            get
            {
                if (this.textChangedCommand == null)
                {
                    textChangedCommand = new UICommand(TextChangedMethod); 
                }
                return this.textChangedCommand;
            }

        }

        private void TextChangedMethod(object obj)
        {
            if (int.TryParse(obj.ToString(), out int validInt))
            {
                LoadDataToCombobox(validInt);
                LoadData();
            }
        }

        public UICommand AddBatchCommand
        {
            get { return new UICommand(BatchForm, CanExecuteBatch); }

        }

        public bool CanExecuteBatch(object parameter)
        {
            return true;
        }

        public void BatchForm(object parameter)
        {
            
        }

        public UICommand AddParticipantCommand
        {
            get { return new UICommand(AddParticipant); }
        }

        private void AddParticipant(object obj)
        {
            AddParticipantView addParticipantView = new AddParticipantView();
            addParticipantView.Show();

        }

        private bool _isOpen;
        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                if (_isOpen == value) return;
                _isOpen = value;

                OnPropertyChanged("IsOpen");
            }
        }
        #endregion
    }
}
