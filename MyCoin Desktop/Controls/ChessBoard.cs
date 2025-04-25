using MyCoin_Desktop.Util;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Controls
{
    public sealed class ChessBoard : Control
    {
        public ChessBoard()
        {
            DefaultStyleKey = typeof(ChessBoard);
        }

        protected override void OnApplyTemplate() { 
            for (int line = 0; line < 8; line++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (GetTemplateChild($"ChessButton{line}{column}") is ChessBoardButton chessBoardButton)
                        chessBoardButton.Click += ChessBoardButton_Click;
                }
            }
        }

        private void ChessBoardButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (!(sender is ChessBoardButton chessBoardButton)) return;

            (int line, int column) = GameBoardUtil.GetLineAndColumn(chessBoardButton.Tag.ToString());

            Debug.WriteLine(chessBoardButton.GetPiece()?.PieceType.ToString());
        }
    }
}
