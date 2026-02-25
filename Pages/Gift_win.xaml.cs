using PR23_Konevskii.Classes;
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

namespace PR23_Konevskii.Pages
{
    /// <summary>
    /// Логика взаимодействия для Gift_win.xaml
    /// </summary>
    public partial class Gift_win : Page
    {
        Classes.Gift gift;
        public Gift_win(Classes.Gift _gift)
        {
            InitializeComponent();
            gift = _gift;
            if (_gift.name != null)
            {
                fio_user.Text = _gift.name;
                text_user.Text = _gift.description;
                addrec_user.Text = _gift.adress;
                string[] dateLoc1 = _gift.date.ToString().Split(' ');
                string[] date1 = (dateLoc1[0]).Split('.');
                date.SelectedDate = new DateTime(int.Parse(date1[2]), int.Parse(date1[1]), int.Parse(date1[0]));
                time.Text = dateLoc1[1];

                mail_user.Text = _gift.mail;
            }
        }

        private void Click_Cancel_User_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Move(MainWindow.main.frame_main, null, Main.page_main.gift_win);
        }

        private void Click_Remove_User_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.connect.LoadData(Classes.Connection.tabels.gifts);
            string vs = $"DELETE FROM [gifts] WHERE [Код] = " + gift.id.ToString() + "";
            var pc = MainWindow.connect.QueryAccess(vs);
            MainWindow.connect.LoadData(Classes.Connection.tabels.gifts);

            MainWindow.main.Load();
            MainWindow.main.Move(MainWindow.main.frame_main, null, Main.page_main.gift_win);
        }

        private void Click_User_Redact(object sender, RoutedEventArgs e)
        {
            int id = MainWindow.connect.SetLastId(Connection.tabels.gifts);
            string query = $"INSERT INTO [gifts]([Код],[name],[adress],[mail],[date],[description]) VALUES ({id.ToString()}," +
                $"'{fio_user.Text}', '{addrec_user.Text}', '{mail_user.Text}','{date.Text}','{text_user.Text}')";
            var pc = MainWindow.connect.QueryAccess(query);
            if (pc != null)
            {
                MainWindow.connect.LoadData(Classes.Connection.tabels.gifts);
                MessageBox.Show("Успешное добавление клиента", "Успешное", MessageBoxButton.OK, MessageBoxImage.Information);
 
                MainWindow.main.Load();
                MainWindow.main.Move(MainWindow.main.frame_main, null, Main.page_main.gift_win);
            }
            else
            {
                MessageBox.Show("Запрос на добавление клиента не был обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
