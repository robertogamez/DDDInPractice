namespace DddInPractice.UI.Common
{
    /// <summary>
    /// Interaction logic for CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow
    {
        public CustomWindow(ViewModel viewModel)
        {
            InitializeComponent();

            //Owner = Application.Current.MainWindow;
            DataContext = viewModel;
        }
    }
}
