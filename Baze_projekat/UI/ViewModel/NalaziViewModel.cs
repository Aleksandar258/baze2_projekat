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
    public class NalaziViewModel : BindableBase
    {
        public static BindingList<DTONalazi> Nalazis { get; set; }

        public NalaziService nalaziService = new NalaziService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }


        public NalaziViewModel()
        {
            Current = new DTONalazi();
            SelectedIndex = -1;
            Nalazis = new BindingList<DTONalazi>();

            List<DTONalazi> kopija = nalaziService.GetAllNalazi();
            foreach (DTONalazi dto in kopija)
            {
                Nalazis.Add(dto);
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
                int idObj = Current.IdObj;
                int idMat = Current.IdMat;
                int idIO = Current.IdIO;
                DTONalazi r = new DTONalazi()
                {
                    IdObj = idObj,
                    IdMat = idMat,
                    IdIO = idIO,
                };
                /*foreach (DTORadnik io in Radnici)
                {
                    if (io.IdRad == r.IdRad)
                    {

                        return;
                    }
                }*/
                if (nalaziService.AddNalazi(r))
                {
                    Nalazis.Add(r);
                }
            }
        }


        public void onDelete()
        {
            if (SelectedIndex != -1)
            {
                if (nalaziService.DeleteNalazi(Nalazis[SelectedIndex].IdObj, Nalazis[SelectedIndex].IdIO, Nalazis[SelectedIndex].IdMat))
                {
                    Nalazis.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            /*if (SelectedIndex == -1)
            {
                return;
            }

            if (Nalazis[SelectedIndex].IdObj != Current.IdObj)
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
                int idrad = Nalazis[SelectedIndex].IdObj;
                int idMat = Nalazis[SelectedIndex].IdMat;
                int idIO = Nalazis[SelectedIndex].IdIO;
                Current.IdObj = idrad;
                Current.IdMat = idMat;
                Current.IdIO = idIO;
            }
        }


        private DTONalazi current;
        public DTONalazi Current
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
