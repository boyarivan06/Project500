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
        public int sum = 0;
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
                test_tabs.Items.Add(t);
                n++;
                if (n >= 12) break;
            }
        }

        private void TestRunWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void end_button_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabItem in test_tabs.Items)
            {
                TestQuestionInterface questionInterface = tabItem.Content as TestQuestionInterface;
                Question question = questionInterface.self_question;
                if (questionInterface.answer_input.Text == question.answer)
                    sum += question.mark;
            }
            end_button.Content = sum.ToString();
            end_button.IsEnabled = false;
        }
    }
}
