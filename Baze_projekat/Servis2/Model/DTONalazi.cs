using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis2.Model
{
    public class DTONalazi : ValidationBase
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


        protected override void ValidateSelf()
        {
            if (this.IdObj.ToString() == "" || this.IdObj == 0)
            {
                this.ValidationErrors["IdObj"] = "IdObj cannot be empty.";
            }

            if (this.IdObj < 0)
            {
                this.ValidationErrors["IdObj"] = "IdObj mora biti veci od 0.";
            }

            if (this.IdIO.ToString() == "" || this.IdIO == 0)
            {
                this.ValidationErrors["IdIO"] = "IdIO cannot be empty.";
            }

            if (this.IdIO < 0)
            {
                this.ValidationErrors["IdIO"] = "IdIO mora biti veci od 0.";
            }

            if (this.IdMat.ToString() == "" || this.IdMat == 0)
            {
                this.ValidationErrors["IdMat"] = "IdMat cannot be empty.";
            }

            if (this.IdMat < 0)
            {
                this.ValidationErrors["IdMat"] = "IdMat mora biti veci od 0.";
            }

        }

    }
}
