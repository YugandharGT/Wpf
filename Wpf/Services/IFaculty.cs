using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Services
{
    public interface IFaculty
    {
       IEnumerable<Faculty> GetDetailsById(int id);
       IEnumerable<Faculty> GetDetailsByName(string Name);
       Faculty AddFaculty(Faculty faculty);
       IEnumerable<Faculty> GetDetails();
    }
}
