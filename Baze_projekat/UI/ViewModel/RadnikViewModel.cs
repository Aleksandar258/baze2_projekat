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
    public class RadnikViewModel : BindableBase
    {
        public static BindingList<DTORadnik> Radnici { get; set; }

        public RadnikService radnikService = new RadnikService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }


        public RadnikViewModel()
        {
            CurrentRadnik = new DTORadnik();
            SelectedIndex = -1;
            Radnici = new BindingList<DTORadnik>();

            List<DTORadnik> kopija = radnikService.GetAllRadnik();
            foreach (DTORadnik dto in kopija)
            {
                Radnici.Add(dto);
            }

            AddCommand = new MyICommand(onAdd);
            DeleteCommand = new MyICommand(onDelete);
            EditCommand = new MyICommand(onEdit);
            ShowCommand = new MyICommand(onShow);
        }


        public void onAdd()
        {
            CurrentRadnik.Validate();
            if (CurrentRadnik.IsValid)
            {
                int idrad = CurrentRadnik.IdRad;
                string ime = CurrentRadnik.ImeRad;
                string prz = CurrentRadnik.PrzRad;
                int plt = CurrentRadnik.PltRad;
                string tip = CurrentRadnik.TipRad;
                int idIO = CurrentRadnik.IdIO;
                DTORadnik r = new DTORadnik()
                {
                    IdRad = idrad,
                    ImeRad = ime,
                    PrzRad = prz,
                    PltRad = plt,
                    TipRad = tip,
                    IdIO = idIO,
                };
                /*foreach (DTORadnik io in Radnici)
                {
                    if (io.IdRad == r.IdRad)
                    {

                        return;
                    }
                }*/
                if (radnikService.AddRadnik(r))
                {
                    Radnici.Add(r);
                }
            }
        }


        public void onDelete()
        {
            if (SelectedIndex != -1)
            {
                if (radnikService.DeleteRadnik(Radnici[SelectedIndex].IdRad, Radnici[SelectedIndex].TipRad))
                {
                    Radnici.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            if (Radnici[SelectedIndex].IdRad != CurrentRadnik.IdRad)
            {
                ErrorButton = "Id selektovanog i id text boxa se moraju poklapati.";
                return;
            }
            if (SelectedIndex != -1)
            {
                CurrentRadnik.Validate();
                if (CurrentRadnik.IsValid)
                {
                    int idrad = CurrentRadnik.IdRad;
                    string ime = CurrentRadnik.ImeRad;
                    string prz = CurrentRadnik.PrzRad;
                    int plt = CurrentRadnik.PltRad;
                    string tip = CurrentRadnik.TipRad;
                    int idIO = CurrentRadnik.IdIO;
                    DTORadnik r = new DTORadnik()
                    {
                        IdRad = idrad,
                        ImeRad = ime,
                        PrzRad = prz,
                        PltRad = plt,
                        TipRad = tip,
                        IdIO = idIO,
                    };
                    if (radnikService.UpdateRadnik(r))
                    {
                        Radnici[SelectedIndex].IdRad = r.IdRad;
                        Radnici[SelectedIndex].ImeRad = r.ImeRad;
                        Radnici[SelectedIndex].PrzRad = r.PrzRad;
                        Radnici[SelectedIndex].PltRad = r.PltRad;
                        Radnici[SelectedIndex].TipRad = r.TipRad;
                        Radnici[SelectedIndex].IdIO = r.IdIO;
                    }
                }
            }
        }

        public void onShow()
        {
            if (SelectedIndex != -1)
            {
                int idrad = Radnici[SelectedIndex].IdRad;
                string ime = Radnici[SelectedIndex].ImeRad;
                string prz = Radnici[SelectedIndex].PrzRad;
                int plt = Radnici[SelectedIndex].PltRad;
                string tip = Radnici[SelectedIndex].TipRad;
                int idIO = Radnici[SelectedIndex].IdIO;
                CurrentRadnik.IdRad = idrad;
                CurrentRadnik.ImeRad = ime;
                CurrentRadnik.PrzRad = prz;
                CurrentRadnik.PltRad = plt;
                CurrentRadnik.TipRad = tip;
                CurrentRadnik.IdIO = idIO;
            }
        }


        private DTORadnik currentRadnik;
        public DTORadnik CurrentRadnik
        {
            get
            {
                return currentRadnik;
            }
            set
            {
                if (currentRadnik != value)
                {
                    currentRadnik = value;
                    OnPropertyChanged("CurrentRadnik");
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
