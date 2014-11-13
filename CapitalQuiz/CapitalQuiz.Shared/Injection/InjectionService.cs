using CapitalQuiz.Implementations;
using CapitalQuizPro.Models.Implementations;
using CapitalQuizPro.Models.Interfaces;
using CapitalQuizPro.ViewModels.Pages;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using UniversalExtensions.Navigation;

namespace CapitalQuiz.Injection
{
    public class InjectionService
    {
        public InjectionService()
        {
            SimpleIoc.Default.Register<IGameService, SampleGameService>();
            SimpleIoc.Default.Register<ITypeService, TypeService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<ITopListService, SampleTopListService>();
            SimpleIoc.Default.Register<IPlayerService, SamplePlayerService>();

            SimpleIoc.Default.Register<GameViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<TopListViewModel>();
        }


        public MenuViewModel Menu
        {
            get { return SimpleIoc.Default.GetInstance<MenuViewModel>(); }
        }

        public GameViewModel Game
        {
            get { return SimpleIoc.Default.GetInstance<GameViewModel>(); }
        }

        public TopListViewModel TopList
        {
            get { return SimpleIoc.Default.GetInstance<TopListViewModel>(); }
        }
    }
}
