using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Model
{
    public class DTOObjekat : ValidationBase
    {
        private int idObj;
        public int IdObj
        {
            get { return idObj; }
            set
            {
                if (this.idObj != value)
                {
                    this.idObj = value;
                    OnPropertyChanged("IdObj");
                }
            }
        }

        private string nazObj;
        public string NazObj
        {
            get { return nazObj; }
            set
            {
                if (this.nazObj != value)
                {
                    this.nazObj = value;
                    OnPropertyChanged("NazObj");
                }
            }
        }

        private string adrObj;
        public string AdrObj
        {
            get { return adrObj; }
            set
            {
                if (this.adrObj != value)
                {
                    this.adrObj = value;
                    OnPropertyChanged("AdrObj");
                }
            }
        }

        private string tipObj;
        public string TipObj
        {
            get { return tipObj; }
            set
            {
                if (this.tipObj != value)
                {
                    this.tipObj = value;
                    OnPropertyChanged("TipObj");
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

        private int idG;
        public int IdG
        {
            get { return idG; }
            set
            {
                if (this.idG != value)
                {
                    this.idG = value;
                    OnPropertyChanged("IdG");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.NazObj))
            {
                this.ValidationErrors["naz"] = "Name cannot be empty.";
            }
            if (string.IsNullOrWhiteSpace(this.AdrObj))
            {
                this.ValidationErrors["adr"] = "Address cannot be empty.";
            }
            if (string.IsNullOrWhiteSpace(this.TipObj))
            {
                this.ValidationErrors["tip"] = "Type cannot be empty.";
            }
            if (this.IdObj.ToString() == "" || this.IdObj == 0)
            {
                this.ValidationErrors["Id"] = "Id cannot be empty.";
            }
            if (this.IdObj < 0)
            {
                this.ValidationErrors["Id"] = "Id mora biti veci od 0.";
            }
            if (this.IdIO.ToString() == "" || this.IdIO == 0)
            {
                this.ValidationErrors["IdIO"] = "IdIO cannot be empty.";
            }
            if (this.IdIO < 0)
            {
                this.ValidationErrors["IdIO"] = "IdIO mora biti veci od 0.";
            }
            if (this.IdG.ToString() == "" || this.IdG == 0)
            {
                this.ValidationErrors["IdG"] = "IdG cannot be empty.";
            }
            if (this.IdG < 0)
            {
                this.ValidationErrors["IdG"] = "IdG mora biti veci od 0.";
            }

        }
    }
}
