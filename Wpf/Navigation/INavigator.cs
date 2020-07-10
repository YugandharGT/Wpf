using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Navigation
{
    public interface INavigator
    {
        
    }

    public enum ViewType
    {
        Faculty,
        SearchFaculty,
        AddBatch,
        BatchDetails,
        AddParticipant,
        SearchPaticipant
    }

    public enum Filter
    {
        ById,
        ByName
    }
}
