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
        public string a1;

        private ObservableCollection<string> _mySource;
        public ObservableCollection<string> MySource
        {
            get
            {
                return _mySource;
            }
            set
            {
                _mySource = value;
                OnPropertyChanged("MySource");
            }
        }
        private ObservableCollection<string> _Q;
        public ObservableCollection<string> Q
        {
            get
            {
                return _Q;
            }
            set
            {
                _Q = value;
                OnPropertyChanged("Q");
            }
        }
        private ObservableCollection<string> _Q2;
        public ObservableCollection<string> Q2
        {
            get
            {
                return _Q2;
            }
            set
            {
                _Q2 = value;
                OnPropertyChanged("Q2");
            }
        }
        private ObservableCollection<string> _Q3;
        public ObservableCollection<string> Q3
        {
            get
            {
                return _Q3;
            }
            set
            {
                _Q3 = value;
                OnPropertyChanged("Q3");
            }
        }
        private ObservableCollection<string> _Q4;
        public ObservableCollection<string> Q4
        {
            get
            {
                return _Q4;
            }
            set
            {
                _Q4 = value;
                OnPropertyChanged("Q4");
            }
        }

        private string _q1Selected;
        public string Q1_Selected
        {
            set
            {
                _q1Selected = value;
                OnPropertyChanged("Q1_Selected");
                setCounts(_q1Selected);
            }
        }
        private string _q2Selected;
        public string Q2_Selected
        {
            set
            {
                _q2Selected = value;
                OnPropertyChanged("Q2_Selected");
                setCounts(_q2Selected);
            }
        }
        private string _q3Selected;
        public string Q3_Selected
        {
            set
            {
                _q3Selected = value;
                OnPropertyChanged("Q3_Selected");
                setCounts(_q3Selected);
            }
        }
        private string _q4Selected;
        public string Q4_Selected
        {
            set
            {
                _q4Selected = value;
                OnPropertyChanged("Q4_Selected");
                setCounts(_q4Selected);
            }
        }
        private string _q5Selected;
        public string Q5_Selected
        {
            set
            {
                _q5Selected = value;
                OnPropertyChanged("Q5_Selected");
                setCounts(_q5Selected);
            }
        }

        public void setCounts(string ans)
        {
            
            if (ans.Equals(baAnswers[count])) baCount++;
            else if (ans.Equals(crAnswers[count])) crCount++;
            else if (ans.Equals(csAnswers[count])) csCount++;
            else if (ans.Equals(iwaAnswers[count])) iwaCount++;
            count++;
        }


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

            public QuizViewModel() {
            
            
            MySource = new ObservableCollection<string>
            {               
                baAnswers[0], crAnswers[0], csAnswers[0], iwaAnswers[0]
            };
            Q = new ObservableCollection<string>
            {
                baAnswers[1], crAnswers[1], csAnswers[1], iwaAnswers[1]
            };
            Q2 = new ObservableCollection<string>
            {
                baAnswers[2], crAnswers[2], csAnswers[2], iwaAnswers[2]
            };
            Q3 = new ObservableCollection<string>
            {
                baAnswers[3], crAnswers[3], csAnswers[3], iwaAnswers[3]
            };
            Q4 = new ObservableCollection<string>
            {
                baAnswers[4], crAnswers[4], csAnswers[4], iwaAnswers[4]
            };



            ResultsCommand = new Command(() =>
            {
                questionVisible = false;
                resultsVisible = true;
                OnPropertyChanged("QuestionVisible");
                OnPropertyChanged("ResultsVisible");
                OnPropertyChanged("CharacterName");
            });
               
            }
        
        public bool QuestionVisible { get { return questionVisible; } }
            public bool ResultsVisible { get { return resultsVisible; } }
           
      
        public string CharacterName {
            get {
                
                //if (name.ToLower().Contains("b")) baCount++;
                //if (age == 23) baCount++;
                //if (name.ToLower().Contains("i")) iwaCount++;
                //if (name.ToLower().Contains("ra")) crCount++;
                //if (name.ToLower().Contains("s")) csCount++;
                var charPhoto = "";
                if (baCount > crCount && baCount > iwaCount && baCount > csCount) { charPhoto = "https://i.pinimg.com/originals/c8/98/1a/c8981a0a8bf8a4bd46614a99124c7fd7.jpg"; }
                else if (crCount > baCount && crCount > iwaCount && crCount > csCount) { charPhoto = "https://i.pinimg.com/originals/3c/1c/d6/3c1cd6049f92e6a9ccb604871e335a60.jpg"; }
                else if (csCount > baCount && csCount > iwaCount && csCount > crCount) { charPhoto = "https://i.pinimg.com/originals/b6/6c/2c/b66c2c7a43d0b0acdc794917dfe50f2d.jpg"; }
                else if (iwaCount > baCount && iwaCount > crCount && iwaCount > crCount){ charPhoto = "https://i.pinimg.com/originals/35/d8/b5/35d8b598dc74a900ee29074b6ef8ea5e.jpg"; }
                else { charPhoto = "https://i.pinimg.com/originals/3c/1c/d6/3c1cd6049f92e6a9ccb604871e335a60.jpg"; }
                return charPhoto;
                }
            }
     
            public ICommand ResultsCommand { get; private set; }
        }
    }