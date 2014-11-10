using CapitalQuizPro.Models.Datas;
using CapitalQuizPro.Models.Interfaces;
using CapitalQuizPro.ViewModels.Connections;
using CapitalQuizPro.ViewModels.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.MVVM;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CapitalQuizPro.ViewModels.Pages
{
    public class TopListViewModel : ViewModelBase
    {
        #region Fields

        private readonly ITopListService _topListService;

        #endregion //Fields

        #region Properties

        private List<TopListItemViewModel> _topList;
        public List<TopListItemViewModel> TopList
        {
            get { return _topList; }
            set { _topList = value; RaisePropertyChanged(); }
        }


        private bool IsUserAttached { get; set; }


        public RelayCommand Init { get; set; }
        public RelayCommand Add { get; set; }

        #endregion //Properties

        #region Constructor

        public TopListViewModel(ITopListService topListService)
        {
            _topListService = topListService;

            Init = new RelayCommand(ExecuteInit);
            Add = new RelayCommand(ExecuteAdd);

            (Window.Current.Content as Frame).Navigated += Navigated;
        }

        #endregion //Constructor

        #region Methods

        private async void ExecuteInit()
        {
            if (!IsUserAttached)
            {
                var list = await _topListService.GetTopList();
                var items = new List<TopListItemViewModel>();

                foreach (var item in list)
                    items.Add(TopListConnector.ConvertToViewModel(item));

                TopList = items;
            }
            else
            { 
                var list = await _topListService.Add("Geri", 0);
                var items = new List<TopListItemViewModel>();

                foreach (var item in list)
                    items.Add(TopListConnector.ConvertToViewModel(item));

                TopList = items;
            }
        }

        private async void ExecuteAdd()
        { 
            var list = await _topListService.Add("Geri", 0);

            var items = new List<TopListItemViewModel>();

            foreach (var item in list)
                items.Add(TopListConnector.ConvertToViewModel(item));

            TopList = items;
        }

        private void Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if (e.Parameter != null)
                IsUserAttached = true;
            else
                IsUserAttached = false;
        }

        #endregion //Methods
    }
}
