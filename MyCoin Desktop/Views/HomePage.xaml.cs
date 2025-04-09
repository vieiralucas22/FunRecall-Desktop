using MyCoin_Desktop.Common;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls;
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;
using NavigationViewSelectionChangedEventArgs = Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs;
using NavigationViewItem = Microsoft.UI.Xaml.Controls.NavigationViewItem;


namespace MyCoin_Desktop.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            contentFrame.Navigate(typeof(TicTacToeMatchPage));
        }

        public void NvSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem item)
            {
                switch (item.Tag)
                {
                    case PageTokens.TIC_TAC_TOE_PAGE:
                        contentFrame.Navigate(typeof(TicTacToePage));
                        break;
                    case PageTokens.HANGMAN_PAGE:
                      //  contentFrame.Navigate(typeof(SamplePage2));
                        break;

                    case PageTokens.CHECKERS:
                       // contentFrame.Navigate(typeof(SamplePage2));
                        break;

                    case PageTokens.WHAT_IS_MY_NUMBER:
                       // contentFrame.Navigate(typeof(SamplePage2));
                        break;
                }
            }
        }
    }
}
