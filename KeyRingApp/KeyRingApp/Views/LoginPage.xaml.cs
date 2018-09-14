using KeyRingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyRingApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            Init();
		}

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Username.FontSize = 20;
            Lbl_Password.FontSize = 20;
            Lbl_Password.TextColor = Constants.MainTextColor;
            Entry_Username.TextColor = Constants.MainTextColor;
            Entry_Password.TextColor = Constants.MainTextColor;
            //Btn_SignIn.BackgroundColor = Constants.ButtonColor;
            //Btn_SignIn.TextColor = Constants.ButtonTextColor;


            Icon.HeightRequest = Constants.LoginIconHeight;
            //App.StartCheckIfInternet(lbl_NoInternet, this);
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            //Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
            Entry_Password.Completed += (s, e) => Btn_SignIn.Focus();

        }

        private void Btn_SignIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu());
        }
    }
}