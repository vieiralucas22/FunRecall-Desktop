using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace MyCoin_Desktop.Controls
{
    public sealed class ChessBoardButton : Button
    {

        #region Dependency properties

        public string ImagePath
        {
            get => (string)GetValue(ImagePathProperty);
            set => SetValue(ImagePathProperty, value);
        }

        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(nameof(ImagePath), typeof(ChessBoardButton), typeof(Image),
                new PropertyMetadata("", OnImagePathChanged));

        public BitmapImage ImageSource
        {
            get => (BitmapImage)GetValue(ImageSourceProperty);
            private set => SetValue(ImageSourceProperty, value);
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(nameof(ImageSource), typeof(BitmapImage), typeof(ChessBoardButton),new PropertyMetadata(null));

        private static void OnImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ChessBoardButton button && e.NewValue is string path && !string.IsNullOrWhiteSpace(path))
            {
                button.ImageSource = new BitmapImage(new Uri(path));
            }
        }


        #endregion

        public ChessBoardButton()
        {
            DefaultStyleKey = typeof(ChessBoardButton);
        }
    }
}
