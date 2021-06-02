using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Model
{
    public class DTOMaterijal : ValidationBase
    {
        private int idMat;
        public int IdMat
        {
            get { return idMat; }
            set
            {
                if (this.idMat != value)
                {
                    this.idMat = value;
                    OnPropertyChanged("IdMat");
                }
            }
        }

        private string nazMat;
        public string NazMat
        {
            get { return nazMat; }
            set
            {
                if (this.nazMat != value)
                {
                    this.nazMat = value;
                    OnPropertyChanged("NazMat");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.NazMat))
            {
                this.ValidationErrors["Naziv"] = "Name cannot be empty.";
            }
            if (this.IdMat.ToString() == "" || this.IdMat == 0)
            {
                this.ValidationErrors["Id"] = "Id cannot be empty.";
            }

            if (this.IdMat < 0)
            {
                this.ValidationErrors["Id"] = "Id mora biti veci od 0.";
            }

        }
    }
}
