using RPGUtility.Model;
using RPGUtility.Models;
using RPGUtility.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace RPGUtility.ViewModel
{
    class TestViewModel:ViewModelBase
    {
        private readonly Character _character;
       // private Stat[] _statsSource;
        private readonly TestModel _model;
        private Stat _select;
        public ObservableCollection<Stat> Stats
        {
            get; set;
        }

        public ObservableCollection<SkillCategory> SkillsList { get; set; }
       
        //public ObservableCollection<SkillCategory> SkillList { get; set; }
        public Stat SelectedItem
        {
            get
            {
                Trace.WriteLine("Selcet");
                return _select; }
            set { _select = value;
                OnPropertyChanged(nameof(SelectedItem));
                //Trace.WriteLine(_select.Content);
                Sum = _select.value;
                OnPropertyChanged(nameof(Sum));
            }
        }

        public int Sum { get; set; }

        public RelayCommand Add10 { get; }
        public RelayCommand Sub10 { get; }
        public RelayCommand Add20 { get; }
        public RelayCommand Sub20 { get; }
        public RelayCommand Add30 { get; }
        public RelayCommand Sub30 { get; }

        public RelayCommand Roll { get; }

        public RelayCommand OkCommand { get; }

        public bool ResultVisibility { get; set; }//zmienna do wyświetlania okna z wynnikiem

        public string HeadText { get; set; }//nagłówek okna z wynikiem
        public string BodyText { get; set; }//wynik dla okna z wynikiem
        public System.Windows.Media.Brush Color { get; set; }
        public string CharacterName { get; set; }
        public TestViewModel(Character character)
        {
            _select = new Stat("", "", 0);
            _character = character;
            CharacterName=character.Name;
            //Stats = new Stat[8];
            ResultVisibility = false;
            Stats = new ObservableCollection<Stat>();
            SkillsList = new ObservableCollection<SkillCategory>();
            _model = new TestModel();
            LoadStats(_character);
            Add10 = new RelayCommand((object parameter) => { if (Sum + 10 <= 100) Sum += 10; OnPropertyChanged(nameof(Sum)); }, CanExecuteMyCommand);
            Add20 = new RelayCommand((object parameter) => { if (Sum + 20 <= 100) Sum += 20; OnPropertyChanged(nameof(Sum)); }, CanExecuteMyCommand);

            Add30 = new RelayCommand((object parameter) => { if (Sum + 30 <= 100) Sum += 30; OnPropertyChanged(nameof(Sum)); }, CanExecuteMyCommand);
            Sub10 = new RelayCommand((object parameter) => { if (Sum - 10 >= 0) Sum -= 10; OnPropertyChanged(nameof(Sum)); }, CanExecuteMyCommand);
            Sub20 = new RelayCommand((object parameter) => { if (Sum - 20 >= 0) Sum -= 20; OnPropertyChanged(nameof(Sum)); }, CanExecuteMyCommand);
            Sub30 = new RelayCommand((object parameter) => { if (Sum - 30 >= 0) Sum -= 30; OnPropertyChanged(nameof(Sum)); }, CanExecuteMyCommand);
            Roll = new RelayCommand((object parameter) => {
                int k = Dice.k100();
                if (Sum > 0)
                { 
                if (k <= Sum)
                {
                    Color= System.Windows.Media.Brushes.Green;
                    HeadText = "Test Pomyślny!";
                    BodyText = "Wynik: "+k+"/"+ Sum;
                }
                else
                {
                    Color = System.Windows.Media.Brushes.Red;
                    HeadText = "Test Nieudany!";
                    BodyText = "Wynik: " + k + "/" + Sum;
                }
                OnPropertyChanged(nameof(Color));
                OnPropertyChanged(nameof(HeadText));
                OnPropertyChanged(nameof(BodyText));
                ResultVisibility = true;
                OnPropertyChanged(nameof(ResultVisibility));
                }
            }, CanExecuteMyCommand);
            OkCommand = new RelayCommand((object parameter) => {
                ResultVisibility = false;
                OnPropertyChanged(nameof(ResultVisibility));

            }, CanExecuteMyCommand);
        }
        private async void LoadStats(Character character)
        {
            Statistic pom = await _model.GetStats(character);
            Stats.Add( new Stat("WW", "Walka Wręcz (WW): Cecha sprawności Bohatera w walce", pom.WeaponSkill));
            Stats.Add(new Stat("US", "Umiejętności Strzeleckie (US): Cecha sprawności Bohatera w strzelaniu", pom.BallisticSkill));
            Stats.Add(new Stat("K", "Krzepa (K): Cecha tężyzny fizycznej Bohatera", pom.Strength));
            Stats.Add(new Stat("Odp", "Odporność (Odp): Cecha odporności fizycznej Bohatera", pom.Toughness));
            Stats.Add(new Stat("Zr", "Zręczność (Zr): Cecha sprawności fizycznej Bohatera", pom.Agility));
            Stats.Add(new Stat("Int", "Inteligencja (Int): Cecha sprawności intelektualnej Bohatera", pom.Intelligence));
            Stats.Add(new Stat("SW", "Siła Woli (SW): Cecha umiejętności koncentracji Bohatera", pom.Willpower));
            Stats.Add(new Stat("Ogd", "Ogłada (Ogd): Cecha charyzmy Bohatera", pom.Fellowship));

            OnPropertyChanged(nameof(Stats));
            List<SkillCategory> skills = await _model.GetSkills(character);
            foreach (var item in skills)
            {
                SkillsList.Add(item);
                //Trace.WriteLine(item.Name);
            }
            OnPropertyChanged(nameof(SkillsList));
        }
        private void Roll100()
        {
            // Random rnd = new Random(System.DateTime.Now.Millisecond);
            int attemps = Dice.k30() + 5;
            int result = 0;
            for (int i = 0; i < attemps; i++)
            {
                result = Dice.k100();
                //result = rnd.Next(1000, 20000) / 1000;

                App.Current.Dispatcher.Invoke(new Action(() => Sum = result));
                OnPropertyChanged(nameof(Sum));

                Thread.Sleep(20);
            }
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
