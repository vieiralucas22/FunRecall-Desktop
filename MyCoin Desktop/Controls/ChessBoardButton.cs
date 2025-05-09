﻿using MyCoin_Desktop.Common;
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
            set => SetValue(ImageSourceProperty, value);
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

        private Piece _buttonPiece;

        public Piece ButtonPiece
        {
            get { return _buttonPiece; }
            set { _buttonPiece = value; }
        }

        public ChessBoardButton()
        {
            DefaultStyleKey = typeof(ChessBoardButton);
            Loaded += ChessBoardButton_Loaded;
        }

        private void ChessBoardButton_Loaded(object sender, RoutedEventArgs e)
        {
            CreatePiece();
        }

        public void CreatePiece()
        {
            var piece = Path.GetFileNameWithoutExtension(ImagePath);

            if (!string.IsNullOrEmpty(piece))
            {
                string[] result = Regex.Split(piece, @"(?=[A-Z])");

                ChessPiecesColors pieceColor = result[2].Equals(ChessPiecesColors.WHITE.GetDescription()) ? ChessPiecesColors.WHITE : ChessPiecesColors.BLACK;
                
                switch (result[1])
                {
                    case GameConstants.PAWN:
                        ButtonPiece = ButtonPiece ?? new Pawn(pieceColor);
                        break;

                    case GameConstants.ROOK:
                        ButtonPiece = ButtonPiece ?? new Rook(pieceColor);
                        break;

                    case GameConstants.KNIGHT:
                        ButtonPiece = ButtonPiece ?? new Knight(pieceColor);
                        break;

                    case GameConstants.BISHOP:
                        ButtonPiece = ButtonPiece ?? new Bishop(pieceColor);
                        break;

                    case GameConstants.QUEEN:
                        ButtonPiece = ButtonPiece ?? new Queen(pieceColor);
                        break;

                    case GameConstants.KING:
                        ButtonPiece = ButtonPiece ?? new King(pieceColor);
                        break;
                }
            }

        }

        public void ResetButton() {
            ImageSource = null;
            ImagePath = null;
            ButtonPiece = null;
        }
    }
}
