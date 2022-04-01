using System.Windows;
using Lw2.ViewModel;


namespace Lw2.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            DataContext = new MainVM(canvas);
        }
    }
}
