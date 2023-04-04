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
using static p1.Classes.clEntity;
using System.Threading;
using p1.Windows;
using System;

namespace p1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String cptch = "";
        private int count = 0;
        public MainWindow()
        {
            InitializeComponent();

            Random rand = new Random();
            for (int i = 0; i < 5; i++) cptch += Convert.ToChar(rand.Next(0x0410, 0x44F));
            LbCaptcha.Content = cptch;
        }

        private void LbReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
        }
        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var authUser = Context.Employee.ToList().Where(i => i.Email == tboxAuthLogin.Text && i.Password == tboxAuthPas.Text).FirstOrDefault();
            var authRoleAdm = Context.Employee.ToList().Where(i => i.Email == tboxAuthLogin.Text && i.Role == "admin").FirstOrDefault();
            var authAccess = Context.Employee.ToList().Where(i => i.Email == tboxAuthLogin.Text && i.Active == true).FirstOrDefault();
            if (authUser != null)
            {
                if (authAccess != null)
                {
                    if (tboxCaptcha.Text == cptch)
                    {
                        if (authRoleAdm != null)
                        {
                            LoginNow = tboxAuthLogin.Text;
                            winWork ww = new winWork();
                            ww.Show();
                            this.Close();
                        }
                        else
                        {
                            LoginNow = tboxAuthLogin.Text;
                            winUser wu = new winUser();
                            wu.Show();
                            this.Close();
                        }
                    }
                    else MessageBox.Show("Captcha не совподает");
                }
                else MessageBox.Show("Доступ заблокирован");
            }
            else
            {
                count++;
                MessageBox.Show("Неверный логин или пароль");
                if (count >= 3)
                {
                    btnAuth.IsEnabled = false;
                    Thread thread = new Thread(() =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Dispatcher.Invoke(() => LbTime.Content = "До повторной попытки осталось: " + (10 - i) + " секунд");
                            Thread.Sleep(1000);
                        }
                        Dispatcher.Invoke(() => LbTime.Content = "");
                        Dispatcher.Invoke(() => btnAuth.IsEnabled = true);
                    });
                    thread.Start();
                }
            }
        }
    }
}
