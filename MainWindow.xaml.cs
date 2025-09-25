using System.Windows;
using System.Windows.Documents;

namespace Terminplaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        private List _appointments = new List();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        
        private void ShowDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new yewah();
            var result = dialog.ShowDialog();
            
            MessageBox.Show(result == true ? "User clicked OK" : "User clicked Cancel");
        }

        

        private void createAppointment(object sender, RoutedEventArgs e) {
            
            ShowDialogButton_Click(sender, e);  
        }
    }

}