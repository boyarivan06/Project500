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
    /// Логика взаимодействия для WindowWithQuestionsByNumber.xaml
    /// </summary>
    public partial class WindowWithQuestionsByNumber : Window
    {
        public Dictionary<Question, TextBox> answers = new Dictionary<Question, TextBox>();
        
        int sum = 0;
        public WindowWithQuestionsByNumber()
        {
            InitializeComponent();
        }
        public void end_button_Click(object sender, RoutedEventArgs e)
        {


            foreach (Question question in answers.Keys)
            {
                if (answers[question].Text == question.answer)
                {
                    sum += question.mark;
                }
            }

            main_list.Items.RemoveAt(main_list.Items.Count-1);
            main_list.Items.Add(new Label { Content = $"Сумма баллов: {sum}" });
        }
    }
}
