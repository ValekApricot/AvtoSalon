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
    /// Логика взаимодействия для pgChAddProduct.xaml
    /// </summary>
    public partial class pgChAddProduct : Page
    {
        public pgChAddProduct()
        {
            InitializeComponent();

            cbPrv.ItemsSource = Context.Provider.ToList();
            cbPrv.SelectedIndex = 0;
            cbPrv.DisplayMemberPath = "Name";

            if (Change == true)
            {
                Change = false;

                tbID.Text = Context.Product.ToList().Where(i => i.IDProduct == IDChange).FirstOrDefault().IDProduct.ToString();
                cbPrv.SelectedIndex = Convert.ToInt32(Context.Product.ToList().Where(i => i.IDProduct == IDChange).FirstOrDefault().IDProvider - 1);
                tbNam.Text = Context.Product.ToList().Where(i => i.IDProduct == IDChange).FirstOrDefault().Name;
                tbCst.Text = Context.Product.ToList().Where(i => i.IDProduct == IDChange).FirstOrDefault().Cost.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Product pt = new Product();

            pt.IDProduct = Convert.ToInt32(tbID.Text);
            pt.IDProvider = cbPrv.SelectedIndex + 1;
            pt.Name = tbNam.Text;
            pt.Cost = Convert.ToInt32(tbCst.Text);

            Context.Product.AddOrUpdate(pt);
            Context.SaveChanges();
            MessageBox.Show("Successfully");
        }
    }
}
