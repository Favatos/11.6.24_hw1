using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace _11._6._24_hw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer;
        public MainWindow()
        {
            InitializeComponent();

            slider.Value = 0.5;
            player.Volume = slider.Value;

            textBlock.Text = Path.GetFileName(player.Source.ToString());
        }

        private void ButtonPlay_Pause_Click(object sender, RoutedEventArgs e)
        {
            if((string)buttonPlay.Content == "Play")
            {
                player.Play();
                buttonPlay.Content = "Pause";
            }
            else
            {
                player.Pause();
                buttonPlay.Content = "Play";
            }
        }

        private void volume_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(popup.IsOpen) 
                player.Volume = slider.Value;
        }

        private void player_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Не удаётся воспроизвести файл. Попробуйте ввести другой путь");
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(fullScreen.Header) == "Fullscreen")
            {
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                fullScreen.Header = "exit fullscreen";
            }
            else
            {
                fullScreen.Header = "Fullscreen";
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
            }
           
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "media element| *.mp4";
            openFileDialog.ShowDialog();
            player.Source = new Uri(openFileDialog.FileName);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            player.Source = null;
            textBlock.Text = null;
        }

        private void player_MediaOpened(object sender, RoutedEventArgs e)
        {
            textBlock.Text = Path.GetFileName(player.Source.ToString());
        }
    }
}