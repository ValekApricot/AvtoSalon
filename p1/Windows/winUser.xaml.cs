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

namespace p1.Windows
{
    /// <summary>
    /// Логика взаимодействия для winUser.xaml
    /// </summary>
    public partial class winUser : Window
    {
        private Stopwatch sw = new Stopwatch();
        private DateTime EntrTime;
        public winUser()
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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            switch (mi.Header)
            {
                case "Клиент":
                    Frame.Content = new pgClient();
                    break;
                case "Сотрудник":
                    Frame.Content = new PgEmployee();
                    break;
                case "Гендер":
                    Frame.Content = new PgGender();
                    break;
                case "Должность":
                    Frame.Content = new PgPosition();
                    break;
                case "Услуга":
                    Frame.Content = new PgService();
                    break;
                case "Чек":
                    Frame.Content = new pgVoucher();
                    break;
                case "Продукт":
                    Frame.Content = new pgProduct();
                    break;
                case "Поставщик":
                    Frame.Content = new pgProvider();
                    break;
                case "Statistic":
                    String FN = Context.Employee.ToList().Where(i => i.Email == LoginNow).FirstOrDefault().FirstName;
                    int c = Context.Log.ToList().Where(i => i.Login == LoginNow && i.LogoutReason != "Window close").Count();

                    int a = 0;
                    for (int i = 0; i < Context.Log.ToList().Where(j => j.Login == LoginNow).Count(); i++)
                        a += Context.Log.ToList().Where(j => j.Login == LoginNow).ElementAtOrDefault(i).Time.Second;

                    MessageBox.Show($" {FN}, мы приветствуем вас в автосервисе Old Master \n Общее время в системе: {a} секунд \n Количество отказов системы: {c}");
                    break;
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sw.Stop();

            Log l = new Log();
            DateTime dt = Convert.ToDateTime("00:00:00");
            dt += sw.Elapsed;

            l.Login = LoginNow;
            l.Time = dt;
            l.EntryTime = EntrTime;
            l.OutTime = DateTime.Now;
            l.LogoutReason = "Window close";

            Context.Log.Add(l);
            Context.SaveChanges();
            //MessageBox.Show(Convert.ToInt32(sw.Elapsed.ToString()).ToString());

            Environment.Exit(0);
        }
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Частный автосервис \n" + "Old Master \n" + "Все права защищены");
        }
    }
}
