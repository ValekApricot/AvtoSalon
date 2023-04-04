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
using p1.DataBase;
using static p1.Classes.clEntity;

namespace p1.Pages
{
    /// <summary>
    /// Логика взаимодействия для pgLogs.xaml
    /// </summary>
    public partial class pgLogs : Page
    {
        public pgLogs()
        {
            InitializeComponent();
            DG.ItemsSource = Context.Log.ToList();

            chbLog.IsChecked = true;
            chbTIS.IsChecked = true;
            chbEtT.IsChecked = true;
            chbOtT.IsChecked = true;
            chbLtR.IsChecked = true;
        }

        private void DG_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var Reason = "Window close";

            if (e.Row.GetIndex() <= Context.Log.ToList().Count() - 1) Reason = Context.Log.ToList().ElementAtOrDefault(e.Row.GetIndex()).LogoutReason;

            if (Reason != "Window close") e.Row.Background = new SolidColorBrush(Colors.Red);
            else e.Row.Background = new SolidColorBrush(Colors.White);
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CB.SelectedIndex)
            {
                case 0:
                    DG.ItemsSource = Context.Log.ToList().Where(i => i.ID == Convert.ToInt32(tbSearch.Text));
                    break;
                case 2:
                    DG.ItemsSource = Context.Log.ToList().Where(i => i.Time == Convert.ToDateTime(tbSearch.Text));
                    break;
                case 3:
                    DG.ItemsSource = Context.Log.ToList().Where(i => i.EntryTime == Convert.ToDateTime(tbSearch.Text));
                    break;
                case 4:
                    DG.ItemsSource = Context.Log.ToList().Where(i => i.OutTime == Convert.ToDateTime(tbSearch.Text));
                    break;
                case 5:
                    DG.ItemsSource = Context.Log.ToList().Where(i => i.LogoutReason == tbSearch.Text);
                    break;
                case 1:
                    DG.ItemsSource = Context.Log.ToList().Where(i => i.Login == tbSearch.Text);
                    break;
            }
        }
        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = Context.Log.ToList();
        }

        private void chb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (cb.Name)
            {
                case "chbLog":
                    if (chbLog.IsChecked == false) dgtcLog.Visibility = Visibility.Hidden;
                    else dgtcLog.Visibility = Visibility.Visible;
                    break;
            }
            switch (cb.Name)
            {
                case "chbTIS":
                    if (chbTIS.IsChecked == false) dgtcTIS.Visibility = Visibility.Hidden;
                    else dgtcTIS.Visibility = Visibility.Visible;
                    break;
            }
            switch (cb.Name)
            {
                case "chbEtT":
                    if (chbEtT.IsChecked == false) dgtcEtT.Visibility = Visibility.Hidden;
                    else dgtcEtT.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbOtT":
                    if (chbOtT.IsChecked == false) dgtcOtT.Visibility = Visibility.Hidden;
                    else dgtcOtT.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbLtR":
                    if (chbLtR.IsChecked == false) dgtcLtR.Visibility = Visibility.Hidden;
                    else dgtcLtR.Visibility = Visibility.Visible; break;
            }
        }
    }
}