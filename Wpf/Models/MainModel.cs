using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf.ViewModels;

namespace Wpf.Models
{
    public class MainModel : BaseViewModel
    {

        public MainModel()
        {

        }

        private UserControl content;

        public UserControl ContentWindow
        {
            get { return content; }
            set 
            { 
                content = value;
                OnPropertyChanged("ContentWindow");
            }
        }

        internal void SetNewContent(UserControl userControl)
        {
            ContentWindow = userControl;
        }

    }
}
