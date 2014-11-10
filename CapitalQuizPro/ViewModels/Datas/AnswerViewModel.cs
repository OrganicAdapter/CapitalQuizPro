using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.MVVM;

namespace CapitalQuizPro.ViewModels.Datas
{
    public class AnswerViewModel : ViewModelBase
    {
        public string Text { get; set; }
        
        
        private bool _isGoodAnswer;
        public bool IsGoodAnswer
        {
            get { return _isGoodAnswer; }
            set { _isGoodAnswer = value; RaisePropertyChanged(); }
        }

        private bool _isBadAnswer;
        public bool IsBadAnswer
        {
            get { return _isBadAnswer; }
            set { _isBadAnswer = value; RaisePropertyChanged(); }
        }



        public AnswerViewModel()
        {
            Text = "";
            IsGoodAnswer = false;
            IsBadAnswer = false;
        }

        public AnswerViewModel(string text)
        {
            Text = text;
            IsGoodAnswer = false;
            IsBadAnswer = false;
        }
    }
}
