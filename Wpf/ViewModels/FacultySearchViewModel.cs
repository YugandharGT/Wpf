using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Commands;
using Wpf.Navigation;
using Wpf.Services;

namespace Wpf.ViewModels
{
    public class FacultySearchViewModel :BaseViewModel
    {
        public FacultySearchViewModel()
        {
            
        }

        private Filter filter;

        public Filter Filter
        {
            get
            {
                return filter;
            }

            set
            {
                filter = value;
                OnPropertyChanged("Filter");
            }
        }

        private string param;

        public string FilterParameter
        {
            get { return param; }
            set { param = value; }
        }

        public UICommand SearchFacultyCommand
        {
            get { return new UICommand(SearchFaculty, CanSearchFaculty); }

        }

        public bool CanSearchFaculty(object parameter)
        {
            return true;
        }

        public void SearchFaculty(object parameter)
        {
            IEnumerable<Faculty> faculty=null;
            IFaculty facultyObj = new FacultyService(new Data.WpfDbContext());
            if (Filter == Filter.ById)
            {
                if (int.TryParse(FilterParameter, out int res))
                {
                    faculty = facultyObj.GetDetailsById(res);
                }
                
            }
            else if (Filter == Filter.ByName)
            {
                faculty = facultyObj.GetDetailsByName(FilterParameter);
            }
            FilterFaculty = new ObservableCollection<Faculty>(faculty);
        }

        private ObservableCollection<Faculty> filterFaculty;
        public ObservableCollection<Faculty> FilterFaculty 
        {
            get
            {
                return filterFaculty;
            }
            set
            {
                filterFaculty = value;
                OnPropertyChanged("FilterFaculty");
            }
        }
    }
}
