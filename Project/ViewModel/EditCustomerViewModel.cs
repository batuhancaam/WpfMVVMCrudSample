using System;
using Project.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project.Helper;
using Project.View;
namespace Project.ViewModel
{
    public class EditCustomerViewModel
    {

        MusteriProvider musteriProvider = new MusteriProvider();


        private MusteriModel musteri;

        public MusteriModel Musteri
        {
            get { return musteri; }
            set { musteri = value; }
        }

     

        private string selectPozisyon;

        public string SelectPozisyon
        {
            get { return selectPozisyon; }
            set { selectPozisyon = value; }
        }

        private ICommand editSave;

        public EditCustomerViewModel(MusteriModel selecItem)
        {
            Musteri = selecItem;

        }

        public ICommand EditSaveCommand
        {
            get
            {

                if (editSave == null)
                    editSave = new RelayCommand(Save);
                return editSave;
            }

        }

        public event EventHandler PersonelEdit;


        private void Save()
        {
            MusteriModel m = new MusteriModel();
            m.KisiAdi = Musteri.KisiAdi;
            m.KisiSoyadi = Musteri.KisiSoyadi;
            m.Numara = Musteri.Numara;
            m.Telefon = Musteri.Telefon;
            m.KisiId = Musteri.KisiId;
            m.PozisyonId = Musteri.PozisyonId;
            musteriProvider.musteriGuncelle(m);
          
     

            if (PersonelEdit != null)
            {

                PersonelEdit(m, null);


            }
        }



    

    }
}
