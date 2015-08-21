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

namespace Basic_Financial_Tracker
{
    public partial class Popup : Window
    {
        public string returnString;
        public Popup(string title, string label, string textbox)
        {
            InitializeComponent();
            PopupWindow.Title = title;
            popupLabel.Content = label;
            popupTextBox.Text = textbox;
        }
    }
}
