using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Commands;
using Wpf.Services;

namespace Wpf.ViewModels
{
    public class ParticipantViewModel : BaseViewModel
    {
        public ParticipantViewModel()
        {

        }

        #region ViewModel Properties

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime dob;

        public DateTime DateOfBirth
        {
            get { return dob; }
            set { dob = value; }
        }

        private int batchId;

        public int BatchId
        {
            get { return batchId; }
            set { batchId = value; }
        }


        private string course;

        public string CourseRegistered
        {
            get { return course; }
            set { course = value; }
        }

        private DateTime registration;

        public DateTime DateOfRegistration
        {
            get { return registration; }
            set { registration = value; }
        }

        #endregion
        #region ButtonCommand Event
        private ICommand _myCommand;
        public ICommand AddParticipantCommand
        {
            get 
            {
                if (_myCommand != null) return _myCommand;
                _myCommand = new UICommand(AddParticipant);  return _myCommand; 
            }

        }

        public void AddParticipant(object parameter)
        {
            Participant participant  = new Participant() { Id = id, Name = name, DateOfBirth = dob, Batchid= batchId, CourseRegistered = course, DateOfRegistration = registration };
            IParticipant participantObj = new ParticipantService(new Data.WpfDbContext());
            participantObj.AddParticipant(participant);
        }
        #endregion
    }
}
