using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.MVVM;
using Windows.UI.Xaml.Media.Imaging;

namespace CapitalQuizPro.ViewModels.Datas
{
    public class PlayerViewModel : ViewModelBase
    {
        public int PlayerId { get; set; }
        public string UserName { get; set; }
        public BitmapImage ProfileImage { get; set; }
        
        private int _money;
        public int Money
        {
            get { return _money; }
            set { _money = value; RaisePropertyChanged(); }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set { _score = value; RaisePropertyChanged(); }
        }

        private int _breaks;
        public int Breaks
        {
            get { return _breaks; }
            set { _breaks = value; RaisePropertyChanged(); }
        }

        private int _guesses;
        public int Guesses
        {
            get { return _guesses; }
            set { _guesses = value; RaisePropertyChanged(); }
        }

        private int _skips;
        public int Skips
        {
            get { return _skips; }
            set { _skips = value; RaisePropertyChanged(); }
        }



        public PlayerViewModel()
        {
            PlayerId = -1;
            UserName = "";
            Score = 0;
            Money = 0;
            Guesses = 0;
            Breaks = 0;
            Skips = 0;
            ProfileImage = null;
        }

        public PlayerViewModel(int playerId, string name, string profileImageUri, int money, int score, int guesses, int breaks, int skips)
        {
            PlayerId = playerId;
            UserName = name;
            Money = money;
            Score = score;
            Guesses = guesses;
            Breaks = breaks;
            Skips = skips;

            if (!String.IsNullOrEmpty(profileImageUri))
                ProfileImage = new BitmapImage(new Uri(profileImageUri));
            else
                ProfileImage = new BitmapImage();
        }
    }
}
