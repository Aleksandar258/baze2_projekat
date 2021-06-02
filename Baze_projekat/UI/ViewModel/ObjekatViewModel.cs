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
    public class ObjekatViewModel : BindableBase
    {
        public static BindingList<DTOObjekat> Objekti { get; set; }

        public ObjekatService objekatService = new ObjekatService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }

        public ObjekatViewModel()
        {
            Current = new DTOObjekat();
            SelectedIndex = -1;
            Objekti = new BindingList<DTOObjekat>();

            List<DTOObjekat> kopija = objekatService.GetAllObjekat();
            foreach (DTOObjekat dto in kopija)
            {
                Objekti.Add(dto);
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
                int idrad = Current.IdObj;
                string naz = Current.NazObj;
                string adr = Current.AdrObj;
                string tip = Current.TipObj;
                int idG = Current.IdG;
                int idIO = Current.IdIO;
                DTOObjekat r = new DTOObjekat()
                {
                    IdObj = idrad,
                    NazObj = naz,
                    AdrObj = adr,
                    TipObj = tip,
                    IdG = idG,
                    IdIO = idIO,
                };
                /*foreach (DTORadnik io in Radnici)
                {
                    if (io.IdRad == r.IdRad)
                    {

                        return;
                    }
                }*/
                if (objekatService.AddObjekat(r))
                {
                    Objekti.Add(r);
                }
            }
        }


        public void onDelete()
        {
            if (SelectedIndex != -1)
            {
                if (objekatService.DeleteObjekat(Objekti[SelectedIndex].IdObj, Objekti[SelectedIndex].IdIO, Objekti[SelectedIndex].TipObj))
                {
                    Objekti.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            if (Objekti[SelectedIndex].IdObj != Current.IdObj)
            {
                ErrorButton = "Id selektovanog i id text boxa se moraju poklapati.";
                return;
            }
            if (SelectedIndex != -1)
            {
                Current.Validate();
                if (Current.IsValid)
                {
                    int idrad = Current.IdObj;
                    string naz = Current.NazObj;
                    string adr = Current.AdrObj;
                    string tip = Current.TipObj;
                    int idG = Current.IdG;
                    int idIO = Current.IdIO;
                    DTOObjekat r = new DTOObjekat()
                    {
                        IdObj = idrad,
                        NazObj = naz,
                        AdrObj = adr,
                        TipObj = tip,
                        IdG = idG,
                        IdIO = idIO,
                    };
                    if (objekatService.UpdateObjekat(r))
                    {
                        Objekti[SelectedIndex].IdObj = r.IdObj;
                        Objekti[SelectedIndex].NazObj = r.NazObj;
                        Objekti[SelectedIndex].AdrObj = r.AdrObj;
                        Objekti[SelectedIndex].TipObj = r.TipObj;
                        Objekti[SelectedIndex].IdG = r.IdG;
                        Objekti[SelectedIndex].IdIO = r.IdIO;
                    }
                }
            }
        }

        public void onShow()
        {
            if (SelectedIndex != -1)
            {
                int idrad = Objekti[SelectedIndex].IdObj;
                string naz = Objekti[SelectedIndex].NazObj;
                string adr = Objekti[SelectedIndex].AdrObj;
                string tip = Objekti[SelectedIndex].TipObj;
                int idG = Objekti[SelectedIndex].IdG;
                int idIO = Objekti[SelectedIndex].IdIO;
                Current.IdObj = idrad;
                Current.NazObj = naz;
                Current.AdrObj = adr;
                Current.TipObj = tip;
                Current.IdG = idG;
                Current.IdIO = idIO;
            }
        }


        private DTOObjekat current;
        public DTOObjekat Current
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
