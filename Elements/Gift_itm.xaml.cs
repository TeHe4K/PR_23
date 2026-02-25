using PR23_Konevskii.Classes;
using PR23_Konevskii.Pages;
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

namespace PR23_Konevskii.Elements
{
    /// <summary>
    /// Логика взаимодействия для Gift_itm.xaml
    /// </summary>
    public partial class Gift_itm : UserControl
    {
        Gift gift;
        public Gift_itm(Gift _gift)
        {
            InitializeComponent();
            gift = _gift;
            if(_gift.name != null)
            {
                name_user.Content = _gift.name;
                text_user.Content = _gift.description;
                addres_user.Content = _gift.adress;

                date_user.Content = _gift.date.ToString()+ " " + _gift.Time.ToString();
                mail_user.Content = _gift.mail;
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            MainWindow.connect.LoadData(Classes.Connection.tabels.gifts);
            string vs = $"DELETE FROM [gifts] WHERE [Код] = " + gift.id.ToString() + "";
            var pc = MainWindow.connect.QueryAccess(vs);
            MainWindow.connect.LoadData(Classes.Connection.tabels.gifts);

            MainWindow.main.Load();
            MainWindow.main.Move(MainWindow.main.frame_main, null, Main.page_main.gift_win);
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Move(MainWindow.main.frame_main, new Pages.Gift_win(gift), Main.page_main.gift_win);
        }
    }
}
