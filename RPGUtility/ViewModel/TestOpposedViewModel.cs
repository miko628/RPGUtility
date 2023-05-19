using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGUtility.Model;
namespace RPGUtility.ViewModel
{
    internal class TestOpposedViewModel:ViewModelBase
    {
        private Campaign _campaign;
        private TestOpossedModel _testOpposedModel;
        private readonly NavigationService _navigationService;
        public RelayCommand NavigateBackCommand { get; }
        private ObservableCollection<Character> _characters;
        private Character _selectedcharacter;
        private bool _isComboBoxVisible;
        private Character _selectedcharacter2;
        private bool _isComboBoxVisible2;
        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged(nameof(Characters));
            }
        }

        public string CharacterName1 { get; set; }
        public string CharacterName2 { get; set; }

        public bool IsComboBoxVisible
        {
            get { return _isComboBoxVisible; }
            set
            {
                _isComboBoxVisible = value;
                OnPropertyChanged(nameof(IsComboBoxVisible));
            }
        }

        public bool IsComboBoxVisible2
        {
            get { return _isComboBoxVisible2; }
            set
            {
                _isComboBoxVisible2 = value;
                OnPropertyChanged(nameof(IsComboBoxVisible2));
            }
        }

        public Character SelectedCharacter
        {
            get { return _selectedcharacter; }
            set
            {
                _selectedcharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
                IsComboBoxVisible = false;
                if (SelectedCharacter is not null) { CharacterName1 = SelectedCharacter.Name; }
                OnPropertyChanged(nameof(CharacterName1));
                
            }
        }
        public Character SelectedCharacter2
        {
            get { return _selectedcharacter; }
            set
            {
                _selectedcharacter2 = value;
                OnPropertyChanged(nameof(SelectedCharacter));
                IsComboBoxVisible2 = false;
                if (SelectedCharacter is not null) { CharacterName2 = SelectedCharacter.Name; }
                OnPropertyChanged(nameof(CharacterName2));

            }
        }
        public RelayCommand ChooseCharacterCommand { get; }
        public RelayCommand ChooseCharacterCommand2 { get; }

        public TestOpposedViewModel(NavigationService navigation, Campaign campaign)
        {
            _navigationService = navigation;
            _campaign = campaign;
            IsComboBoxVisible = false;
            IsComboBoxVisible2 = false;

        }
    }
}
