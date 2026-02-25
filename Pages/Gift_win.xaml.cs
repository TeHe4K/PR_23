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


                mail_user.Text = _gift.mail;
            }
        }

        private void Click_Cancel_User_Redact(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Remove_User_Redact(object sender, RoutedEventArgs e)
        {

        }

        private void Click_User_Redact(object sender, RoutedEventArgs e)
        {

        }
    }
}
