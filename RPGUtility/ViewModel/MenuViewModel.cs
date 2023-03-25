using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RPGUtility.ViewModel
{
    class MenuViewModel : ViewModelBase
    {
        public string Welcome => "welocme to d";

        public ICommand NavigateCommand { get; set; }
    }
}
