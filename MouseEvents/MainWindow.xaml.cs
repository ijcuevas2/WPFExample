using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MouseEvents
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Register navigation events
            NavigationService ns = NavigationService.GetNavigationService(this);
            if (ns != null)
            {
                ns.Navigating += NavigationService_Navigating;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string buttonPressed = e.ChangedButton switch
            {
                MouseButton.Left => "Left Button",
                MouseButton.Right => "Right Button",
                MouseButton.Middle => "Middle Button",
                MouseButton.XButton1 => "XButton1 (Back)",
                MouseButton.XButton2 => "XButton2 (Forward)",
                _ => $"Other Button ({e.ChangedButton})"
            };

            txtButtonPressed.Text = $"Button Pressed: {buttonPressed}";
            txtClickType.Text = $"Click Type: {(e.ClickCount == 2 ? "Double Click" : "Single Click")}";
            txtClickCount.Text = $"Click Count: {e.ClickCount}";

            // Handle browser navigation buttons
            if (e.ChangedButton == MouseButton.XButton1)
            {
                txtNavigationButton.Text = "Browser Navigation: Back Button";
                HandleBackNavigation();
                e.Handled = true;
            }
            else if (e.ChangedButton == MouseButton.XButton2)
            {
                txtNavigationButton.Text = "Browser Navigation: Forward Button";
                HandleForwardNavigation();
                e.Handled = true;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.XButton1)
            {
                txtNavigationButton.Text = "Browser Navigation: Back Button";
                HandleBackNavigation();
                e.Handled = true;
            }
            else if (e.ChangedButton == MouseButton.XButton2)
            {
                txtNavigationButton.Text = "Browser Navigation: Forward Button";
                HandleForwardNavigation();
                e.Handled = true;
            }
        }

        private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                txtNavigationButton.Text = "Browser Navigation: System Back Detected";
            }
            else if (e.NavigationMode == NavigationMode.Forward)
            {
                txtNavigationButton.Text = "Browser Navigation: System Forward Detected";
            }
        }

        private void HandleBackNavigation()
        {
            // Add your back navigation logic here
            MessageBox.Show("Back Navigation Detected");
        }

        private void HandleForwardNavigation()
        {
            // Add your forward navigation logic here
            MessageBox.Show("Forward Navigation Detected");
        }
    }
}
