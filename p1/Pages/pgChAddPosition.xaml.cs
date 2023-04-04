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
using p1.DataBase;
using static p1.Classes.clEntity;
using System.Data.Entity.Migrations;

namespace p1.Pages
{
    /// <summary>
    /// Логика взаимодействия для pgChAddPosition.xaml
    /// </summary>
    public partial class pgChAddPosition : Page
    {
        public pgChAddPosition()
        {
            InitializeComponent();

            if (Change == true)
            {
                Change = false;

                tbID.Text = Context.Position.ToList().Where(i => i.IDPosition == IDChange).FirstOrDefault().IDPosition.ToString();
                tbNam.Text = Context.Position.ToList().Where(i => i.IDPosition == IDChange).FirstOrDefault().Name;
                tbSal.Text = Context.Position.ToList().Where(i => i.IDPosition == IDChange).FirstOrDefault().Salary.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Position p = new Position();

            p.IDPosition = Convert.ToInt32(tbID.Text);
            p.Name = tbNam.Text;
            p.Salary = Convert.ToInt32(tbSal.Text);

            Context.Position.AddOrUpdate(p);
            Context.SaveChanges();
            MessageBox.Show("Successfully");
        }
    }
} 

