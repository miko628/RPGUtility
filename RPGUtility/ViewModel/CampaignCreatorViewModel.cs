using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    class CampaignCreatorViewModel: ViewModelBase
    {

        //description moze byc nullem tylko reszta not null ok ok
        private readonly NavigationService _navigationService;
        private CampaignCreatorModel _campaignCreatorModel;
        public RelayCommand CancelCommand { get; }
        public RelayCommand SubmitCommand { get; }

        public string Name
        {
            get
            {
                Trace.WriteLine("Name");
                return _campaignCreatorModel.Name;
            }
            set
            {
                _campaignCreatorModel.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get
            {
                Trace.WriteLine("Description");
                return _campaignCreatorModel.Description;
            }
            set
            {
                _campaignCreatorModel.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string GameMaster
        {
            get
            {
                Trace.WriteLine("GameMaster");
                return _campaignCreatorModel.GameMaster;
            }
            set
            {
                _campaignCreatorModel.GameMaster = value;
                OnPropertyChanged(nameof(GameMaster));
            }
        }

        public string Year
        {
            get
            {
                Trace.WriteLine("Year");
                return _campaignCreatorModel.Year;
            }
            set
            {
                _campaignCreatorModel.Year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public CampaignCreatorViewModel(NavigationService navigation)
        {
            _navigationService = navigation;
            _campaignCreatorModel = new CampaignCreatorModel();
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CampaignViewModel(_navigationService)); }, CanExecuteMyCommand);
            SubmitCommand = new RelayCommand(async (object parameter) => { Campaign pom=await _campaignCreatorModel.Save();  /*_navigationService.Navigate(() => new MenuViewModel(_navigationService));*/ _navigationService.Navigate(() => new StoryViewModel(_navigationService, pom)); }, CanExecuteMyCommand);
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
