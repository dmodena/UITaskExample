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

namespace UITaskExample
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

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "Calculando...";
            long noOfValues = long.Parse(txtInput.Text);
            asyncChangeValue(noOfValues);
            MessageBox.Show("Test");            
        }

        private double computAverages(long noOfValues)
        {
            double total = 0;
            Random rand = new Random();

            for (long values = 0; values < noOfValues; values++)
            {
                total = total + rand.NextDouble();
            }

            return total / noOfValues;
        }

        private Task<double> asyncComputeAverages(long noOfValues)
        {
            return Task<double>.Run(() => {
                return computAverages(noOfValues);
            });
        }

        private async void asyncChangeValue(long noOfValues)
        {
            double result = await(asyncComputeAverages(noOfValues));
            lblResult.Content = result.ToString();
        }
    }
}
