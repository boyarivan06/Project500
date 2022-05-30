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
            InitializeComponent();
            my_Variant = variant;
            int n = 0;
            foreach (Question question in my_Variant.questions)
            {
                var t = new TabItem();
                t.Content = new TestQuestionInterface(question);
                t.Header = question.number.ToString();
                
                n++;
                if (n >= 12) break;
            }
        }

        private void TestRunWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
