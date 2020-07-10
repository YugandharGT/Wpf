using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using Wpf.Commands;
using Wpf.Views;

namespace Wpf.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Switching Custom Controls on content section
        private BaseViewModel selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set 
            { 
                selectedViewModel = value;
                OnPropertyChanged(nameof(selectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
        #endregion 

        public ContentControl Content { get; set; }
        
        public MainWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            
        }

        private BaseViewModel _LoadedControl;

        public BaseViewModel LoadedControl
        {
            get { return _LoadedControl; }
            set
            {
                _LoadedControl = value;

                OnPropertyChanged("LoadedControl");

            }
        }


    }
}
