using Project.ViewModel;
using System.Windows;
using Project.View;
 

namespace Project
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MusteriView window = new MusteriView(); 
            window.Show();
        }
    }
}
