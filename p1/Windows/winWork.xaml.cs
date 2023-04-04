using p1.Classes;
using p1.DataBase;
using p1.Pages;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static p1.Classes.clEntity;
using p1.Windows;
using System.Threading;
using System.Reflection.Emit;

namespace p1.Windows
{
    /// <summary>
    /// Логика взаимодействия для winWork.xaml
    /// </summary>
    public partial class winWork : Window
    {
        private Stopwatch sw = new Stopwatch();
        private DateTime EntrTime;
        private string frameNow;
        public winWork()
        {
            InitializeComponent();
            EntrTime = DateTime.Now;
            sw.Start();
            Frame.Content = new PgEmployee();

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Dispatcher.Invoke(() => lbTIme.Content = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                    Dispatcher.Invoke(() => lbDate.Content = DateTime.Now.DayOfWeek + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    Thread.Sleep(400);
                }
            });
            thread.Start();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sw.Stop();

            MainWindow mw = new MainWindow();
            Log l = new Log();

            DateTime dt = Convert.ToDateTime("00:00:00");
            dt += sw.Elapsed;

            l.Login = LoginNow;
            l.Time = dt;
            l.EntryTime = EntrTime;
            l.OutTime = System.DateTime.Now;
            l.LogoutReason = "Window close";

            Context.Log.Add(l);
            Context.SaveChanges();
            

            Environment.Exit(0);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            btnChange.Visibility = Visibility.Visible;
            MenuItem mi = sender as MenuItem;
            switch (mi.Header)
            {
                case "Клиент":
                    frameNow = "Клиент";
                    Frame.Content = new pgClient();
                    break;
                case "Сотрудник":
                    frameNow = "Сотрудник";
                    Frame.Content = new PgEmployee();
                    break;
                case "Гендер":
                    frameNow = "Гендер";
                    Frame.Content = new PgGender();
                    break;
                case "Должность":
                    frameNow = "Должность";
                    Frame.Content = new PgPosition();
                    break;
                case "Услуга":
                    frameNow = "Услуга";
                    Frame.Content = new PgService();
                    break;
                case "Чек":
                    frameNow = "Чек";
                    Frame.Content = new pgVoucher();
                    break;
                case "Продукт":
                    frameNow = "Продукт";
                    Frame.Content = new pgProduct();
                    break;
                case "Поставщик":
                    frameNow = "Поставщик";
                    Frame.Content = new pgProvider();
                    break;
                case "Logs":
                    frameNow = "Logs";
                    Frame.Content = new pgLogs();
                    btnChange.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void btnChangeAdd_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Name == "btnChange") Change = true;

            switch (frameNow)
            {
                case "Клиент":
                    Frame.Content = new pgChAddClient();
                    break;
                case "Сотрудник":
                    Frame.Content = new pgChAddEmployee();
                    break;
                case "Гендер":
                    Frame.Content = new pgChAddGender();
                    break;
                case "Logs":
                    Frame.Content = new pgChAddLogs();
                    break;
                case "Должность":
                    Frame.Content = new pgChAddPosition();
                    break;
                case "Продукт":
                    Frame.Content = new pgChAddProduct();
                    break;
                case "Поставщик":
                    Frame.Content = new pgChAddProvider();
                    break;
                case "Услуга":
                    Frame.Content = new pgChAddService();
                    break;
                case "Чек":
                    Frame.Content = new pgChAddVoucher();
                    break;
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            switch (frameNow)
            {
                case "Клиент":
                    Client cln = Context.Client.First(i => i.IDClient == IDChange);
                    Context.Client.Remove(cln);
                    Context.SaveChanges();
                    Frame.Content = new pgClient();
                    break;
                case "Сотрудник":
                    Employee em = Context.Employee.First(i => i.IDEmployee == IDChange);
                    Context.Employee.Remove(em);
                    Context.SaveChanges();
                    Frame.Content = new PgEmployee();
                    break;
                case "Гендер":
                    Gender g = Context.Gender.First(i => i.IDGender == IDChange);
                    Context.Gender.Remove(g);
                    Context.SaveChanges();
                    Frame.Content = new PgGender();
                    break;
                case "Logs":
                    Log l = Context.Log.First(i => i.ID == IDChange);
                    Context.Log.Remove(l);
                    Context.SaveChanges();
                    Frame.Content = new pgLogs();
                    break;
                case "Должность":
                    Position p = Context.Position.First(i => i.IDPosition == IDChange);
                    Context.Position.Remove(p);
                    Context.SaveChanges();
                    Frame.Content = new PgPosition();
                    break;
                case "Продукт":
                    Product pt = Context.Product.First(i => i.IDProduct == IDChange);
                    Context.Product.Remove(pt);
                    Context.SaveChanges();
                    Frame.Content = new pgProduct();
                    break;
                case "Поставщик":
                    Provider pr = Context.Provider.First(i => i.IDProvider == IDChange);
                    Context.Provider.Remove(pr);
                    Context.SaveChanges();
                    Frame.Content = new pgProvider();
                    break;
                case "Услуга":
                    Service s = Context.Service.First(i => i.IDService == IDChange);
                    Context.Service.Remove(s);
                    Context.SaveChanges();
                    Frame.Content = new PgService();
                    break;
                case "Чек":
                    Voucher v = Context.Voucher.First(i => i.IDVoucher == IDChange);
                    Context.Voucher.Remove(v);
                    Context.SaveChanges();
                    Frame.Content = new pgVoucher();
                    break;
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Частный автосервис \n" + "Old Master \n" + "Все права защищены");
        }
    }
}
