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
    /// Логика взаимодействия для pgVoucher.xaml
    /// </summary>
    public partial class pgVoucher : Page
    {
        public pgVoucher()
        {
            InitializeComponent();
            DG.ItemsSource = Context.Voucher.ToList();

            chbEmp.IsChecked = true;
            chbClt.IsChecked = true;
            chbTct.IsChecked = true;
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
                    DG.ItemsSource = Context.Voucher.ToList().Where(i => i.IDVoucher == Convert.ToInt32(tbSearch.Text));
                    break;
                case 1:
                    DG.ItemsSource = Context.Voucher.ToList().Where(i => i.TotalCost == Convert.ToInt32(tbSearch.Text));
                    break;
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = Context.Voucher.ToList();
        }

        private void chb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (cb.Name)
            {
                case "chbEmp":
                    if (chbEmp.IsChecked == false) dgtcEmp.Visibility = Visibility.Hidden;
                    else dgtcEmp.Visibility = Visibility.Visible;
                    break;
            }
            switch (cb.Name)
            {
                case "chbClt":
                    if (chbClt.IsChecked == false) dgtcClt.Visibility = Visibility.Hidden;
                    else dgtcClt.Visibility = Visibility.Visible;
                    break;
            }
            switch (cb.Name)
            {
                case "chbTct":
                    if (chbTct.IsChecked == false) dgtcTct.Visibility = Visibility.Hidden;
                    else dgtcTct.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
