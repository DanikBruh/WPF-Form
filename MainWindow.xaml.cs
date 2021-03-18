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

namespace InputApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Срабатывает при нажатии на кнопку Calculate. Вычисляет два наибольших числа.
        /// </summary>
        private void Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> values = new List<int>();

                IEnumerable<TextBox> collection = InputGrid.Children.OfType<TextBox>();

                foreach (TextBox tb in collection)
                {
                    if (tb.Text == "")
                        throw new Exception("Заполните все поля!");
                    values.Add(Convert.ToUInt16(tb.Text));
                }

                int largest = values.Max();
                int second = 0;

                foreach (int i in values)
                {
                    if (i > second && i < largest)
                    {
                        second = i;
                    }
                }

                MaxValue.Text = Convert.ToString(largest);
                Max2Value.Text = Convert.ToString(second);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Срабатывает при нажатии на кнопку Random. Заполняет ячейки рандомными значениями.
        /// </summary>
        private void InsertRandomValues(object sender, RoutedEventArgs e)
        {
            IEnumerable<TextBox> collection = InputGrid.Children.OfType<TextBox>();
            Random rand = new Random();
            foreach (TextBox tb in collection)
            {
                tb.Text = rand.Next(1, 100).ToString();
            }
            MaxValue.Text = "";
            Max2Value.Text = "";
        }

        /// <summary>
        /// Срабатывает при нажатии на кнопку Exit. Очищает все поля.
        /// </summary>
        private void Exit(object sender, RoutedEventArgs e)
        {
            IEnumerable<TextBox> collectionInner = InputGrid.Children.OfType<TextBox>();
            IEnumerable<TextBox> collectionOuter = OutputGrid.Children.OfType<TextBox>();

            foreach (TextBox tb in collectionInner)
            {
                tb.Text = "";
            }
            foreach (TextBox tb in collectionOuter)
            {
                tb.Text = "";
            }
        }
    }
}
