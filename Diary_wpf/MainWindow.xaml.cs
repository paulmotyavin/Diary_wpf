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

namespace Diary_wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            date();
        }
        private void date()
        {
            DateTime date = DateTime.Now;
            datepicker.Text = date.ToString();
            datepicker.DisplayDateStart = new DateTime(2023, 01, 01);
            datepicker.DisplayDateEnd = new DateTime(2023, 12, 31);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            listbox.Items.Clear();
            De_serilization.Deserialize< List<Model>>();
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_name.Text.Length != 0 && tbx_description.Text.Length != 0)
            {
                Model model = new Model(tbx_name.Text, tbx_description.Text, datepicker.DisplayDate);
                /*collection.Add(tbx_name.Text);*/
                Model.collection.Add(model);
                /*                listbox.ItemsSource = collection;
                */
                listbox.Items.Add(tbx_name.Text);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.Items.Count > 0)
            {
                listbox.Items.RemoveAt(listbox.SelectedIndex);
            }

        }

        private void Save_Button(object sender, RoutedEventArgs e)
        {
            De_serilization.Serialization(Model.collection);
        }
    }
}
