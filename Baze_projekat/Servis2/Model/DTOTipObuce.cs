using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Model
{
    public class DTOTipObuce : ValidationBase
    {
        private int idTip;
        public int IdTipOb
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

        private string nazTip;
        public string NazTip
        {
            get { return nazTip; }
            set
            {
                if (this.nazTip != value)
                {
                    this.nazTip = value;
                    OnPropertyChanged("NazTip");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.NazTip))
            {
                this.ValidationErrors["Naziv"] = "Name cannot be empty.";
            }
            if (this.IdTipOb.ToString() == "" || this.IdTipOb == 0)
            {
                this.ValidationErrors["Id"] = "Id cannot be empty.";
            }

            if (this.IdTipOb < 0)
            {
                this.ValidationErrors["Id"] = "Id mora biti veci od 0.";
            }

        }
    }
}
