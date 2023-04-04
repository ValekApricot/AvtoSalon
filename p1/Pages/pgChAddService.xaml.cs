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
using p1.Windows;
using static p1.Classes.clEntity;

namespace p1.Pages
{
    /// <summary>
    /// Логика взаимодействия для pgChAddService.xaml
    /// </summary>
    public partial class pgChAddService : Page
    {
        public pgChAddService()
        {
            InitializeComponent();

            if (Change == true)
            {
                Change = false;

                tbID.Text = Context.Service.ToList().Where(i => i.IDService == IDChange).FirstOrDefault().IDService.ToString();
                tbNam.Text = Context.Service.ToList().Where(i => i.IDService == IDChange).FirstOrDefault().Name;
                tbCst.Text = Context.Service.ToList().Where(i => i.IDService == IDChange).FirstOrDefault().Cost.ToString();
                if (Context.Service.ToList().Where(i => i.IDService == IDChange).FirstOrDefault().ISDeleted == true) chbDel.IsChecked = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Service s = new Service();

            s.IDService = Convert.ToInt32(tbID.Text);
            s.Name = tbNam.Text;
            s.Cost = Convert.ToInt32(tbCst.Text);
            if (chbDel.IsChecked == true) s.ISDeleted = true;
            else s.ISDeleted = false;

            Context.Service.AddOrUpdate(s);
            Context.SaveChanges();
            MessageBox.Show("Successfully");
        }
    }
}
