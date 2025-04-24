using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Controls
{
    public sealed class ChessBoard : Control
    {
        ChessBoardButton bt;
        public ChessBoard()
        {
            DefaultStyleKey = typeof(ChessBoard);
        }

        protected override void OnApplyTemplate() { 
        }
    }
}
