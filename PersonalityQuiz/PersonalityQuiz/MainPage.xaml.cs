//using PersonalityQuiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PersonalityQuiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           // BindingContext = new QuizViewModel();
        }
        private async void goToResults(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Results());
        }
    }
}
