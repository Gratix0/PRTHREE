using System;
using System.Collections.Generic;
using System.Data;
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
using PR.ColorAndCarDataSetTableAdapters;

namespace PR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OfficeTableAdapter Office = new OfficeTableAdapter();
        produktTableAdapter Product = new produktTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            ColorTable.ItemsSource = Office.GetData();
            CarTable.ItemsSource = Product.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Office.InsertQuery(TextBXL.Text);
            ColorTable.ItemsSource = Office.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (ColorTable.SelectedItem as DataRowView).Row[0];
            Office.DeleteQuery(Convert.ToInt32(id));
            ColorTable.ItemsSource = Office.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Product.InsertQuery(Convert.ToInt32(TextBXR.Text));
            CarTable.ItemsSource = Product.GetData();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object id = (CarTable.SelectedItem as DataRowView).Row[0];
            Product.DeleteQuery(Convert.ToInt32(id));
            CarTable.ItemsSource = Product.GetData();
        }
    }
}
