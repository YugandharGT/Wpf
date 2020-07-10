using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Navigation;
using Wpf.ViewModels;
using Wpf.Views;

namespace Wpf.Commands
{
    /// <summary>
    /// It represents the implementation of page switching on content template
    /// </summary>
    public class UpdateViewCommand : ICommand
    {
        MainWindowViewModel mainWindow;

        public UpdateViewCommand()
        {
        }

        public UpdateViewCommand(MainWindowViewModel viewModel)
        {
            this.mainWindow = viewModel;
        }
        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == ViewType.Faculty.ToString())
            {
                mainWindow.SelectedViewModel = new FacultyViewModel();
            }
            else if (parameter.ToString() == ViewType.SearchFaculty.ToString())
            {
                mainWindow.SelectedViewModel = new FacultySearchViewModel();
            }
            else if (parameter.ToString() == ViewType.AddBatch.ToString())
            {
                mainWindow.SelectedViewModel = new BatchViewModel();
            }
            else if (parameter.ToString() == ViewType.BatchDetails.ToString())
            {
                mainWindow.SelectedViewModel = new BatchDetailsViewModel();
            }
            else if (parameter.ToString() == ViewType.AddParticipant.ToString())
            {
                //mainWindow.SelectedViewModel = new ParticipantViewModel();
                AddParticipantView addParticipantView = new AddParticipantView();
                addParticipantView.Show();
                
            }
            else if (parameter.ToString() == ViewType.SearchPaticipant.ToString())
            {
                mainWindow.SelectedViewModel = new ParticipantSearchViewModel();
            }

        }
    }
}
