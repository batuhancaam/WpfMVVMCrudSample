using System;
using Project.Helper;
using Project.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Project.ViewModel
{
    public class AddCustomerViewModel : INotifyPropertyChanged
    {
        #region Constructors


        ResimProvider ResimProvider = new ResimProvider();

        private MusteriModel musteri;
        public MusteriModel Musteri
        {
            get { return musteri; }
            set
            {
                musteri = value;
                OnPropertyChanged(nameof(musteri));
            }
        }

        public AddCustomerViewModel(MusteriModel musteri)
        {
            Musteri = musteri;
        }




        private string selectPozisyon;

        public string SelectPozisyon
        {
            get { return selectPozisyon; }
            set { selectPozisyon = value; }
        }
        #endregion

        #region ICommands

        private ICommand saveCustomerCommand;

        public ICommand SaveCustomerCommand
        {
            get
            {
                if (saveCustomerCommand == null)
                    saveCustomerCommand = new RelayCommand(Save);
                return saveCustomerCommand;

            }

        }
        public event EventHandler PersonelSave;
        public event PropertyChangedEventHandler PropertyChanged;

        private void Save()
        {

            MusteriModel musteri = new MusteriModel();

            musteri.KisiAdi = Musteri.KisiAdi;
            musteri.KisiSoyadi = Musteri.KisiSoyadi;
            musteri.Numara = Musteri.Numara;
            musteri.Telefon = Musteri.Telefon;
            musteri.PozisyonId = int.Parse(SelectPozisyon);
            MusteriProvider musteriProvider = new MusteriProvider();
            musteriProvider.musteriEkle(musteri);
            musteri = musteriProvider.tekMusteriGetir();
            ResimProvider.resimEkle(base64Encoded,musteri.KisiId);


            if (PersonelSave != null)
            {

                PersonelSave(musteri, null);


            }





        }


        private ICommand saveDialog;

        public ICommand SaveDialogCommand
        {
            get
            {
                if (saveDialog == null)
                    saveDialog = new RelayCommand(Open);
                return saveDialog;

            }

        }

        public string base64Encoded { get; set; }
        private void Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open Image";
            open.ShowDialog();
            base64Encoded = Convert.ToBase64String(File.ReadAllBytes(open.FileName));
            ImageSource = open.FileName;








        }


        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


        private string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }


        #endregion
    }
}

