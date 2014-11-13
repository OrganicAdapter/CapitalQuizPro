using CapitalQuizPro.Models.Datas;
using CapitalQuizPro.Models.Interfaces;
using CapitalQuizPro.ViewModels.Connections;
using CapitalQuizPro.ViewModels.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions;
using UniversalExtensions.MVVM;
using UniversalExtensions.Navigation;
using Windows.UI.Xaml;

namespace CapitalQuizPro.ViewModels.Pages
{
    public class GameViewModel : ViewModelBase
    {
        #region Fields

        private readonly IGameService _gameService;
        private readonly INavigationService _navigationService;
        private readonly IPlayerService _playerService;

        public const int MAXIMUM_TIME = 30;

        #endregion //Fields

        #region Properties

        private QuestionViewModel _question;
        public QuestionViewModel Question
        {
            get { return _question; }
            set { _question = value; RaisePropertyChanged(); }
        }

        private int _time;
        public int Time
        {
            get { return _time; }
            set { _time = value; RaisePropertyChanged(); }
        }

        private bool _isCountbackVisible;
        public bool IsCountbackVisible
        {
            get { return _isCountbackVisible; }
            set { _isCountbackVisible = value; RaisePropertyChanged(); }
        }

        private bool _isAlive;
        public bool IsAlive
        {
            get { return _isAlive; }
            set 
            { 
                _isAlive = value;
                RaisePropertyChanged(); 
            }
        }

        private PlayerViewModel _player;
        public PlayerViewModel Player
        {
            get { return _player; }
            set { _player = value; RaisePropertyChanged(); }
        }


        private DispatcherTimer Timer { get; set; }
        public int QuestionNumber { get; set; }


        public RelayCommand Init { get; set; }
        public RelayCommand<string> SetAnswer { get; set; }
        public RelayCommand SetFinished { get; set; }

        #endregion //Properties

        #region Constructor

        public GameViewModel(IGameService gameService, INavigationService navigationService, IPlayerService playerService)
        {
            _gameService = gameService;
            _navigationService = navigationService;
            _playerService = playerService;

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += TimerTick;

            Init = new RelayCommand(ExecuteInit);
            SetAnswer = new RelayCommand<string>(ExecuteSetAnswer);
            SetFinished = new RelayCommand(ExecuteSetFinished);
        }

        #endregion //Constructor

        #region Methods

        private async void ExecuteInit()
        {
            //Init player values
            IsAlive = true;
            Player = PlayerConnector.ConvertToViewModel(await _playerService.GetPlayer(), await _playerService.GetPlayerValues());

            //Init game values
            Question = null;
            QuestionNumber = 1;

            //Init and start the timer
            Time = 3;
            IsCountbackVisible = true;
            Timer.Start();
        }

        private void TimerTick(object sender, object e)
        {
            if (Time > 0)
                Time--;
            else
            {
                if (IsCountbackVisible)
                {
                    //Start the game
                    IsCountbackVisible = false;
                    Time = MAXIMUM_TIME;
                    GetQuestion();
                }
                else
                {
                    //Fail the game
                    IsAlive = false;
                    _gameService.SetFailed(Player.PlayerId, Player.Score);
                }
            }
        }

        private async void GetQuestion()
        {
            //Get a new question
            var question = await _gameService.GetQuestion();

            //Stop if no new question is available, or continue
            if (question == null)
            {
                ExecuteSetFinished();
                MessageService.ShowMessage("All completed!");
            }
            else
            {
                Time = 30;
                Question = QuestionConnector.ConvertToViewModel(question);
            }
        }

        private async void ExecuteSetAnswer(string answer)
        {
            //Set answer and get a new question, or finish game
            if (await _gameService.SetAnswer(Player.PlayerId, QuestionConnector.ConvertToModel(Question), answer, MAXIMUM_TIME - Time))
            {
                var selected = Question.AllAnswers.Where((x) => x.Text.Equals(answer)).FirstOrDefault();
                selected.IsGoodAnswer = true;

                Player.Score += (Time * QuestionNumber) / 10;
                QuestionNumber++;

                GetQuestion();
            }
            else
            {
                Timer.Stop();
                IsAlive = false;
            }
        }

        private void ExecuteSetFinished()
        {
            //Finish the game
            Timer.Stop();
            _gameService.SetFinished(Player.PlayerId, Player.Score);
            _navigationService.Navigate("CapitalQuiz.Pages", "TopListPage", true);
        }

        #endregion //Methods
                
    }
}
