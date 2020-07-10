using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wpf.Commands;
using Wpf.Services;

namespace Wpf.ViewModels
{
    public class BatchViewModel: BaseViewModel
    {
        private int batchId;

        public int BatchId  
        {
            get { return batchId; }
            set { batchId = value; OnPropertyChanged("BatchId"); }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; OnPropertyChanged("StartDate"); }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged("EndDate"); }
        }

        private string stream;

        public string Stream
        {
            get { return stream; }
            set { stream = value; OnPropertyChanged("Stream"); }
        }

        private int facultyId;

        public int FacultyId
        {
            get { return facultyId; }
            set { facultyId = value; OnPropertyChanged("FacultyId"); }
        }

        #region ButtonCommand Event

        public UICommand AddBatchCommand
        {
            get { return new UICommand(AddBatch,CanExecuteBatch); }

        }

        private bool CanExecuteBatch(object arg)
        {
            return true;
        }

        private void AddBatch(object obj)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to save the details?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (DateTime.Compare(endDate, startDate) < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Start Date should be greater than enddate", "Information", MessageBoxButtons.OK);
                    return;
                }
                Batch batch = new Batch() { BatchId = batchId, StartDate = startDate, EndDate = endDate, Stream = stream, FacultyId = facultyId };
                IBatch batch1 = new BatchService(new Data.WpfDbContext());
                batch1.AddBatch(batch);
            }
        }

        private UICommand myCommand;
        public UICommand StartDateChangeCommand
        {
            get
            {
                if (myCommand != null) return myCommand;
                myCommand = new UICommand(StartDateChangeEvent); return myCommand;
            }

        }

        private void StartDateChangeEvent(object obj)
        {
            if (DateTime.TryParse(obj.ToString(), out DateTime dateTime))
            {
                startDate = dateTime;
            }
        }

        private UICommand _myCommand;
        public UICommand EndDateChangeCommand
        {
            get
            {
                if (_myCommand != null) return _myCommand;
                _myCommand = new UICommand(EndDateChangeEvent); return _myCommand;
            }

        }

        private void EndDateChangeEvent(object obj)
        {
            if (DateTime.TryParse(obj.ToString(), out DateTime dateTime))
            {
                endDate = dateTime;
            }
        }

        #endregion
    }
}
