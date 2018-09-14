using KeyRingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyRingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PasswordPage : ContentPage
	{
        public PasswordPage (int a_id)
		{
			InitializeComponent ();
            Init(a_id);
            
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(10000);
            for (var counter = 1; counter < 2; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            }

            await Navigation.PopAsync();
            
        }

        private void ClosePage()
        {
            Thread.Sleep(10000);
            
        }

        private void Init(int a_id)
        {

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Constants.BackgroundColor;

            NavigationPage.SetHasBackButton(this, false);
            BackgroundColor = Constants.BackgroundColor;

            
            

            Icon.HeightRequest = Constants.IconHeight;
            //App.StartCheckIfInternet(lbl_NoInternet, this);

            

            lbl_Password.Text = GetPassword(a_id);
            


        }

        private string GetPassword(int a_id)
        {
            var PasswordList = new List<Password>()
            {
                new Password() {Id = 1, Text = "1234"},
                new Password() {Id = 2, Text = "Password1234567"},
                new Password() {Id = 3, Text = "5up3rc1@l"},
                new Password() {Id = 4, Text = "88595"},
                new Password() {Id = 5, Text = "90134"},
                new Password() {Id = 6, Text = "Password6"},
                new Password() {Id = 7, Text = "Password7"},

            };

            Password pword = PasswordList.Find(x => x.Id == a_id);
            int fontMod = 0;
            int dyn_FontSize = 0;

            if (pword.Text.Length < 8)
            {
                dyn_FontSize = 90 - pword.Text.Length;
            }
            else if ((pword.Text.Length >= 8) && (pword.Text.Length <= 12))
            {
                dyn_FontSize = 65 - pword.Text.Length;
            }
            else if(pword.Text.Length > 12)
            {
                dyn_FontSize = 55 - pword.Text.Length;
            }
            
            lbl_Password.FontSize = dyn_FontSize;
            return pword.Text;
        }

        
    }
}