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

namespace Project500
{
    /// <summary>
    /// Логика взаимодействия для DialogAcceptWindow.xaml
    /// </summary>
    public partial class DialogAcceptWindow : Window
    {
        public DialogAcceptWindow()
        {
            InitializeComponent();
        }

        private void Acceptbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Unacceptbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Closing += (s, e2) => { var w2 = new DialogAcceptWindow(); w2.Show(); };
            this.Close();
        }
    }
}
