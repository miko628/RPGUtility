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
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.ComponentModel;

namespace RPGUtility.ViewModel
{
    class CampaignViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private CampaignModel _campaignModel;
        private Campaign _selectedItem;
        private ObservableCollection<Campaign> _campaigns;
       
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

        public RelayCommand DeleteCampaignCommand { get; }
        public RelayCommand SubmitCommand { get; }
        public RelayCommand NewCampaignCommand { get; }
        public ObservableCollection<Campaign> Campaigns
        {
            get {
               // Trace.WriteLine("222");
               // _campaigns = _campaignModel.Campaigns;

                return _campaigns; }
            set {
                _campaigns = value;
                OnPropertyChanged(nameof(Campaigns));
            }
        }

        private async Task Load()
        {

            List<Campaign> camp = await _campaignModel.GetAll();
            await App.Current.Dispatcher.BeginInvoke((Action)delegate ()
           {
               Campaigns.Clear();
               foreach (var item in camp)
               {
                   Campaigns.Add(item);
               }
           });



        }

        public CampaignViewModel(NavigationService navigation)
        {
            _navigationService = navigation;
            _campaignModel=new CampaignModel();
            _campaigns=new ObservableCollection<Campaign>();
            // Campaigns.Add(new Campaign("ok","ok","ok","ok");
            // _=_campaignModel.GetAll();
            //Task < List < Campaign >> task1;
            Task.Run(Load);
            CancelCommand = new RelayCommand((object parameter) => {  _navigationService.Navigate(() => new HomeViewModel(_navigationService)); }, CanExecuteMyCommand);
            SubmitCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new StoryViewModel(_navigationService, _selectedItem)); }, CanExecuteMyCommand);//tutaj przejscie do campaignView
            NewCampaignCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CampaignCreatorViewModel(_navigationService)); }, CanExecuteMyCommand);
            DeleteCampaignCommand = new RelayCommand(async(object parameter) => { await _campaignModel.Delete(_selectedItem); await Load(); }, CanExecuteMyCommand);

            //przycisk do dodawania nowego scenariusza ok ok

        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
