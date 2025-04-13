using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Controls
{
    public sealed class PlayerCardInfo : Control
    {
        #region Properties

        private TextBlock _playerName;
        public TextBlock PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        private Image _playerRepresentation;
        public Image PlayerRepresentation
        {
            get { return _playerRepresentation; }
            set { _playerRepresentation = value; }
        }

        #endregion

        public PlayerCardInfo()
        {
            DefaultStyleKey = typeof(PlayerCardInfo);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _playerName = GetTemplateChild("PlayerName") as TextBlock;
            _playerRepresentation = GetTemplateChild("PlayerRepresentation") as Image;
        }
    }
}
