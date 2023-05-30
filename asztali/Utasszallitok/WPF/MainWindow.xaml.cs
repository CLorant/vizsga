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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MachKalkulatorGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void szamolGomb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double qc = double.Parse(toltoNyomasTextBox.Text);
                double p0 = double.Parse(statikusNyomasTextBox.Text);
                double ma = Math.Sqrt(5 * (Math.Pow(qc / p0 + 1, 2.0 / 7) - 1));
                if (ma < 1)
                {
                    eredmenyekListBox.Items.Add($"qc={qc} p0={p0} Ma={ma}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
