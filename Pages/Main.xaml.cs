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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public enum page_main
        {
            main, gift_win, none
        };
        public static page_main page_select;
        public Main()
        {
            InitializeComponent();
            page_select = page_main.none;
            Load();
        }

        public void Load()
        {
            MainWindow.connect.LoadData(Classes.Connection.tabels.gifts);
            parrent.Children.Clear();
            foreach (Gift gift_itm in MainWindow.connect.gifts)
            {
                parrent.Children.Add(new Elements.Gift_itm(gift_itm));
            }
            var ff = new Pages.Gift_win(new Gift());
            parrent.Children.Add(new Elements.add_itm(ff));
        }

        public void Move(Frame frame_main = null, Page pages = null , page_main page_restart = page_main.none)
        {
            frame_main.Navigate(pages);
        }
    }
}
