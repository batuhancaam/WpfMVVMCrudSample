using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.View
{
    /// <summary>
    /// AddCustomerWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class AddCustomerWindow : Window, IDisposable
    {
        public AddCustomerViewModel AddCustomerViewModel;
        public AddCustomerWindow(Model.MusteriModel musteri)
        {
            InitializeComponent();
            AddCustomerViewModel = new AddCustomerViewModel(musteri);
            DataContext = AddCustomerViewModel;
        }

        public void Dispose()
        {
            AddCustomerViewModel = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
