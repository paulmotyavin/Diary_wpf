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
        List<Model> items_today = new List<Model>();
        public MainWindow()
        {
            InitializeComponent();
            date();
            Model.collection = De_serilization.Deserialize<List<Model>>();
        }
        private void date()
        {
            DateTime date = DateTime.Now;
            datepicker.Text = date.ToString();
            datepicker.DisplayDateStart = new DateTime(2023, 01, 01);
            datepicker.DisplayDateEnd = new DateTime(2023, 12, 31);
        }
        private void update_tbx()
        {
            items_today = Model.collection.Where(x => x.Date == datepicker.SelectedDate.Value).ToList();

            if (items_today.Count > 0)
            {
                foreach (var i in items_today)
                {
                    listbox.Items.Add(i.Name);
                    save.IsEnabled = true;
                    delete.IsEnabled = true;
                }
            }
            else
            {
                tbx_description.Text = "";
                tbx_name.Text = "";
                save.IsEnabled = false;
                delete.IsEnabled = false;
            }
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            listbox.Items.Clear();
            update_tbx();
        }
        private void update_lbx()
        {
            items_today = Model.collection.Where(x => x.Date == datepicker.SelectedDate.Value).ToList();
            if (listbox.SelectedItem != null)
            {
                int i = listbox.SelectedIndex;
                foreach (var item in items_today)
                {
                    if (item.Name == listbox.SelectedItem.ToString())
                    {
                        tbx_name.Text = item.Name;
                        tbx_description.Text = item.Description;
                    }
                }
            }
        }
        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update_lbx();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_name.Text.Length != 0 && tbx_description.Text.Length != 0)
            {
                Model model = new Model(tbx_name.Text, tbx_description.Text, datepicker.SelectedDate.Value);
                Model.collection.Add(model);
                listbox.Items.Add(tbx_name.Text);
                De_serilization.Serialization(Model.collection);
                Model.collection = De_serilization.Deserialize<List<Model>>();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            items_today = Model.collection.Where(x => x.Date == datepicker.SelectedDate.Value).ToList();
            foreach (var item in items_today)
            {
                if (item.Name == listbox.SelectedItem)
                {
                    Model.collection = Model.collection.Where(x => x.Description != item.Description).ToList();
                    De_serilization.Serialization(Model.collection);
                    Model.collection = De_serilization.Deserialize<List<Model>>();
                }
            }
            tbx_description.Text = "";
            tbx_name.Text = "";
            listbox.Items.Remove(listbox.SelectedItem);
        }

        private void Save_Button(object sender, RoutedEventArgs e)
        {
            items_today = Model.collection.Where(x => x.Date == datepicker.SelectedDate.Value).ToList();
            foreach (var item in items_today)
            {
                Model.collection = Model.collection.Where(x => x.Description != item.Description).ToList();
                Model model = new Model(tbx_name.Text, tbx_description.Text, datepicker.SelectedDate.Value);
                Model.collection.Add(model);
                De_serilization.Serialization(Model.collection);
                Model.collection = De_serilization.Deserialize<List<Model>>();
            }
            listbox.Items.Clear();
            update_tbx();
        }
    }
}
