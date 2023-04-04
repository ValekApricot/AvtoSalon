using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
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
    /// Логика взаимодействия для pgChAddEmployee.xaml
    /// </summary>
    public partial class pgChAddEmployee : Page
    {
        public pgChAddEmployee()
        {
            InitializeComponent();
            CBGender.ItemsSource = Context.Gender.ToList();
            CBGender.SelectedIndex = 0;
            CBGender.DisplayMemberPath = "Name";

            CBPosition.ItemsSource = Context.Position.ToList();
            CBPosition.SelectedIndex = 0;
            CBPosition.DisplayMemberPath = "Name";

            if (Change == true)
            {
                Change = false;

                CBGender.SelectedIndex = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().IDGender;
                CBPosition.SelectedIndex = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().IDPosition - 1;
                tbFirst.Text = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().FirstName;
                tbLast.Text = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().LastName;
                tbPatr.Text = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().Patronimic;
                DP.SelectedDate = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().Birthday;
                tbPhone.Text = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().Phone.ToString();
                tbEmail.Text = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().Email;
                tbAdress.Text = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().Adress;
                if (Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().Role == "admin") rbAdmin.IsChecked = true;
                else rbUser.IsChecked = true;
                tbPass.Text = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().Password;
                if (Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().Active == true) chbAccess.IsChecked = true;
                tbID.Text = Context.Employee.ToList().Where(i => i.IDEmployee == IDChange).FirstOrDefault().IDEmployee.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();

            emp.IDEmployee = Convert.ToInt32(tbID.Text);
            emp.IDGender = CBGender.SelectedIndex;
            emp.IDPosition = CBPosition.SelectedIndex + 1;
            emp.FirstName = tbFirst.Text;
            emp.LastName = tbLast.Text;
            emp.Patronimic = tbPatr.Text;
            emp.Birthday = DP.SelectedDate.Value;
            emp.Phone = Convert.ToInt32(tbPhone.Text);
            emp.Email = tbEmail.Text;
            emp.Adress = tbAdress.Text;
            if (rbAdmin.IsChecked == true) emp.Role = "admin";
            else if (rbUser.IsChecked == true) emp.Role = "user";
            emp.Password = tbPass.Text;
            if (chbAccess.IsChecked == true) emp.Active = true;

            Context.Employee.AddOrUpdate(emp);
            Context.SaveChanges();
            MessageBox.Show("Successfully");
        }
    }
}
