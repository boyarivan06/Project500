using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public List<Variant> Variants = new List<Variant>();

        public MainWindow()
        {
            InitializeComponent();
            /*var w = new TestRunWindow(new Variant {number=0, questions = JsonSerializer.Deserialize<List<List<Question>>>(File.ReadAllText("db/variants"))[0]});
            w.Show();*/

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var FirstDialog = new Register();
            FirstDialog.Owner = this;
            //FirstDialog.Closing += FirstDialog_Closing;
            FirstDialog.ShowDialog();

            var subVariants = JsonSerializer.Deserialize<List<List<Question>>>(File.ReadAllText("db/variants"));

            int n = 1;
            foreach (var variant in subVariants)
            {
                var var_now = new Variant { number = n, questions = variant };
                Variants.Add(var_now);
                //var tI = new TabItem { Content = $"Вариант {n}" };
                var bt_var = new Button { Content = $"Вариант {n}" };

                bt_var.Click += (s, e1) => { var test = new TestRunWindow(var_now); test.Show(); };
                PreparedVariantsTab.Items.Add(bt_var);
                n++;
            }
                
                
        }

        public void ClosingAll()
        {
            this.Close();
        }

        private void FirstDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var FirstDialog = new Register();
            FirstDialog.Closing += FirstDialog_Closing;
            FirstDialog.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(1);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(2);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(3);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(4);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(5);
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(6);
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(7);
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(8);
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(9);
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(10);
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(11);
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(12);
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(13);
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(14);
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            GetQuestionByNumber(15);
        }

        private void NewWindowWithQuestionsByNumber(List<Question> questions, int n)
        {
            var w = new WindowWithQuestionsByNumber();
            w.Title = $"Задание {n}";
            foreach (Question question in questions) w.main_list.Items.Add(new TestQuestionInterface(question));
            
            w.Show();

        }

        /*private void NewWindowWithQuestionsByNumber(List<Question> questions)
        {
            var w = new WindowWithQuestionsByNumber();
            foreach (Question question in questions) w.main_list.Items.Add(new TestQuestionInterface(question));
            
            w.Show();

        }*/

        private void GetQuestionByNumber(int n)
        {
            var ret = new List<Question>();
            foreach (List<Question> variant_list in JsonSerializer.Deserialize<List<List<Question>>>(File.ReadAllText("db/variants")))
            {
                foreach (Question question in variant_list)
                {
                    if (question.number == n)
                    {
                        ret.Add(question);
                    }
                }
            }
            NewWindowWithQuestionsByNumber(ret, n);
        }

        /*private void GetQuestionByNumber(int n, int mode)
        {
            var ret = new List<Question>();
            foreach (List<Question> variant_list in JsonSerializer.Deserialize<List<List<Question>>>(File.ReadAllText("db/variants")))
            {
                foreach (Question question in variant_list)
                {
                    if (question.number == n)
                    {
                        ret.Add(question);
                    }
                }
            }
            NewWindowWithQuestionsByNumber2(ret);
        }*/

        /*private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Variants = JsonSerializer.Deserialize<List<List<Question>>>(File.ReadAllText("db/variants"));
            foreach (var Variant in Variants)
                PreparedVariantsTab.Items.Add(Variant);
        }*/
    }
    public class Question
    {

        public int number { get; set; }
        public string text { get; set; }
        public string file_source { get; set; }
        public string answer { get; set; }
        public string user_answer { get; set; }
        public int score { get; set; }
    }

    public class Variant
    {
        public int number { get; set; }
        public List<Question>questions { get; set; }
    }

    
}
