using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace StackOverfortress
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ItemModelManaged();
        }

        /// <summary>
        /// HatShot
        /// <see cref="http://stackoverflow.com/questions/24466482/how-to-take-a-screenshot-of-a-wpf-control"/>
        /// <seealso cref="http://stackoverflow.com/a/24478299/1506454"/>
        /// </summary>
        private void HatshotClick(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.FileName = (DataContext as ItemModelManaged).Item.Name;
            sfd.Filter = "Image|*.png";
            if (sfd.ShowDialog() != true)
                return;

            var renderer = new RenderTargetBitmap((int)ItemCard.RenderSize.Width, (int)ItemCard.RenderSize.Height, 96, 96, PixelFormats.Pbgra32);
            
            renderer.Render(ItemCard);

            var pngImage = new PngBitmapEncoder();
            
            pngImage.Frames.Add(BitmapFrame.Create(renderer));

            using (Stream fileStream = File.Create(sfd.FileName))
            {
                pngImage.Save(fileStream);                
            }

            Process.Start(sfd.FileName);
        }
    }
}
