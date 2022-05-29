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
                Variants.Add(new Variant { Number = n, questions = variant });
                //var tI = new TabItem { Content = $"Вариант {n}" };
                var bt_var = new Button { Content = $"Вариант {n}" };
                
                bt_var.Click += (s, e1) => { var test = new TestRunWindow(Variants[n]); test.Show(); };
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
    }

    public class Variant
    {
        public int Number { get; set; }
        public List<Question>questions { get; set; }
    }
}
