using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;

namespace PersonalityQuiz.ViewModels
{
    public class QuizViewModel : INotifyPropertyChanged
    {
            public string name;
            public int age;

            public bool questionVisible = true;
            public bool resultsVisible = false;

            public string characterName = "Error";

            public int count = 0;
            public int baCount = 0;
            public int crCount = 0;
            public int csCount = 0;
            public int iwaCount = 0;
            public int question = 0;

            public string[] character = { "Barry Allen aka THE FLASH", "Cisco Ramon aka VIBE", "Caitlyn Snow aka KILLER FROST", "Iris West-Allen" };
            public string[] questions = { "1) Which metahuman super power would you want to have the most?",
            "2) If you couldn't be out fighting crime, what would you be doing?",
            "3) If a stranger was in trouble, what would be your first reaction?",
            "4) In a superhero team, who are you?",
            "5) What is your favorite color?" };

        public string[] baAnswers = { "superspeed", "law enforcement", "help them", "the leader", "red" };
        public string[] crAnswers = { "telekinesis", "engineer", "think it through", "the weapon specialist", "black" };
        public string[] csAnswers = { "weather manipulation", "scientist", "make a plan", "the brains", "blue" };
        public string[] iwaAnswers = { "flight", "journalist", "call the police", "the lookout", "yellow" };

        public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public QuizViewModel()
            {
                
                BACommand = new Command(() =>
                {
                    if (question < 4)
                    {
                        question++;
                        baCount++;
                      //  question++;
                        OnPropertyChanged("LabelText");
                        OnPropertyChanged("BAAns");
                        OnPropertyChanged("CSAns");
                        OnPropertyChanged("CRAns");
                        OnPropertyChanged("IWAAns");
                       
                    }
                    else
                    {
                        questionVisible = false;
                        resultsVisible = true;
                        OnPropertyChanged("QuestionVisible");
                        OnPropertyChanged("ResultsVisible");
                        OnPropertyChanged("CharacterName");
                    }
                });
                CRCommand = new Command(() =>
                {
                    if (question < 4)
                    {
                        question++;
                        crCount++;
                       // question++;
                        OnPropertyChanged("LabelText");
                        OnPropertyChanged("BAAns");
                        OnPropertyChanged("CSAns");
                        OnPropertyChanged("CRAns");
                        OnPropertyChanged("IWAAns");
                        
                    }
                    else
                    {
                        questionVisible = false;
                        resultsVisible = true;
                        OnPropertyChanged("QuestionVisible");
                        OnPropertyChanged("ResultsVisible");
                        OnPropertyChanged("CharacterName");
                    }
                });
                CSCommand = new Command(() =>
                {
                    if (question < 4)
                    {
                        question++;
                        csCount++;
                        //question++;
                        OnPropertyChanged("LabelText");
                        OnPropertyChanged("BAAns");
                        OnPropertyChanged("CSAns");
                        OnPropertyChanged("CRAns");
                        OnPropertyChanged("IWAAns");
                        
                    }
                    else
                    {
                        questionVisible = false;
                        resultsVisible = true;
                        OnPropertyChanged("QuestionVisible");
                        OnPropertyChanged("ResultsVisible");
                        OnPropertyChanged("CharacterName");
                    }
                });
                IWACommand = new Command(() =>
                {
                    if (question < 4)
                    {
                        question++;
                        iwaCount++;
                        OnPropertyChanged("LabelText");
                        OnPropertyChanged("BAAns");
                        OnPropertyChanged("CSAns");
                        OnPropertyChanged("CRAns");
                        OnPropertyChanged("IWAAns");
                        
                    }
                    else
                    {
                        questionVisible = false;
                        resultsVisible = true;
                        OnPropertyChanged("QuestionVisible");
                        OnPropertyChanged("ResultsVisible");
                        OnPropertyChanged("CharacterName");
                    }
                });
                ResultsBtnCommand = new Command(() =>
                    {
                        count = 0;
                        baCount = 0;
                        csCount = 0;
                        crCount = 0;
                        iwaCount = 0;
                        question = 0;
                        questionVisible = true;
                        resultsVisible = false;
                        
                        OnPropertyChanged("QuestionVisible");
                        OnPropertyChanged("ResultsVisible");
                    });
            }

            public bool QuestionVisible { get { return questionVisible; } }
            public bool ResultsVisible { get { return resultsVisible; } }
            public string LabelText { get { return questions[question]; } }
            public string BAAns { get { return baAnswers[question]; } }
            public string CRAns { get { return crAnswers[question]; } }
            public string CSAns { get { return csAnswers[question]; } }
            public string IWAAns { get { return iwaAnswers[question]; } }
        //public string Photo
        //{
        //    get
        //    {
        //        var character = CharacterName;
        //        if (character == this.character[0]) return "https://i.pinimg.com/originals/76/fc/50/76fc50eea0e8fd6c5a9cda7ad64905b9.jpg";
        //        else if (character == this.character[1]) return "https://i.pinimg.com/originals/9e/82/47/9e8247eb9dbfbfc691017b95524fc978.jpg";
        //        else if (character == this.character[2]) return "https://i.pinimg.com/originals/b6/6c/2c/b66c2c7a43d0b0acdc794917dfe50f2d.jpg";
        //        else if (character == this.character[3]) return "https://i.pinimg.com/474x/df/cb/a7/dfcba74a55283ab0faf1548e8814a8b8--flash-tv-the-flash.jpg";
        //        else return "";
        //    }
        //}
        public string CharacterName {
            get {
                var charPhoto = "";
                if (baCount > crCount && baCount > iwaCount && baCount > csCount) { count = 0; charPhoto = "https://i.pinimg.com/originals/c8/98/1a/c8981a0a8bf8a4bd46614a99124c7fd7.jpg"; }
                else if (crCount > baCount && crCount > iwaCount && crCount > csCount) { count = 1; charPhoto = "https://i.pinimg.com/originals/3c/1c/d6/3c1cd6049f92e6a9ccb604871e335a60.jpg"; }
                else if (csCount > baCount && csCount > iwaCount && csCount > crCount) { count = 2; charPhoto = "https://i.pinimg.com/originals/b6/6c/2c/b66c2c7a43d0b0acdc794917dfe50f2d.jpg"; }
                else if (iwaCount > baCount && iwaCount > crCount && iwaCount > crCount){ count = 3; charPhoto = "https://i.pinimg.com/originals/35/d8/b5/35d8b598dc74a900ee29074b6ef8ea5e.jpg"; }
                else { charPhoto = "https://i.pinimg.com/originals/3c/1c/d6/3c1cd6049f92e6a9ccb604871e335a60.jpg"; }
                return charPhoto;
                    //return character[count];
                }
            }
     

            public ICommand BACommand { get; private set; }
            public ICommand CRCommand { get; private set; }
            public ICommand CSCommand { get; private set; }
            public ICommand IWACommand { get; private set; }
            public ICommand ResultsBtnCommand { get; private set; }
        }
    }