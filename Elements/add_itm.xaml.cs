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

namespace PR23_Konevskii.Elements
{
    /// <summary>
    /// Логика взаимодействия для add_itm.xaml
    /// </summary>
    public partial class add_itm : UserControl
    {
        Page page;
        public add_itm(Page _page)
        {
            InitializeComponent();
            page = _page;
        }

        private void Click_add(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Move(MainWindow.main.frame_main, page);
        }
    }
}
