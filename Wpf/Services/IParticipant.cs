using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Services
{
    public interface IParticipant
    {
        IEnumerable<Participant> GetDetails();
        IEnumerable<Participant> GetDetailsById(int id);
        IEnumerable<Participant> GetDetailsByName(string name);
        Participant AddParticipant(Participant participant);
    }
}
