using PersonalityQuiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalityQuiz
{
	public partial class Results : ContentPage
	{
       QuizViewModel _viewModel;
        public Results ()
		{
			InitializeComponent();

        }
        void calc(object sender, EventArgs e)
        {
          _viewModel = new QuizViewModel();
         // character.Text = _viewModel.Calculate();
        }
    }
}