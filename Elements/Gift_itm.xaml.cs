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
                string[] dateLoc1 = _gift.date.ToString().Split(' ');

                string[] date1 = (dateLoc1[0]).Split('.');

                System.DateTime date = new DateTime(int.Parse(date1[2]),
                    int.Parse(date1[1]),
                    int.Parse(date1[0]),
                    int.Parse(dateLoc1[1].Split(':')[0]),
                    int.Parse(dateLoc1[1].Split(':')[1]), 0);
                date_user.Content = "Продолжительность звонка: " + date.ToString();
                mail_user.Content = _gift.mail;
            }
        }
    }
}
