using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace RPGUtility.ViewModel
{
    internal class CharacterChooseViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private CharacterChooseModel _characterchooseModel;
        private ObservableCollection<Character> _characters;
        private Character _selectedCharacter;
        public RelayCommand CancelCommand { get; }

        public RelayCommand DeleteCharacterCommand { get; }
        public RelayCommand SubmitCommand { get; }
        public RelayCommand NewCharacterCommand { get; }
        public CharacterChooseViewModel(NavigationService navigation,Campaign? campaign)
        {
            _navigationService = navigation;
            _characterchooseModel = new CharacterChooseModel(campaign);
            _characters = new ObservableCollection<Character>();
            Task.Run(Load);
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new MenuViewModel(_navigationService,campaign)); }, CanExecuteMyCommand);
            SubmitCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService, _selectedCharacter ,campaign)); }, CanExecuteMyCommand);
            NewCharacterCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterCreatorViewModel(_navigationService,campaign)); }, CanExecuteMyCommand);
            //  DeleteCharacterCommand = new RelayCommand(async (object parameter) => { await _characterChooseModel.Delete(_selectedCharacter); await Load(); }, CanExecuteMyCommand);
        }
        public ObservableCollection<Character> Characters
        {
            get
            {
                return _characters;
            }
            set
            {
                _characters = value;
                OnPropertyChanged(nameof(Characters));
            }
        }
        public Character SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
            }
        }
        private async Task Load()
        {

            List<Character> camp = await _characterchooseModel.GetAll();
            App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                Characters.Clear();
                foreach (var item in camp)
                {
                    Characters.Add(item);
                }
            });
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
