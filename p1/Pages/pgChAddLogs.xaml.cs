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
    /// Логика взаимодействия для pgChAddLogs.xaml
    /// </summary>
    public partial class pgChAddLogs : Page
    {
        public pgChAddLogs()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Log lg = new Log();

            DateTime dt = Convert.ToDateTime("00:00:00");
            dt += TimeSpan.Parse(tbTIS.Text);
            MessageBox.Show(dt.ToString());

            lg.Login = tbLog.Text;
            lg.Time = dt;
            lg.EntryTime = dpEnT.SelectedDate.Value;
            lg.OutTime = dpOtT.SelectedDate.Value;
            lg.LogoutReason = tbLgR.Text;

            Context.Log.AddOrUpdate(lg);
            Context.SaveChanges();
            MessageBox.Show("Successfully");
        }
    }
} 

