using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Model
{
    public class DTORadnik : ValidationBase
    {
        private int idRad;
        public int IdRad
        {
            get { return idRad; }
            set
            {
                if (this.idRad != value)
                {
                    this.idRad = value;
                    OnPropertyChanged("IdRad");
                }
            }
        }

        private string imeRad;
        public string ImeRad
        {
            get { return imeRad; }
            set
            {
                if (this.imeRad != value)
                {
                    this.imeRad = value;
                    OnPropertyChanged("ImeRad");
                }
            }
        }

        private string przRad;
        public string PrzRad
        {
            get { return przRad; }
            set
            {
                if (this.przRad != value)
                {
                    this.przRad = value;
                    OnPropertyChanged("PrzRad");
                }
            }
        }

        private int pltRad;
        public int PltRad
        {
            get { return pltRad; }
            set
            {
                if (this.pltRad != value)
                {
                    this.pltRad = value;
                    OnPropertyChanged("PltRad");
                }
            }
        }

        private string tipRad;
        public string TipRad
        {
            get { return tipRad; }
            set
            {
                if (this.tipRad != value)
                {
                    this.tipRad = value;
                    OnPropertyChanged("TipRad");
                }
            }
        }

        private int idIO;
        public int IdIO
        {
            get { return idIO; }
            set
            {
                if (this.idIO != value)
                {
                    this.idIO = value;
                    OnPropertyChanged("IdIO");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (this.IdRad.ToString() == "" || this.IdRad == 0)
            {
                this.ValidationErrors["Id"] = "Id cannot be empty.";
            }

            if (this.IdRad < 0)
            {
                this.ValidationErrors["Id"] = "Id mora biti veci od 0.";
            }
            if (this.IdIO.ToString() == "" || this.IdIO == 0)
            {
                this.ValidationErrors["IdIO"] = "Id IO cannot be empty.";
            }

            if (this.IdIO < 0)
            {
                this.ValidationErrors["IdIO"] = "Id IO mora biti veci od 0.";
            }
            if (this.PltRad.ToString() == "" || this.PltRad == 0)
            {
                this.ValidationErrors["plt"] = "Plata cannot be empty.";
            }

            if (this.PltRad < 0)
            {
                this.ValidationErrors["Id"] = "Plata mora biti veci od 0.";
            }
            if (string.IsNullOrWhiteSpace(this.imeRad))
            {
                this.ValidationErrors["ime"] = "Name cannot be empty.";
            }
            if (string.IsNullOrWhiteSpace(this.PrzRad))
            {
                this.ValidationErrors["prz"] = "Lastname cannot be empty.";
            }
            if (string.IsNullOrWhiteSpace(this.TipRad))
            {
                this.ValidationErrors["tip"] = "Type cannot be empty.";
            }
        }
    }
}
