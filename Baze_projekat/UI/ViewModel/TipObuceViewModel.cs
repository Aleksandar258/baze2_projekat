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
    public class TipObuceViewModel : BindableBase
    {
        public static BindingList<DTOTipObuce> TipoviObuce { get; set; }

        public TipObuceService tipObuceService = new TipObuceService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }

        public TipObuceViewModel()
        {
            CurrentTipObuce = new DTOTipObuce();
            SelectedIndex = -1;
            TipoviObuce = new BindingList<DTOTipObuce>();

            List<DTOTipObuce> kopija = tipObuceService.GetAllTipObuce();
            foreach (DTOTipObuce dto in kopija)
            {
                TipoviObuce.Add(dto);
            }

            AddCommand = new MyICommand(onAdd);
            DeleteCommand = new MyICommand(onDelete);
            EditCommand = new MyICommand(onEdit);
            ShowCommand = new MyICommand(onShow);
        }

        public void onAdd()
        {
            CurrentTipObuce.Validate();
            if (CurrentTipObuce.IsValid)
            {
                /*foreach (DTOGrad io in Gradovi)
                {
                    if (io.IdG == CurrentGrad.IdG)
                    {

                        return;
                    }
                }*/
                List<DTOTipObuce> ii = tipObuceService.GetAllTipObuce();
                int id;
                if (ii.Count == 0)
                {
                    id = 1;
                }
                else
                {
                    id = ii.Max(x => x.IdTipOb) + 1;
                }
                string name = CurrentTipObuce.NazTip;
                DTOTipObuce io2 = new DTOTipObuce()
                {
                    IdTipOb = id,
                    NazTip = name,
                };
                if (tipObuceService.AddTipObuce(io2))
                {
                    TipoviObuce.Add(io2);
                }
            }
        }


        public void onDelete()
        {
            if (SelectedIndex != -1)
            {
                if (tipObuceService.DeleteTipObuce(TipoviObuce[SelectedIndex].IdTipOb))
                {
                    TipoviObuce.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            if (TipoviObuce[SelectedIndex].IdTipOb != CurrentTipObuce.IdTipOb)
            {
                ErrorButton = "Id selektovanog i id text boxa se moraju poklapati.";
                return;
            }
            if (SelectedIndex != -1)
            {
                CurrentTipObuce.Validate();
                if (CurrentTipObuce.IsValid)
                {
                    int id = CurrentTipObuce.IdTipOb;
                    string name = CurrentTipObuce.NazTip;
                    DTOTipObuce io2 = new DTOTipObuce()
                    {
                        IdTipOb = id,
                        NazTip = name,
                    };
                    if (tipObuceService.UpdateTipObuce(io2))
                    {
                        TipoviObuce[SelectedIndex].IdTipOb = io2.IdTipOb;
                        TipoviObuce[SelectedIndex].NazTip = io2.NazTip;
                    }
                }
            }
        }

        public void onShow()
        {
            if (SelectedIndex != -1)
            {
                int id = TipoviObuce[SelectedIndex].IdTipOb;
                string name = TipoviObuce[SelectedIndex].NazTip;
                CurrentTipObuce.IdTipOb = id;
                CurrentTipObuce.NazTip = name;
            }
        }

        private DTOTipObuce currentTipObuce;
        public DTOTipObuce CurrentTipObuce
        {
            get
            {
                return currentTipObuce;
            }
            set
            {
                if (currentTipObuce != value)
                {
                    currentTipObuce = value;
                    OnPropertyChanged("CurrentTipObuce");
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
