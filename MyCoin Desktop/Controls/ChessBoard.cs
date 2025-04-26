using MyCoin_Desktop.Util;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Controls
{
    public sealed class ChessBoard : Control
    {

        #region States
        private const string STATE_SELECTED = "Selected";
        private const string STATE_NO_SELECTED = "NoSelected";
        #endregion

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

        private void ChessBoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is ChessBoardButton chessBoardButton)) return;

            (int line, int column) = GameBoardUtil.GetLineAndColumn(chessBoardButton.Tag.ToString());

            SelectButtonClicked(chessBoardButton, line, column);
        }

        private void SelectButtonClicked(ChessBoardButton chessBoardButton, int line, int column)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == line && j == column)
                        continue;

                    if (GetTemplateChild($"ChessButton{i}{j}") is ChessBoardButton button && button.GetPiece() != null)
                        VisualStateManager.GoToState(button, STATE_NO_SELECTED, false);
                }
            }

            if (chessBoardButton.GetPiece() != null)
            {
                VisualStateManager.GoToState(chessBoardButton, STATE_SELECTED, false);
            }
        }
    }
}
