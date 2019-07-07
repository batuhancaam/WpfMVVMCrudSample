using Microsoft.Win32;
using Project.Helper;
using Project.Model;
using Project.View;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModel
{
    public class MusteriViewModel : INotifyPropertyChanged
    {
        MusteriProvider musteriProvaider = new MusteriProvider();
        PozisyonProvider pozisyonProvider = new PozisyonProvider();
        ResimProvider resimProvider = new ResimProvider();

        #region Constructors
        private ObservableCollection<MusteriModel> musteriList;
        public ObservableCollection<MusteriModel> MusteriList
        {
            get { return musteriList; }
            set
            {
                musteriList = value;
            }

        }

        private List<PozisyonModel> pozisyonList;

        public List<PozisyonModel> PozisyonList
        {
            get { return pozisyonList; }
            set
            {
                pozisyonList = value;
                OnPropertyChanged("PozisyonList");

            }
        }

        public MusteriViewModel()
        {
            musteriList = new ObservableCollection<MusteriModel>(musteriProvaider.MusteriGetir());
            pozisyonList = pozisyonProvider.pozisyonGetir();

        }

        #endregion




        #region     ICommands 


        private ICommand upListCommand;

        public ICommand UpListCommand
        {
            get
            {
                if (upListCommand == null)
                {
                    upListCommand = new RelayCommand(UpList);
                }
                return upListCommand;

            }

        }

        private void UpList()
        {


            if (MusteriList.IndexOf(SelecItem) != 0 && MusteriList.IndexOf(SelecItem) != -1)
            {
                var Index = MusteriList.IndexOf(SelecItem);
                var temp = MusteriList[Index];
                MusteriList[Index] = MusteriList[Index - 1];
                MusteriList[Index - 1] = temp;
                SelecItem = MusteriList[Index - 1];
            }
        }

        private ICommand downListCommand;

        public ICommand DownListCommand
        {
            get
            {
                if (downListCommand == null)
                    downListCommand = new RelayCommand(DownList);
                return downListCommand;
            }

        }

        private void DownList()


        {
            if (MusteriList.IndexOf(selecItem) != MusteriList.Count - 1 && MusteriList.IndexOf(SelecItem) != -1)
            {
                var Index = MusteriList.IndexOf(SelecItem);
                var temp = MusteriList[Index];
                MusteriList[Index] = MusteriList[Index + 1];
                MusteriList[Index + 1] = temp;
                SelecItem = MusteriList[Index + 1];
            }
        }



        private ICommand deletePersonelCommand;

        public ICommand DeletePersonelCommand
        {
            get
            {
                if (deletePersonelCommand == null)
                    deletePersonelCommand = new RelayCommand(DeletePersonel);
                return deletePersonelCommand;
            }
        }

        private void DeletePersonel()
        {
            resimProvider.resimSil(SelecItem.KisiId);
            musteriProvaider.musteriSil(selecItem);
            MusteriList.Remove(selecItem);
        }


        private ICommand addCustomerCommand;

        public ICommand AddCustomerCommand
        {
            get
            {
                if (addCustomerCommand == null)
                    addCustomerCommand = new RelayCommand(AddCustomer);
                return addCustomerCommand;
            }
        }

        AddCustomerWindow window;
        private void AddCustomer()
        {
            if (window == null)
            {
                MusteriModel musteri = new MusteriModel();

                window = new AddCustomerWindow(musteri);

                window.AddCustomerViewModel.PersonelSave += AddCustomerViewModelSaved;
                window.Closing += AddCustomerWindowClosing;
                window.Show();





            }

            else
            {

                window.Focus();

            }



        }

        private void AddCustomerViewModelSaved(object sender, EventArgs e)
        {
            window.Close();

            MusteriList.Add((MusteriModel)sender);



        }

        private void AddCustomerWindowClosing(object sender, EventArgs e)
        {
            window.Dispose();
            window = null;



        }




        private ICommand editCustomerCommand;

        public ICommand EditCustomerCommand
        {
            get
            {
                if (editCustomerCommand == null)
                    editCustomerCommand = new RelayCommand(Edit);
                return editCustomerCommand;

            }

        }
        EditCustomerWindow EditWindow;
        private void Edit()
        {
            if (EditWindow == null)
            {

                EditWindow = new EditCustomerWindow(selecItem);
                EditWindow.EditCustomerViewModel.PersonelEdit += EditCustomerViewModelSaved;
                EditWindow.Closing += EditCustomerWindowClosing;
                EditWindow.Show();


            }

            else
            {

                EditWindow.Focus();
                
            }


        }

        private void EditCustomerWindowClosing(object sender, CancelEventArgs e)
        {
            EditWindow.Dispose();
            EditWindow = null;
        }

        private void EditCustomerViewModelSaved(object sender, EventArgs e)
        {
            EditWindow.Close();
           
          
        }


        






        #endregion

        #region EventHandler



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private MusteriModel selecItem;

        public MusteriModel SelecItem
        {
            get { return selecItem; }
            set
            {
                selecItem = value;
                OnPropertyChanged(nameof(SelecItem));
            }
        }

        #endregion


    }
}
