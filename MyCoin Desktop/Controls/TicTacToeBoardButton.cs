using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MyCoin_Desktop.Controls
{
    public sealed class TicTacToeBoardButton : Button
    {

        private Image _image;
        public TicTacToeBoardButton()
        {
            DefaultStyleKey = typeof(TicTacToeBoardButton);

        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate(); 

            _image = GetTemplateChild("XorOImage") as Image;
        }

        public void SetBackgroundImageButton(BitmapImage source)
        {
            _image.Source = source;
            _image.Visibility = Visibility.Visible;
        }
    }
}
