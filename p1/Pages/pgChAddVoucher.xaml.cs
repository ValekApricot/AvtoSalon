using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using p1.DataBase;
using static p1.Classes.clEntity;

namespace p1.Pages
{
    /// <summary>
    /// Логика взаимодействия для pgChAddVoucher.xaml
    /// </summary>
    public partial class pgChAddVoucher : Page
    {
        public pgChAddVoucher()
        {
            InitializeComponent();
            cbClt.ItemsSource = Context.Client.ToList();
            cbClt.SelectedIndex = 0;
            cbClt.DisplayMemberPath = "LastName";

            cbEmp.ItemsSource = Context.Employee.ToList();
            cbEmp.SelectedIndex = 0;
            cbEmp.DisplayMemberPath = "LastName";


            if (Change == true)
            {
                Change = false;

                tbID.Text = Context.Voucher.ToList().Where(i => i.IDVoucher == IDChange).FirstOrDefault().IDClient.ToString();
                cbEmp.SelectedIndex = Context.Voucher.ToList().Where(i => i.IDVoucher == IDChange).FirstOrDefault().IDEmployee - 1;
                cbClt.SelectedIndex = Context.Voucher.ToList().Where(i => i.IDVoucher == IDChange).FirstOrDefault().IDClient - 1;
                tbTCt.Text = Context.Voucher.ToList().Where(i => i.IDVoucher == IDChange).FirstOrDefault().TotalCost.ToString();
                if (Context.Voucher.ToList().Where(i => i.IDVoucher == IDChange).FirstOrDefault().ISDeleted == true) chbdel.IsChecked = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Voucher v = new Voucher();

            v.IDVoucher = Convert.ToInt32(tbID.Text);
            v.IDClient = cbClt.SelectedIndex + 1;
            v.IDEmployee = cbEmp.SelectedIndex + 1;
            v.TotalCost = Int32.Parse(tbTCt.Text);
            if (chbdel.IsChecked == true) v.ISDeleted = true;
            else v.ISDeleted = false;

            Context.Voucher.AddOrUpdate(v);
            Context.SaveChanges();
            MessageBox.Show("Successfully");
        }
    }
}
