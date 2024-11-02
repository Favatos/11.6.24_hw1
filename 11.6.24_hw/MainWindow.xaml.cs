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
using System.Windows.Shapes;

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (File.Exists(textBox.Text)) player.Source = new Uri(textBox.Text);
        }

        private void player_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Не удаётся воспроизвести файл. Попробуйте ввести другой путь");
        }
    }
}