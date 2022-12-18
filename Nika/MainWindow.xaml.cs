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

namespace Nika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            DatabaseEntities db = new DatabaseEntities();
            if (db.Users.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).Count() > 0)
            {
                Users user = db.Users.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).FirstOrDefault();
                MessageBox.Show($"Вход выполнен под пользователем {user.Login}");
                Shop shop = new Shop(user.ID);
                shop.Show();
                Close();
            }
            else MessageBox.Show("Данные для входа не верны");
        }
    }
}
