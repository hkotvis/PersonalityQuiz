//using PersonalityQuiz.ViewModels;
using PersonalityQuiz.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace PersonalityQuiz
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

        }
    }
}
//public partial class MainPage : ContentPage
//    {
//        QuizViewModel _viewModel;//
        
//        public MainPage()
//        {
//            InitializeComponent();
//            _viewModel = new QuizViewModel();//
//            BindingContext = _viewModel;//
//        }
//        private void goToResults(object sender, EventArgs e)
//        {
//            Navigation.PushAsync(new Results());
//        }
//    }
//}
