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
    /// Логика взаимодействия для TestRunWindow.xaml
    /// </summary>
    public partial class TestRunWindow : Window
    {
        Variant my_Variant = new Variant();
        public TestRunWindow(Variant variant)
        {
            my_Variant = variant;
            
            InitializeComponent();
        }

        private void TestRunWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            int n = 1;
            foreach (Question question in my_Variant.questions)
            {
                test_tabs.Items[n] = new TestQuestionInterface(question);
                n++;
            }
        }
    }
}
