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
    /// Логика взаимодействия для pgClient.xaml
    /// </summary>
    public partial class pgClient : Page
    {
        public pgClient()
        {
            InitializeComponent();
            DG.ItemsSource = Context.Client.ToList();

            chbGen.IsChecked = true;
            chbFst.IsChecked = true;
            chbLst.IsChecked = true;
            chbPtr.IsChecked = true;
            chbBrt.IsChecked = true;
            chbEml.IsChecked = true;
            chbPhn.IsChecked = true;
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CB.SelectedIndex)
            {
                case 0:
                    DG.ItemsSource = Context.Client.ToList().Where(i => i.IDClient == Convert.ToInt32(tbSearch.Text));
                    break;
                case 1:
                    DG.ItemsSource = Context.Client.ToList().Where(i => i.FirstName == tbSearch.Text);
                    break;
                case 2:
                    DG.ItemsSource = Context.Client.ToList().Where(i => i.LastName == tbSearch.Text);
                    break;
                case 3:
                    DG.ItemsSource = Context.Client.ToList().Where(i => i.Patronimic == tbSearch.Text);
                    break;
                case 4:
                    DG.ItemsSource = Context.Client.ToList().Where(i => i.Birthday == Convert.ToDateTime(tbSearch.Text));
                    break;
            }
        }
        private void chb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (cb.Name)
            {
                case "chbGen":
                    if (chbGen.IsChecked == false) dgtcGen.Visibility = Visibility.Hidden;
                    else dgtcGen.Visibility = Visibility.Visible;
                    break;
            }
            switch (cb.Name)
            {
                case "chbFst":
                    if (chbFst.IsChecked == false) dgtcFst.Visibility = Visibility.Hidden;
                    else dgtcFst.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbLst":
                    if (chbLst.IsChecked == false) dgtcLst.Visibility = Visibility.Hidden;
                    else dgtcLst.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbPtr":
                    if (chbPtr.IsChecked == false) dgtcPtr.Visibility = Visibility.Hidden;
                    else dgtcPtr.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbBrt":
                    if (chbBrt.IsChecked == false) dgtcBrt.Visibility = Visibility.Hidden;
                    else dgtcBrt.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbPhn":
                    if (chbPhn.IsChecked == false) dgtcPhn.Visibility = Visibility.Hidden;
                    else dgtcPhn.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbEml":
                    if (chbEml.IsChecked == false) dgtcEml.Visibility = Visibility.Hidden;
                    else dgtcEml.Visibility = Visibility.Visible; break;
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = Context.Client.ToList();
        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock x = DG.Columns[0].GetCellContent(DG.Items[DG.SelectedIndex]) as TextBlock;
            IDChange = Convert.ToInt32(x?.Text);
            
        }
    }
}
