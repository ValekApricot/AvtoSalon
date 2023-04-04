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
using p1.Windows;
using static p1.Classes.clEntity;

namespace p1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PgEmployee.xaml
    /// </summary>
    public partial class PgEmployee : Page
    {
        public PgEmployee()
        {
            InitializeComponent();
            DG.ItemsSource = Context.Employee.ToList();

            chbGen.IsChecked = true;
            chbPos.IsChecked = true;
            chbFirst.IsChecked = true;
            chbLast.IsChecked = true;
            chbPatr.IsChecked = true;
            chbBirth.IsChecked = true;
            chbAdr.IsChecked = true;
            chbAccs.IsChecked = true;
            chbRole.IsChecked = true;
            chbPass.IsChecked = true;
            chbEmail.IsChecked = true;
            chbPhone.IsChecked = true;
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
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.IDEmployee == Convert.ToInt32(tbSearch.Text));
                    break;
                case 1:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.FirstName == tbSearch.Text);
                    break;
                case 2:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.LastName == tbSearch.Text);
                    break;
                case 3:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.Patronimic == tbSearch.Text);
                    break;
                case 4:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.Birthday == Convert.ToDateTime(tbSearch.Text));
                    break;
                case 5:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.Phone == Convert.ToInt32(tbSearch.Text));
                    break;
                case 6:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.Email == tbSearch.Text);
                    break;
                case 7:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.Adress == tbSearch.Text);
                    break;
                case 8:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.Role == tbSearch.Text);
                    break;
                case 9:
                    DG.ItemsSource = Context.Employee.ToList().Where(i => i.Active == Convert.ToBoolean(tbSearch.Text));
                    break;
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = Context.Employee.ToList();
        }

        private void chbGen_Click(object sender, RoutedEventArgs e)
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
                case "chbPos":
                    if (chbPos.IsChecked == false) dgtcPos.Visibility = Visibility.Hidden;
                    else dgtcPos.Visibility = Visibility.Visible;
                    break;
            }
            switch (cb.Name)
            {
                case "chbFirst":
                    if (chbFirst.IsChecked == false) dgtcFirst.Visibility = Visibility.Hidden;
                    else dgtcFirst.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbLast":
                    if (chbLast.IsChecked == false) dgtcLast.Visibility = Visibility.Hidden;
                    else dgtcLast.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbPatr":
                    if (chbPatr.IsChecked == false) dgtcPatr.Visibility = Visibility.Hidden;
                    else dgtcPatr.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbBirth":
                    if (chbBirth.IsChecked == false) dgtcBirth.Visibility = Visibility.Hidden;
                    else dgtcBirth.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbPhone":
                    if (chbPhone.IsChecked == false) dgtcPhone.Visibility = Visibility.Hidden;
                    else dgtcPhone.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbEmail":
                    if (chbEmail.IsChecked == false) dgtcEmail.Visibility = Visibility.Hidden;
                    else dgtcEmail.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbAdr":
                    if (chbAdr.IsChecked == false) dgtcAdr.Visibility = Visibility.Hidden;
                    else dgtcAdr.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbRole":
                    if (chbRole.IsChecked == false) dgtcRole.Visibility = Visibility.Hidden;
                    else dgtcRole.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbPass":
                    if (chbPass.IsChecked == false) dgtcPass.Visibility = Visibility.Hidden;
                    else dgtcPass.Visibility = Visibility.Visible; break;
            }
            switch (cb.Name)
            {
                case "chbAccs":
                    if (chbAccs.IsChecked == false) dgtcAccs.Visibility = Visibility.Hidden;
                    else dgtcAccs.Visibility = Visibility.Visible; break;
            }
        }
        private void DG_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var Reason = true;

            if (e.Row.GetIndex() <= Context.Employee.ToList().Count() - 1) Reason = Context.Employee.ToList().ElementAtOrDefault(e.Row.GetIndex()).Active;

            if (Reason == false) e.Row.Background = new SolidColorBrush(Colors.Red);
            else e.Row.Background = new SolidColorBrush(Colors.White);
        }
    }
}