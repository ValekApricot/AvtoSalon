using p1.DataBase;
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
using static p1.Classes.clEntity;
using System.Data.Entity.Migrations;

namespace p1.Pages
{
    /// <summary>
    /// Логика взаимодействия для pgChAddProvider.xaml
    /// </summary>
    public partial class pgChAddProvider : Page
    {
        public pgChAddProvider()
        {
            InitializeComponent();

            if (Change == true)
            {
                Change = false;

                tbID.Text = Context.Provider.ToList().Where(i => i.IDProvider == IDChange).FirstOrDefault().IDProvider.ToString();
                tbNam.Text = Context.Provider.ToList().Where(i => i.IDProvider == IDChange).FirstOrDefault().Name;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Provider pr = new Provider();

            pr.IDProvider = Convert.ToInt32(tbID.Text);
            pr.Name = tbNam.Text;

            Context.Provider.AddOrUpdate(pr);
            Context.SaveChanges();
            MessageBox.Show("Successfully");
        }
    }
}
