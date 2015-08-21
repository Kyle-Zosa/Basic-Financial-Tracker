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
using System.Data.SQLite;

namespace Basic_Financial_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private Controller controller;
        private Model model;

        public string popupReturnValue;
        public MainView()
        {
            InitializeComponent();
            this.model = new Model();
            this.controller = new Controller(this, this.model);
        }
        #region Button Click Events
        private void aButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void bButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void cButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void originalBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            Popup editOriginalBalance = new Popup("Edit Original Balance", "New Original Balance:", "Original Balance");
            editOriginalBalance.ShowDialog();
            this.controller.updateView();
        }
        #endregion
    }
}
