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
    public class SastojiViewModel : BindableBase
    {
        public static BindingList<DTOSastoji> Sastojis { get; set; }

        public SastojiService sastojiService = new SastojiService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }

        public SastojiViewModel()
        {
            Current = new DTOSastoji();
            SelectedIndex = -1;
            Sastojis = new BindingList<DTOSastoji>();

            List<DTOSastoji> kopija = sastojiService.GetAllSastoji();
            foreach (DTOSastoji dto in kopija)
            {
                Sastojis.Add(dto);
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
                int idMat = Current.IdMat;
                int idOb = Current.IdOb;
                int idIO = Current.IdIO;
                DTOSastoji r = new DTOSastoji()
                {
                    IdObj = idrad,
                    IdMat = idMat,
                    IdOb = idOb,
                    IdIO = idIO,
                };
                /*foreach (DTORadnik io in Radnici)
                {
                    if (io.IdRad == r.IdRad)
                    {

                        return;
                    }
                }*/
                if (sastojiService.AddSastoji(r))
                {
                    Sastojis.Add(r);
                }
            }
        }


        public void onDelete()
        {
            if (SelectedIndex != -1)
            {
                if (sastojiService.DeleteSastoji(Sastojis[SelectedIndex].IdObj, Sastojis[SelectedIndex].IdIO, Sastojis[SelectedIndex].IdMat, Sastojis[SelectedIndex].IdOb))
                {
                    Sastojis.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            /*if (SelectedIndex == -1)
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
            }*/
        }

        public void onShow()
        {
            if (SelectedIndex != -1)
            {
                int idObj = Sastojis[SelectedIndex].IdObj;
                int idMat = Sastojis[SelectedIndex].IdMat;
                int idOb = Sastojis[SelectedIndex].IdOb;
                int idIO = Sastojis[SelectedIndex].IdIO;
                Current.IdObj = idObj;
                Current.IdMat = idMat;
                Current.IdOb = idOb;
                Current.IdIO = idIO;
            }
        }


        private DTOSastoji current;
        public DTOSastoji Current
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
