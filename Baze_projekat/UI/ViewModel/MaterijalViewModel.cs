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
    public class MaterijalViewModel : BindableBase
    {
        public static BindingList<DTOMaterijal> Materijali { get; set; }

        public MaterijalService materijalService = new MaterijalService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }


        public MaterijalViewModel()
        {
            CurrentMaterijal = new DTOMaterijal();
            SelectedIndex = -1;
            Materijali = new BindingList<DTOMaterijal>();

            List<DTOMaterijal> kopija = materijalService.GetAllMaterijal();
            foreach (DTOMaterijal dto in kopija)
            {
                Materijali.Add(dto);
            }

            AddCommand = new MyICommand(onAdd);
            DeleteCommand = new MyICommand(onDelete);
            EditCommand = new MyICommand(onEdit);
            ShowCommand = new MyICommand(onShow);
        }

        public void onAdd()
        {
            CurrentMaterijal.Validate();
            if (CurrentMaterijal.IsValid)
            {
                /*foreach (DTOGrad io in Gradovi)
                {
                    if (io.IdG == CurrentGrad.IdG)
                    {

                        return;
                    }
                }*/
                List<DTOMaterijal> ii = materijalService.GetAllMaterijal();
                int id;
                if (ii.Count == 0)
                {
                    id = 1;
                }
                else
                {
                    id = ii.Max(x => x.IdMat) + 1;
                }
                
                string name = CurrentMaterijal.NazMat;
                DTOMaterijal io2 = new DTOMaterijal()
                {
                    IdMat = id,
                    NazMat = name,
                };
                if (materijalService.AddMaterijal(io2))
                {
                    Materijali.Add(io2);
                }
            }
        }


        public void onDelete()
        {
            if (SelectedIndex != -1)
            {
                if (materijalService.DeleteMaterijal(Materijali[SelectedIndex].IdMat))
                {
                    Materijali.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            if (Materijali[SelectedIndex].IdMat != CurrentMaterijal.IdMat)
            {
                ErrorButton = "Id selektovanog i id text boxa se moraju poklapati.";
                return;
            }
            if (SelectedIndex != -1)
            {
                CurrentMaterijal.Validate();
                if (CurrentMaterijal.IsValid)
                {
                    int id = CurrentMaterijal.IdMat;
                    string name = CurrentMaterijal.NazMat;
                    DTOMaterijal io2 = new DTOMaterijal()
                    {
                        IdMat = id,
                        NazMat = name,
                    };
                    if (materijalService.UpdateMaterijal(io2))
                    {
                        Materijali[SelectedIndex].IdMat = io2.IdMat;
                        Materijali[SelectedIndex].NazMat = io2.NazMat;
                    }
                }
            }
        }

        public void onShow()
        {
            if (SelectedIndex != -1)
            {
                int id = Materijali[SelectedIndex].IdMat;
                string name = Materijali[SelectedIndex].NazMat;
                CurrentMaterijal.IdMat = id;
                CurrentMaterijal.NazMat = name;
            }
        }


        private DTOMaterijal currentMaterijal;
        public DTOMaterijal CurrentMaterijal
        {
            get
            {
                return currentMaterijal;
            }
            set
            {
                if (currentMaterijal != value)
                {
                    currentMaterijal = value;
                    OnPropertyChanged("CurrentMaterijal");
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
