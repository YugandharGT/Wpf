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
    public class ParticipantSearchViewModel : BaseViewModel
    {
        private ObservableCollection<Participant> filterParticipant;
        public ObservableCollection<Participant> FilterParticipant
        {
            get
            {
                return filterParticipant;
            }
            set
            {
                filterParticipant = value;
                OnPropertyChanged("FilterParticipant");
            }
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

        public UICommand ParticipantSearchCommand
        {
            get { return new UICommand(SearchParticipant); }

        }

        public void SearchParticipant(object parameter)
        {
            IEnumerable<Participant> faculty = null;
            IParticipant facultyObj = new ParticipantService(new Data.WpfDbContext());
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
            FilterParticipant = new ObservableCollection<Participant>(faculty);
        }
    }
}
