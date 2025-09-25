using System.Windows;
using System.Windows.Controls;

namespace Terminplaner;

public partial class yewah : Window
{
    public bool DialogResultValue { get; private set; }

    public yewah()
    {
        InitializeComponent();
    }


    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        DialogResultValue = true;
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResultValue = false;
    }

    public bool? ShowDialog()
    {
        return DialogResultValue;
    }
}