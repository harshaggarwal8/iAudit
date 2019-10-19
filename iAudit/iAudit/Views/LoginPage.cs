using Xamarin.Forms;

namespace iAudit.Views
{
    internal class LoginPage : Page
    {
        private UserViewModel userViewModel;

        public LoginPage(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
        }
    }
}