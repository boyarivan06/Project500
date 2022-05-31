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
    /// Логика взаимодействия для MusicPlayer.xaml
    /// </summary>
    public partial class MusicPlayer : UserControl
    {
        bool stop = false;
        public MusicPlayer()
        {
            InitializeComponent();
        }

        MediaPlayer player = new MediaPlayer();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

                label_name.Content = openFileDialog.FileName;
                Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
                player.Open(uri);
                //music_slider.Maximum = Convert.ToDouble(player.NaturalDuration);
                volume_slider.Value= player.Volume;
                music_slider.Minimum = 0;
            }
            else
            {
                label_name.Content = "FALSE??";
            }

        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
            music_slider.IsEnabled = true;
        }

        private void PauseUnPause_Click(object sender, RoutedEventArgs e)
        {
            if (!stop)
            {
                player.Pause();
                stop= true;
                PauseUnPause.Content = "Продолжить";
            }
            else
            {
                player.Play();
                stop= false;
                PauseUnPause.Content = "Пауза";
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            music_slider.IsEnabled = false;
            player.Stop();
            label_name.Content = "Файл не выбран";
        }

        private void music_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Position = new TimeSpan((long)music_slider.Value);
        }

        private void volume_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = (double)volume_slider.Value;
        }
    }
}
