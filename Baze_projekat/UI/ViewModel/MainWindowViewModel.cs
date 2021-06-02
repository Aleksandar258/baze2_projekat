﻿using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views;

namespace UI.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {

        public MyICommand<string> MenuCommand { get; set; }

        private IndustrijaObuceViewModel industrijaObuceView = new IndustrijaObuceViewModel();
        private RadnikViewModel radnikView = new RadnikViewModel();
        private GradViewModel gradView = new GradViewModel();
        private MaterijalViewModel materijalView = new MaterijalViewModel();
        private TipObuceViewModel tipObuceView = new TipObuceViewModel();
        private ObjekatViewModel objekatView = new ObjekatViewModel();

        public MainWindowViewModel()
        {
            MenuCommand = new MyICommand<string>(OnMenu);
        }

        #region Propertys
        private BindableBase currentView;
        public BindableBase CurrentView
        {
            get { return currentView; }
            set
            {
                SetProperty(ref currentView, value);
            }
        }

        private BindableBase viewView1;
        public BindableBase ViewView1
        {
            get { return viewView1; }
            set
            {
                SetProperty(ref viewView1, value);
            }
        }
        #endregion


        public void OnMenu(string view)
        {
            switch (view)
            {
                case "industrijaObuce":
                    CurrentView = industrijaObuceView;
                    break;
                case "radnik":
                    CurrentView = radnikView;
                    break;
                case "grad":
                    CurrentView = gradView;
                    break;
                case "materijal":
                    CurrentView = materijalView;
                    break;
                case "tipObuce":
                    CurrentView = tipObuceView;
                    break;
                case "objekat":
                    CurrentView = objekatView;
                    break;
            }
        }
    }
}
