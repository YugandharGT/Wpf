using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Wpf.Commands;
using Wpf.Models;
using Wpf.Views;
using Wpf.Services;
using Models;

namespace Wpf.ViewModels
{
    public class FacultyViewModel : BaseViewModel
    {
        public FacultyViewModel()
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

        private int experience;

        public int PreviousExperience
        {
            get { return experience; }
            set { experience = value; }
        }

        private string qualification;

        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        #endregion
        #region ButtonCommand Event

        public UICommand AddFacultyCommand
        {
            get { return new UICommand(GetFacultyForm, CanExecuteForm); }

        }

        public bool CanExecuteForm(object parameter)
        {
            return true;
        }

        public void GetFacultyForm(object parameter)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to save the details?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                Faculty faculty = new Faculty() { Id = id, Name = name, DateOfBirth = dob, PreviousExperience = experience, Qualification = qualification };
                IFaculty facultyObj = new FacultyService(new Data.WpfDbContext());
                facultyObj.AddFaculty(faculty);
            }
        }
        #endregion

        #region Unused Code
        //MainModel mainModel;
        //public UICommand FacultyFormCommand 
        //{
        //    //get
        //    //{
        //    //    return new UICommand(OpenFacultyForm);
        //    //}
        //    get; internal set;
        //}

        //public FacultyViewModel()
        //{
        //    FacultyFormCommand = new UICommand(OpenFacultyForm);
        //}

        //public FacultyViewModel(MainModel mainModel)
        //{
        //    this.mainModel = mainModel;
        //}

        //private bool CanOpenFacultyForm()
        //{
        //    return true;
        //}

        //private void OpenFacultyForm(object obj)
        //{
        //    FacultyViewModel facultyViewModel = new FacultyViewModel(mainModel);
        //    AddFacultyView facultyView = new AddFacultyView();
        //    facultyView.DataContext = facultyViewModel;
        //    mainModel.SetNewContent(facultyView);
        //}
        #endregion
    }
}
