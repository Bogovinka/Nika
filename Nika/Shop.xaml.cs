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
using System.Windows.Shapes;

namespace Nika
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        int idU;
        DatabaseEntities db = new DatabaseEntities();
        public Shop(int id)
        {
            InitializeComponent();
            idU = id;
            listShop.ItemsSource = db.Games.ToList();
            listMy.ItemsSource = db.BuyGames.Where(x => x.Users_id == idU).ToList();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void bas_Click(object sender, RoutedEventArgs e)
        {
            Bask b = new Bask(idU);
            b.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int idG = Convert.ToInt32(b.Tag);
            if (db.Basket.Where(x => x.Games_id == idG && x.Users_id == idU).Count() == 0 && db.BuyGames.Where(x => x.Games_id == idG && x.Users_id == idU).Count() == 0)
            {
                MessageBox.Show("Игра добавлена в корзрину");
                Basket bas = new Basket()
                {
                    Games_id = idG,
                    Users_id = idU
                };
                db.Basket.Add(bas);
                db.SaveChanges();
            }
            else MessageBox.Show("Эта игра уже куплена или в корзине");
        }
    }
}
