using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Model
{
    public class DTOGrad : ValidationBase
    {
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

        private string nazG;
        public string NazG
        {
            get { return nazG; }
            set
            {
                if (this.nazG != value)
                {
                    this.nazG = value;
                    OnPropertyChanged("NazG");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.NazG))
            {
                this.ValidationErrors["Naziv"] = "Name cannot be empty.";
            }
            if (this.IdG.ToString() == "" || this.IdG == 0)
            {
                this.ValidationErrors["Id"] = "Id cannot be empty.";
            }

            if (this.IdG < 0)
            {
                this.ValidationErrors["Id"] = "Id mora biti veci od 0.";
            }

        }
    }
}
