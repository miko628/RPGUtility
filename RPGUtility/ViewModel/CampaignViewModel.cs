using RPGUtility.Model;
using RPGUtility.Models;
using RPGUtility.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace RPGUtility.ViewModel
{
    class CampaignViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private CampaignModel _campaignModel;
        private Campaign _selectedItem;
        public Campaign SelectedCampaign
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedCampaign));
            }
        }
         public RelayCommand CancelCommand { get; }

        public RelayCommand SubmitCommand { get; }
        public RelayCommand NewCampaignCommand { get; }
        public ObservableCollection<Campaign> Campaigns
        {
            get { return _campaignModel.Campaigns; }
            set { _campaignModel.Campaigns = value;
                OnPropertyChanged(nameof(Campaigns));
            }
        }

        /* private async Task Load()
         {
             List<Campaign> pom= await _campaignModel.GetAll();

             foreach (var item in pom)
             {
                 Campaigns.Add(item);
             }
         }*/
        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            int intIndex = Convert.ToInt32(radioButton.Content.ToString());
            MessageBox.Show(intIndex.ToString(CultureInfo.InvariantCulture));
        }
        public CampaignViewModel(NavigationService navigation)
        {
            _navigationService = navigation;
            _campaignModel=new CampaignModel();
           // Campaigns.Add(new Campaign("ok","ok","ok","ok");
            _=_campaignModel.GetAll();
           // Load();
            CancelCommand = new RelayCommand((object parameter) => {  _navigationService.Navigate(() => new MenuViewModel(_navigationService)); }, CanExecuteMyCommand);
            SubmitCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new StoryViewModel(_navigationService, _selectedItem)); }, CanExecuteMyCommand);//tutaj przejscie do campaignView
            NewCampaignCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CampaignCreatorViewModel(_navigationService)); }, CanExecuteMyCommand);
            //przycisk do dodawania nowego scenariusza ok ok

        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
