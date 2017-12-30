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

namespace adventofcode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Populate the day selection combo box using reflection
            var solverInterfaceType = typeof(ISolver);
            var allSolvers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => solverInterfaceType.IsAssignableFrom(x) && !x.IsInterface)
                .Select(x => Activator.CreateInstance(x));

            foreach (ISolver solver in allSolvers)
            {
                dayComboBox.Items.Add(solver);
            }

        }

        // Method to parse the input string and the selected day and pass input string to necessary solver
        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            String inputString = inputTextBox.Text;

            if(inputString == null || inputString == "")
            {
                MessageBox.Show("Please enter a valid input string");

                return;
            }

            if (dayComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid day");

                return;
            }

            ISolver selectedSolver = (ISolver)dayComboBox.SelectedItem;

            Tuple<String, String> result = selectedSolver.solve(inputString);

            output1TextBox.Text = result.Item1;
            output2TextBox.Text = result.Item2;
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(sender.Equals(copy1Button) ? output1TextBox.Text : output2TextBox.Text);
        }
    }
}
