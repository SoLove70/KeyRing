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
	public partial class RandomQuestion : ContentPage
	{
        public int PID;
        Question randomq = new Question();
        public RandomQuestion (int p_id)
		{
			InitializeComponent ();
            PID = p_id;
            Init();
		}

        private void Init()
        {
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Constants.BackgroundColor;
            
            NavigationPage.SetHasBackButton(this, false);
            BackgroundColor = Constants.BackgroundColor;
            RandQuestion.TextColor = Constants.MainTextColor;
            RandQuestion.FontSize = 20;

            Icon.HeightRequest = Constants.IconHeight;
            //App.StartCheckIfInternet(lbl_NoInternet, this);

            RandQuestion.Text = GetRandomQuestion().Text;

            
        }

        public Question GetRandomQuestion ()
        {
            var QuestionList = new List<Question>()
            {
                new Question() { Id = 1, Text = "Favourite colour", AnswerId = 1 },
                new Question() { Id = 2, Text = "Favourite movie", AnswerId = 2 },
                new Question() { Id = 3, Text = "Middle childs name", AnswerId = 3 },
                new Question() { Id = 4, Text = "Favourite boardgame", AnswerId = 4 },
                new Question() { Id = 5, Text = "Relaxing Place", AnswerId = 5 }
            };

            
            Random rnd = new Random();
            int qamount = QuestionList.Count;
            int qnumber = rnd.Next(0, qamount); // creates a number between 0 and the amount of questions

            randomq = QuestionList[qnumber];

            return randomq;
        }

        private void Btn_SubmitAnswer_Clicked(object sender, EventArgs e)
        {
            string q_Answer = Q_Answer.Text.ToUpper();

            string storedAnswer = GetAnswer(randomq.AnswerId);

            if(q_Answer == storedAnswer)
            {
                Navigation.PushAsync(new PasswordPage(PID));
            }
            else
            {
                RandQuestion.Text = GetRandomQuestion().Text;
            }

        }

        private string GetAnswer(int id)
        {
            var AnswerList = new List<Answer>()
            {
                new Answer() {Id = 1, Text = "PURPLE"},
                new Answer() {Id = 2, Text = "CHASING AMY"},
                new Answer() {Id = 3, Text = "ANDREW"},
                new Answer() {Id = 4, Text = "POWER GRID"},
                new Answer() {Id = 5, Text = "FOUNTAIN"},

            };

            Answer answer = AnswerList.Find(x => x.Id == id);
            string q_answer = answer.Text;
            return q_answer;
        }
    }
}