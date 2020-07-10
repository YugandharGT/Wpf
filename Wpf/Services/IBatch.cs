using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Services
{
    public interface IBatch
    {
        Batch AddBatch(Batch batch);
        Batch GetBatchDetails(int id);
    }
}
