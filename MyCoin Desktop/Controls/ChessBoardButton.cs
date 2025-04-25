using MyCoin_Desktop.Common;
using MyCoin_Desktop.Common.Enums;
using MyCoin_Desktop.Entities;
using MyCoin_Desktop.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
            DependencyProperty.Register(nameof(ImageSource), typeof(BitmapImage), typeof(ChessBoardButton), new PropertyMetadata(null));

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

        public Piece GetPiece()
        {
            var piece = Path.GetFileNameWithoutExtension(ImagePath);
            Piece chessPiece = null;

            if (!string.IsNullOrEmpty(piece))
            {
                string[] result = Regex.Split(piece, @"(?=[A-Z])");

                ChessPiecesColors pieceColor = result[2].Equals(ChessPiecesColors.WHITE.GetDescription()) ? ChessPiecesColors.WHITE : ChessPiecesColors.BLACK;
                
                switch (result[1])
                {
                    case GameConstants.PAWN:
                        chessPiece = new Pawn(pieceColor);
                        break;

                    case GameConstants.ROOK:
                        chessPiece = new Rook(pieceColor);
                        break;

                    case GameConstants.KNIGHT:
                        chessPiece = new Knight(pieceColor);
                        break;

                    case GameConstants.BISHOP:
                        chessPiece = new Bishop(pieceColor);
                        break;

                    case GameConstants.QUEEN:
                        chessPiece = new Queen(pieceColor);
                        break;

                    case GameConstants.KING:
                        chessPiece = new King(pieceColor);
                        break;
                }
            }

            return chessPiece;
        }
    }
}
