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
using p1.Classes;
using p1.DataBase;
using static p1.Classes.clEntity;

namespace p1.Pages
{
    /// <summary>
    /// Логика взаимодействия для pgChAddClient.xaml
    /// </summary>
    public partial class pgChAddClient : Page
    {
        public pgChAddClient()
        {
            InitializeComponent();
            CBGender.ItemsSource = Context.Gender.ToList();
            CBGender.SelectedIndex = 0;
            CBGender.DisplayMemberPath = "Name";

            if (Change == true)
            {
                Change = false;

                tbID.Text = Context.Client.ToList().Where(i => i.IDClient == IDChange).FirstOrDefault().IDClient.ToString();
                CBGender.SelectedIndex = Context.Client.ToList().Where(i => i.IDClient == IDChange).FirstOrDefault().IDGender;
                tbFirst.Text = Context.Client.ToList().Where(i => i.IDClient == IDChange).FirstOrDefault().FirstName;
                tbLast.Text = Context.Client.ToList().Where(i => i.IDClient == IDChange).FirstOrDefault().LastName;
                tbPatr.Text = Context.Client.ToList().Where(i => i.IDClient == IDChange).FirstOrDefault().Patronimic;
                DP.SelectedDate = Context.Client.ToList().Where(i => i.IDClient == IDChange).FirstOrDefault().Birthday;
                tbPhone.Text = Context.Client.ToList().Where(i => i.IDClient == IDChange).FirstOrDefault().Phone.ToString();
                tbEmail.Text = Context.Client.ToList().Where(i => i.IDClient == IDChange).FirstOrDefault().Email;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Client cln = new Client();

            cln.IDClient = Convert.ToInt32(tbID.Text);
            cln.IDGender = CBGender.SelectedIndex;
            cln.FirstName = tbFirst.Text;
            cln.LastName = tbLast.Text;
            cln.Patronimic = tbPatr.Text;
            cln.Birthday = DP.SelectedDate.Value;
            cln.Phone = Convert.ToInt32(tbPhone.Text);
            cln.Email = tbEmail.Text;

            Context.Client.AddOrUpdate(cln);
            Context.SaveChanges();
            MessageBox.Show("Successfully");
        }
    }
}
