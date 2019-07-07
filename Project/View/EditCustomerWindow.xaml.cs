using System;
using Project.ViewModel;
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
    /// EditCustomerWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class EditCustomerWindow : Window , IDisposable
    {
       public EditCustomerViewModel EditCustomerViewModel;
        public EditCustomerWindow(Model.MusteriModel selecItem)
        {
            InitializeComponent();
            EditCustomerViewModel = new EditCustomerViewModel(selecItem);
            DataContext = EditCustomerViewModel;
        }

   

        public void Dispose()
        {
            EditCustomerViewModel = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }

    }
}
