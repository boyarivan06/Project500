using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Project500
{
    /// <summary>
    /// Логика взаимодействия для _13_2_QuestionInterface.xaml
    /// </summary>
    public partial class _13_2_QuestionInterface : UserControl
    {
        Question self_Question = new Question();
        public _13_2_QuestionInterface(Question question)
        {
            self_Question = question;
            task_name.Content = question.number.ToString();
            task_image.Source = new BitmapImage(new Uri($"db/{question.file_source}"));
            task_text.Content = question.text;
            InitializeComponent();
        }

        private void doc_source_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);

                self_Question.user_answer = uri.ToString();

            }
        }
    }
}
