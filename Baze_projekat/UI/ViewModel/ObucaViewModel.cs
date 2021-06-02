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
    public class ObucaViewModel : BindableBase
    {
        public static BindingList<DTOObuca> Obucas { get; set; }

        public ObucaService obucaService = new ObucaService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }

        public ObucaViewModel()
        {
            Current = new DTOObuca();
            SelectedIndex = -1;
            Obucas = new BindingList<DTOObuca>();

            List<DTOObuca> kopija = obucaService.GetAllObuca();
            foreach (DTOObuca dto in kopija)
            {
                Obucas.Add(dto);
            }

            AddCommand = new MyICommand(onAdd);
            DeleteCommand = new MyICommand(onDelete);
            EditCommand = new MyICommand(onEdit);
            ShowCommand = new MyICommand(onShow);
        }

        public void onAdd()
        {
            Current.Validate();
            if (Current.IsValid)
            {
                int idrad = Current.IdOb;
                string naz = Current.NazOb;
                int broj = Current.BrOb;
                int cena = Current.CenaOb;
                int idTip = Current.IdTip;
                DTOObuca r = new DTOObuca()
                {
                    IdOb = idrad,
                    NazOb = naz,
                    BrOb = broj,
                    CenaOb = cena,
                    IdTip = idTip,
                };
                /*foreach (DTORadnik io in Radnici)
                {
                    if (io.IdRad == r.IdRad)
                    {

                        return;
                    }
                }*/
                if (obucaService.AddObuca(r))
                {
                    Obucas.Add(r);
                }
            }
        }


        public void onDelete()
        {
            if (SelectedIndex != -1)
            {
                if (obucaService.DeleteObuca(Obucas[SelectedIndex].IdOb))
                {
                    Obucas.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            if (Obucas[SelectedIndex].IdOb != Current.IdOb)
            {
                ErrorButton = "Id selektovanog i id text boxa se moraju poklapati.";
                return;
            }
            if (SelectedIndex != -1)
            {
                Current.Validate();
                if (Current.IsValid)
                {
                    int idrad = Current.IdOb;
                    string naz = Current.NazOb;
                    int broj = Current.BrOb;
                    int cena = Current.CenaOb;
                    int idTip = Current.IdTip;
                    DTOObuca r = new DTOObuca()
                    {
                        IdOb = idrad,
                        NazOb = naz,
                        BrOb = broj,
                        CenaOb = cena,
                        IdTip = idTip,
                    };
                    if (obucaService.UpdateObuca(r))
                    {
                        Obucas[SelectedIndex].IdOb = r.IdOb;
                        Obucas[SelectedIndex].NazOb = r.NazOb;
                        Obucas[SelectedIndex].BrOb = r.BrOb;
                        Obucas[SelectedIndex].CenaOb = r.CenaOb;
                        Obucas[SelectedIndex].IdTip = r.IdTip;
                    }
                }
            }
        }

        public void onShow()
        {
            if (SelectedIndex != -1)
            {
                int idrad = Obucas[SelectedIndex].IdOb;
                string naz = Obucas[SelectedIndex].NazOb;
                int br = Obucas[SelectedIndex].BrOb;
                int cena = Obucas[SelectedIndex].CenaOb;
                int idtip = Obucas[SelectedIndex].IdTip;
                Current.IdOb = idrad;
                Current.NazOb = naz;
                Current.BrOb = br;
                Current.CenaOb = cena;
                Current.IdTip = idtip;
            }
        }

        private DTOObuca current;
        public DTOObuca Current
        {
            get
            {
                return current;
            }
            set
            {
                if (current != value)
                {
                    current = value;
                    OnPropertyChanged("Current");
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
