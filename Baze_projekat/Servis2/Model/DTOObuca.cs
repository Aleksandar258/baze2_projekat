using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Model
{
    public class DTOObuca : ValidationBase
    {
        private int idOb;
        public int IdOb
        {
            get { return idOb; }
            set
            {
                if (this.idOb != value)
                {
                    this.idOb = value;
                    OnPropertyChanged("IdOb");
                }
            }
        }

        private string nazOb;
        public string NazOb
        {
            get { return nazOb; }
            set
            {
                if (this.nazOb != value)
                {
                    this.nazOb = value;
                    OnPropertyChanged("NazOb");
                }
            }
        }


        private int brOb;
        public int BrOb
        {
            get { return brOb; }
            set
            {
                if (this.brOb != value)
                {
                    this.brOb = value;
                    OnPropertyChanged("BrOb");
                }
            }
        }

        private int cenaOb;
        public int CenaOb
        {
            get { return cenaOb; }
            set
            {
                if (this.cenaOb != value)
                {
                    this.cenaOb = value;
                    OnPropertyChanged("CenaOb");
                }
            }
        }

        private int idTip;
        public int IdTip
        {
            get { return idTip; }
            set
            {
                if (this.idTip != value)
                {
                    this.idTip = value;
                    OnPropertyChanged("IdTip");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.NazOb))
            {
                this.ValidationErrors["naz"] = "Name cannot be empty.";
            }
            if (this.idOb.ToString() == "" || this.idOb == 0)
            {
                this.ValidationErrors["Id"] = "Id cannot be empty.";
            }

            if (this.idOb < 0)
            {
                this.ValidationErrors["Id"] = "Id mora biti veci od 0.";
            }

            if (this.BrOb.ToString() == "" || this.BrOb == 0)
            {
                this.ValidationErrors["br"] = "Broj cannot be empty.";
            }

            if (this.BrOb < 0)
            {
                this.ValidationErrors["br"] = "Broj mora biti veci od 0.";
            }

            if (this.CenaOb.ToString() == "" || this.CenaOb == 0)
            {
                this.ValidationErrors["cena"] = "Cena cannot be empty.";
            }

            if (this.CenaOb < 0)
            {
                this.ValidationErrors["cena"] = "Cena mora biti veci od 0.";
            }

            if (this.IdTip.ToString() == "" || this.IdTip == 0)
            {
                this.ValidationErrors["IdTip"] = "IdTip cannot be empty.";
            }

            if (this.IdTip < 0)
            {
                this.ValidationErrors["IdTip"] = "IdTip mora biti veci od 0.";
            }

        }
    }
}
