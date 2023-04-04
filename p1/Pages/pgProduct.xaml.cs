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
using p1.Classes;
using static p1.Classes.clEntity;

namespace p1.Pages
{
    /// <summary>
    /// Логика взаимодействия для pgProduct.xaml
    /// </summary>
    public partial class pgProduct : Page
    {
        public pgProduct()
        {
            InitializeComponent();
            DG.ItemsSource = Context.Product.ToList();

            chbPrv.IsChecked = true;
            chbNam.IsChecked = true;
            chbCst.IsChecked = true;
        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock x = DG.Columns[0].GetCellContent(DG.Items[DG.SelectedIndex]) as TextBlock;
            IDChange = Convert.ToInt32(x?.Text);
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CB.SelectedIndex)
            {
                case 0:
                    DG.ItemsSource = Context.Product.ToList().Where(i => i.IDProduct == Convert.ToInt32(tbSearch.Text));
                    break;
                case 1:
                    DG.ItemsSource = Context.Product.ToList().Where(i => i.Name == tbSearch.Text);
                    break;
                case 2:
                    DG.ItemsSource = Context.Product.ToList().Where(i => i.Cost == Convert.ToInt32(tbSearch.Text));
                    break;
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = Context.Product.ToList();
        }

        private void chb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (cb.Name)
            {
                case "chbPrv":
                    if (chbPrv.IsChecked == false) dgtcPrv.Visibility = Visibility.Hidden;
                    else dgtcPrv.Visibility = Visibility.Visible;
                    break;
            }
            switch (cb.Name)
            {
                case "chbNam":
                    if (chbNam.IsChecked == false) dgtcNam.Visibility = Visibility.Hidden;
                    else dgtcNam.Visibility = Visibility.Visible;
                    break;
            }
            switch (cb.Name)
            {
                case "chbCst":
                    if (chbCst.IsChecked == false) dgtcCst.Visibility = Visibility.Hidden;
                    else dgtcCst.Visibility = Visibility.Visible; break;
            }
        }
    }
}