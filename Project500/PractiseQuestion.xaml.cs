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

namespace Project500
{
    /// <summary>
    /// Логика взаимодействия для PractiseQuestion.xaml
    /// </summary>
    public partial class PractiseQuestion : UserControl
    {
        public PractiseQuestion()
        {
            InitializeComponent();
        }
    }
}
/*OpenFileDialog openFileDialog = new OpenFileDialog();
if (openFileDialog.ShowDialog() == true)
{
Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
    ImageSource imgSource = new BitmapImage(uri);
        Avatar.Source = imgSource;

}*/