using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RPGUtility.ViewModel
{
    internal class DiceViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private int _rollResult;

        private int _attemps;

        public RelayCommand RollDiceCommand { get; }
        public int RollResult
        {
            get { return _rollResult; }
            set
            {
                _rollResult = value;
                OnPropertyChanged(nameof(RollResult));
            }
        }

        public int Attemps
        { 
            get { return _attemps; }
            set { _attemps=value; OnPropertyChanged(nameof(Attemps));}
        }
        public DiceViewModel(NavigationService navigationService)
        {

            _navigationService = navigationService;
            RollDiceCommand = new RelayCommand(DiceRoll, CanExecuteMyCommand);

        }

        private async Task Roll()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30()+5;
            int result = 0;
            for(int i=0;i< attemps; i++)
            {
                result = Dice.k20();
                //result = rnd.Next(1000, 20000) / 1000;
                App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                {
                    RollResult = result;
                });
                   // Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        private void DiceRoll(object parameter)
        {
            Task.Run(Roll);
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
