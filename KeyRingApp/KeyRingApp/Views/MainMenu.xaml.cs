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
	public partial class MainMenu : ContentPage
	{
		public MainMenu ()
		{
			InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Constants.BackgroundColor;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Constants.MainTextColor;
            Init();
		}

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            RequestList.BackgroundColor = Constants.BackgroundColor;
            RequestList.SeparatorColor = Constants.BackgroundColor;

            NavigationPage.SetHasBackButton(this, false);

            

            Icon.HeightRequest = Constants.IconHeight;
            //App.StartCheckIfInternet(lbl_NoInternet, this);

            RequestList.ItemsSource = new List<Request>()
            {
                new Request() { Id = 1, Name = "Barclays PIN" },
                new Request() { Id = 2, Name = "Work PC" },
                new Request() { Id = 3, Name = "Facebook" },
                new Request() { Id = 4, Name = "Online Banking" },
                new Request() { Id = 5, Name = "Security Door" },
                new Request() { Id = 6, Name = "Catalogue" },
                new Request() { Id = 7, Name = "Laptop" }
            };
        }

        private void Btn_GetPassword_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string wanted = button.Text;
            Navigation.PushAsync(new RandomQuestion(wanted));
        }
    }
}