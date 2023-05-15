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
    public class DiceViewModel:ViewModelBase
    {
        //private readonly NavigationService _navigationService;
        private int _rollResult;

        private int _attemps;

        public RelayCommand RollDiceCommand4 { get; }
        public RelayCommand RollDiceCommand6 { get; }
        public RelayCommand RollDiceCommand8 { get; }
        public RelayCommand RollDiceCommand10 { get; }
        public RelayCommand RollDiceCommand12 { get; }
        public RelayCommand RollDiceCommand20 { get; }
        public RelayCommand RollDiceCommand30 { get; }
        public RelayCommand RollDiceCommand100 { get; }
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
        public DiceViewModel()
        {

            //_navigationService = navigationService;
            RollDiceCommand4 = new RelayCommand((object parameter) => { Task.Run(Roll4); }, CanExecuteMyCommand);
            RollDiceCommand6 = new RelayCommand((object parameter) => { Task.Run(Roll6); }, CanExecuteMyCommand);
            RollDiceCommand8 = new RelayCommand((object parameter) => { Task.Run(Roll8); }, CanExecuteMyCommand);
            RollDiceCommand10 = new RelayCommand((object parameter) => { Task.Run(Roll10); }, CanExecuteMyCommand);
            RollDiceCommand12= new RelayCommand((object parameter) => { Task.Run(Roll12); }, CanExecuteMyCommand);
            RollDiceCommand20 = new RelayCommand((object parameter) => { Task.Run(Roll20); }, CanExecuteMyCommand);
            RollDiceCommand30 = new RelayCommand((object parameter) => { Task.Run(Roll30); }, CanExecuteMyCommand);
            RollDiceCommand100 = new RelayCommand((object parameter) => { Task.Run(Roll100); }, CanExecuteMyCommand);

        }
        /*    private void DiceRoll(object parameter)
            {
                int attemps = Dice.k30() + 5;
                int result = 0;
                for (int i = 0; i < attemps; i++)
                {
                    result = Dice.k20();
                    //result = rnd.Next(1000, 20000) / 1000;
                    RollResult = Dice.k30();
                }
            }*/
        private async Task Roll4()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k4();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        private async Task Roll6()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k6();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        private async Task Roll8()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k8();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        private async Task Roll10()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k10();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        private async Task Roll12()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k12();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        private async Task Roll20()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k20();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        private async Task Roll30()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k30();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        private async Task Roll100()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k100();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                Thread.Sleep(20);
            }
        }
        /*private async Task Roll()
             {
                 // Random rnd = new Random(System.DateTime.Now.Millisecond);
                 int attemps = Dice.k30()+5;
                 int result = 0;
                 for(int i=0;i< attemps; i++)
                 {
                     result = Dice.k20();
                     //result = rnd.Next(1000, 20000) / 1000;

                     App.Current.Dispatcher.Invoke(new Action(() => RollResult = result));
                     Thread.Sleep(20);
                 }
             }
*/
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
