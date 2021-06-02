using Servis2.Helper;
using Servis2.Model;
using Servis2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class IndustrijaObuceViewModel : BindableBase
    {
        public static BindingList<DTOIndustrijaObuce> IndustrijeObuce { get; set; }

        public IndustrijaObuceService industrijaObuceService = new IndustrijaObuceService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }

        public IndustrijaObuceViewModel()
        {
            CurrentIndustrijaObuce = new DTOIndustrijaObuce();
            SelectedIndex = -1;
            IndustrijeObuce = new BindingList<DTOIndustrijaObuce>();

            List<DTOIndustrijaObuce> kopija = industrijaObuceService.GetAllIndustrijaObuce();
            foreach (DTOIndustrijaObuce dto in kopija)
            {
                IndustrijeObuce.Add(dto);
            }

            AddCommand = new MyICommand(onAdd);
            DeleteCommand = new MyICommand(onDelete);
            EditCommand = new MyICommand(onEdit);
            ShowCommand = new MyICommand(onShow);
        }

        public void onAdd()
        {
            CurrentIndustrijaObuce.Validate();
            if (CurrentIndustrijaObuce.IsValid)
            {
                /*foreach(DTOIndustrijaObuce io in IndustrijeObuce)
                {
                    if(io.IdIO == CurrentIndustrijaObuce.IdIO)
                    {

                        return;
                    }
                }*/
                List<DTOIndustrijaObuce> ii = industrijaObuceService.GetAllIndustrijaObuce();
                int id;
                if (ii.Count == 0)
                {
                    id = 1;
                }
                else
                {
                    id = ii.Max(x => x.IdIO) + 1;
                }
                string name = CurrentIndustrijaObuce.NazIO;
                DTOIndustrijaObuce io2 = new DTOIndustrijaObuce()
                {
                    IdIO = id,
                    NazIO = name,
                };
                if(industrijaObuceService.AddIndustrijaObuce(io2))
                {
                    IndustrijeObuce.Add(io2);
                }
            }
        }

        public void onDelete()
        {
            if(SelectedIndex != -1)
            {
                if(industrijaObuceService.DeleteIndustrijaObuce(IndustrijeObuce[SelectedIndex].IdIO))
                {
                    for(int i = 0; i < RadnikViewModel.Radnici.Count; i++)
                    {
                        if (RadnikViewModel.Radnici[i].IdIO == IndustrijeObuce[SelectedIndex].IdIO)
                        {
                            RadnikViewModel.Radnici.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < ObjekatViewModel.Objekti.Count; i++)
                    {
                        if(ObjekatViewModel.Objekti[i].IdIO == IndustrijeObuce[SelectedIndex].IdIO)
                        {
                            ObjekatViewModel.Objekti.RemoveAt(i);
                        }
                    }
                    IndustrijeObuce.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            if (IndustrijeObuce[SelectedIndex].IdIO != CurrentIndustrijaObuce.IdIO)
            {
                ErrorButton = "Id selektovanog i id text boxa se moraju poklapati.";
                return;
            }
            if (SelectedIndex != -1)
            {
                CurrentIndustrijaObuce.Validate();
                if(CurrentIndustrijaObuce.IsValid)
                {
                    int id = CurrentIndustrijaObuce.IdIO;
                    string name = CurrentIndustrijaObuce.NazIO;
                    DTOIndustrijaObuce io2 = new DTOIndustrijaObuce()
                    {
                        IdIO = id,
                        NazIO = name,
                    };
                    if (industrijaObuceService.UpdateIndustrijaObuce(io2))
                    {
                        IndustrijeObuce[SelectedIndex].IdIO = io2.IdIO;
                        IndustrijeObuce[SelectedIndex].NazIO = io2.NazIO;
                    }
                }
            }
        }

        public void onShow()
        {
            if(SelectedIndex != -1)
            {
                int id = IndustrijeObuce[SelectedIndex].IdIO;
                string name = IndustrijeObuce[SelectedIndex].NazIO;
                CurrentIndustrijaObuce.IdIO = id;
                CurrentIndustrijaObuce.NazIO = name;
            }
        }

        private DTOIndustrijaObuce currentIndustrijaObuce;
        public DTOIndustrijaObuce CurrentIndustrijaObuce
        {
            get
            {
                return currentIndustrijaObuce;
            }
            set
            {
                if (currentIndustrijaObuce != value)
                {
                    currentIndustrijaObuce = value;
                    OnPropertyChanged("CurrentIndustrijaObuce");
                }
            }
        }


        private string errorButton;
        public string ErrorButton
        {
            get
            {
                return errorButton;
            }
            set
            {
                if (errorButton != value)
                {
                    errorButton = value;
                    OnPropertyChanged("ErrorButton");
                }
            }
        }
    }
}
