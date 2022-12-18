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
    /// Логика взаимодействия для Bask.xaml
    /// </summary>
    public partial class Bask : Window
    {
        int idU;
        DatabaseEntities db = new DatabaseEntities();
        public Bask(int id)
        {
            InitializeComponent();
            listShop.ItemsSource = db.Basket.Where(x => x.Users_id == id).ToList();
            idU = id;
        }

        private void DelBas_Click(object sender, RoutedEventArgs e)
        {
            Basket bas = (Basket)listShop.SelectedItem;
            db.Basket.Remove(bas);
            db.SaveChanges();
            listShop.ItemsSource = db.Basket.Where(x => x.Users_id == idU).ToList();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            List<Basket> bas = db.Basket.Where(x=>x.Users_id==idU).ToList();
            BuyGames bG;
            foreach(Basket b in bas)
            {
                bG = new BuyGames()
                {
                    Games_id = b.Games_id,
                    Users_id = idU
                };
                db.BuyGames.Add(bG);
                db.Basket.Remove(b);
                db.SaveChanges();
            }
            listShop.ItemsSource = db.Basket.Where(x => x.Users_id == idU).ToList();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            Shop s = new Shop(idU);
            s.Show();
            Close();
        }
    }
}
