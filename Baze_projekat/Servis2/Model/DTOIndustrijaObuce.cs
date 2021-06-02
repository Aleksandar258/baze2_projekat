using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Model
{
    public class DTOIndustrijaObuce : ValidationBase
    {

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

        private string nazIO;
        public string NazIO
        {
            get { return nazIO; }
            set
            {
                if (this.nazIO != value)
                {
                    this.nazIO = value;
                    OnPropertyChanged("NazIO");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.NazIO))
            {
                this.ValidationErrors["Naziv"] = "Name cannot be empty.";
            }
            if (this.IdIO.ToString() == "" || this.IdIO == 0)
            {
                this.ValidationErrors["Id"] = "Id cannot be empty.";
            }

            if (this.IdIO < 0)
            {
                this.ValidationErrors["Id"] = "Id mora biti veci od 0.";
            }

        }
    }

}
