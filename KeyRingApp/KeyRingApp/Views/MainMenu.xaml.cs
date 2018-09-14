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

            

            //Icon.HeightRequest = Constants.IconHeight;
            //App.StartCheckIfInternet(lbl_NoInternet, this);

            RequestList.ItemsSource = new List<Request>()
            
            {
                new Request() { Id = 1, Name = "Barclays PIN", PasswordId="1" },
                new Request() { Id = 2, Name = "Work PC", PasswordId="2" },
                new Request() { Id = 3, Name = "Facebook", PasswordId="3" },
                new Request() { Id = 4, Name = "Online Banking", PasswordId="4" },
                new Request() { Id = 5, Name = "Security Door", PasswordId="5" },
                new Request() { Id = 6, Name = "Catalogue", PasswordId="6" },
                new Request() { Id = 7, Name = "Laptop", PasswordId="7" }
            };
        }

        //private void RequestList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    //var button = (Button)sender;
        //    //string wanted = button.Text;
        //    var wanted = (sender as ListView).SelectedItem as Request;
        //    Navigation.PushAsync(new RandomQuestion(wanted));
        //}

        private void Btn_GetPassword_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var R_List = new List<Request>()
            {
                new Request() { Id = 1, Name = "Barclays PIN", PasswordId="1" },
                new Request() { Id = 2, Name = "Work PC", PasswordId="2" },
                new Request() { Id = 3, Name = "Facebook", PasswordId="3" },
                new Request() { Id = 4, Name = "Online Banking", PasswordId="4" },
                new Request() { Id = 5, Name = "Security Door", PasswordId="5" },
                new Request() { Id = 6, Name = "Catalogue", PasswordId="6" },
                new Request() { Id = 7, Name = "Laptop", PasswordId="7" }
            };

            
            var button = (Button)sender;
            string wanted = button.Text;
            var rqst = R_List.Find(x => x.Name == button.Text);
            int p_id = Convert.ToInt32(rqst.PasswordId); 


            Navigation.PushAsync(new RandomQuestion(p_id));
        }


    }
}