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
    public class GradViewModel : BindableBase
    {
        public static BindingList<DTOGrad> Gradovi { get; set; }

        public GradService gradService = new GradService();

        public int SelectedIndex { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand ShowCommand { get; set; }

        public GradViewModel()
        {
            CurrentGrad = new DTOGrad();
            SelectedIndex = -1;
            Gradovi = new BindingList<DTOGrad>();

            List<DTOGrad> kopija = gradService.GetAllGrad();
            foreach (DTOGrad dto in kopija)
            {
                Gradovi.Add(dto);
            }

            AddCommand = new MyICommand(onAdd);
            DeleteCommand = new MyICommand(onDelete);
            EditCommand = new MyICommand(onEdit);
            ShowCommand = new MyICommand(onShow);
        }

        public void onAdd()
        {
            CurrentGrad.Validate();
            if (CurrentGrad.IsValid)
            {
                /*foreach (DTOGrad io in Gradovi)
                {
                    if (io.IdG == CurrentGrad.IdG)
                    {

                        return;
                    }
                }*/
                List<DTOGrad> ii = gradService.GetAllGrad();
                int id;
                if (ii.Count == 0)
                {
                    id = 1;
                }
                else
                {
                    id = ii.Max(x => x.IdG) + 1;
                }
                string name = CurrentGrad.NazG;
                DTOGrad io2 = new DTOGrad()
                {
                    IdG = id,
                    NazG = name,
                };
                if (gradService.AddGrad(io2))
                {
                    Gradovi.Add(io2);
                }
            }
        }


        public void onDelete()
        {
            if (SelectedIndex != -1)
            {
                if (gradService.DeleteGrad(Gradovi[SelectedIndex].IdG))
                {
                    for (int i = 0; i < ObjekatViewModel.Objekti.Count; i++)
                    {
                        if (ObjekatViewModel.Objekti[i].IdG == Gradovi[SelectedIndex].IdG)
                        {
                            ObjekatViewModel.Objekti.RemoveAt(i);
                        }
                    }
                    Gradovi.RemoveAt(SelectedIndex);
                }
            }
        }

        public void onEdit()
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            if (Gradovi[SelectedIndex].IdG != CurrentGrad.IdG)
            {
                ErrorButton = "Id selektovanog i id text boxa se moraju poklapati.";
                return;
            }
            if (SelectedIndex != -1)
            {
                CurrentGrad.Validate();
                if (CurrentGrad.IsValid)
                {
                    int id = CurrentGrad.IdG;
                    string name = CurrentGrad.NazG;
                    DTOGrad io2 = new DTOGrad()
                    {
                        IdG = id,
                        NazG = name,
                    };
                    if (gradService.UpdateGrad(io2))
                    {
                        Gradovi[SelectedIndex].IdG = io2.IdG;
                        Gradovi[SelectedIndex].NazG = io2.NazG;
                    }
                }
            }
        }

        public void onShow()
        {
            if (SelectedIndex != -1)
            {
                int id = Gradovi[SelectedIndex].IdG;
                string name = Gradovi[SelectedIndex].NazG;
                CurrentGrad.IdG = id;
                CurrentGrad.NazG = name;
            }
        }


        private DTOGrad currentGrad;
        public DTOGrad CurrentGrad
        {
            get
            {
                return currentGrad;
            }
            set
            {
                if (currentGrad != value)
                {
                    currentGrad = value;
                    OnPropertyChanged("CurrentGrad");
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
