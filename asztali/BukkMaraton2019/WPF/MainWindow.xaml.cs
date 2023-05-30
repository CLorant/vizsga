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

namespace BukkMaraton2019GUI
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
                ComboBoxItem selectedItem = (ComboBoxItem)tavComboBox.SelectedItem;
                int tav = int.Parse(selectedItem.Content.ToString().Split('-')[1].Substring(1, 2));
                int[] temp = idoTextBox.Text.Split(':').Select(int.Parse).ToArray();
                TimeSpan ido = new TimeSpan(temp[0], temp[1], temp[2]);
                atlagSebessegKMH.Content = string.Format("{0:0.00}", tav / ido.TotalHours);
                atlagSebessegMS.Content = string.Format("{0:0.00}", (tav * 1000 / (ido.TotalHours * 3600)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
