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
        int bCount = 0;
        int cCount = 0;
        int kCount = 0;
        int iCount = 0;
        string character = "";
        string picture = "";
        int i = 0;
        int[] score = { 0, 0, 0, 0 };
        Boolean isVisible = true;
        Boolean pictureVisibility = false;
        String[] Questions = new string[5] { "1) Which metahuman super power would you want to have the most?", "2) If you couldn't be out fighting crime, what would you be doing?", "3) If a stranger was in trouble, what would be your first reaction?", "4) In a superhero team, who are you?", "5) What is your favorite color?" };
         String[] bAns = new string[5] { "superspeed", "law enforcement", "help them", "the leader",  "red" };
        String[] iAns = new string[5] { "flight", "journalist", "call the police",  "the lookout",  "yellow" };
        String[] cAns = new string[5] { "telekinesis", "engineer", "think it through", "the weapon specialist","black" };
        String[] kAns = new string[5] { "weather manipulation", "scientist","make a plan", "the brains", "blue" };
      
        public event PropertyChangedEventHandler PropertyChanged;
 

        public QuizViewModel() 
        {

            TallyCommand = new Command<string>((key) =>
            {
                i++;
                if (i > 4)
                {
                    //hide buttons and such
                    isVisible = false;
                    Visible = false;
                    pictureVisibility = true;
                    Picture = true;
                   Question = findPersonality();
                }
                else
                {
                    Question = "";
                    bAnswer = "";
                    iAnswer = "";
                    cAnswer = "";
                    kAnswer = "";
                }

            });
        }

        public string findPersonality()
        {
           
            if (bCount > cCount && bCount > iCount && bCount > kCount) { character = "Barry Allen aka The Flash"; picture = "https://i.pinimg.com/originals/76/fc/50/76fc50eea0e8fd6c5a9cda7ad64905b9.jpg"; }
            else if (cCount > bCount && cCount > iCount && cCount > kCount) { character = "Cisco Ramon aka Vibe"; picture = ""; }
            else if (kCount > bCount && kCount > iCount && kCount > cCount) { character = "Kailtlyn Snow aka Killer Frost"; picture = ""; }
            else if (iCount > bCount && iCount > cCount && iCount > kCount) { character = "Iris West-Allen aka Reporter"; picture = ""; }

           
            return character;
            
        }
        public string Character { get; set; }
 public string PhotoSrc
        {
            protected set
            {
                OnPropertyChanged("PhotoSrc");
            }
            get
            {
                return picture;
            }
        }
        public bool Picture
        {
            protected set
            {
                OnPropertyChanged("Picture");
            }
            get
            {
                return pictureVisibility;
            }
        }
        public bool Visible
        {
            protected set
            {
                OnPropertyChanged("Visible");
            }
            get
            {
                return isVisible;
            }
        }
        public string Question
        {
            protected set
            {
                OnPropertyChanged("Question");
            }
            get
            {
                return Questions[i];
            }
        }
       
        public string bAnswer
        {
            protected set
            {
                OnPropertyChanged("bAnswer");
               bCount++;
            }
            get
            {
                return bAns[i];
            }
        }
        public string iAnswer
        {
            protected set
            {
                OnPropertyChanged("iAnswer");
                iCount++;
            }
            get
            {
                return iAns[i];
            }
        }
        public string cAnswer
        {
            protected set
            {
                OnPropertyChanged("cAnswer");
                cCount++;
            }
            get
            {
                return cAns[i];
            }
        }
        public string kAnswer
        {
            protected set
            {
                OnPropertyChanged("kAnswer");
                kCount++;
            }
            get
            {
                return kAns[i];
            }
        }
        public ICommand TallyCommand { protected set; get; }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
    }
}


        /* int i = 0;
            int bCount = 0;
            int cCount = 0;
            int kCount = 0;
            int iCount = 0;

            String[] Questions = new string[6] { "1) Which metahuman super power would you want to have the most?", "2) If you couldn't be out fighting crime, what would you be doing?", "3) If a stranger was in trouble, what would be your first reaction?", "4) In a superhero team, who are you?", "5) What is your favorite color?", "" };
            String[] Answers = new string[20] { "superspeed", "flight", "telekinesis", "weather manipulation", "law enforcement", "scientist", "engineer", "journalist", "the brains", "the lookout", "the weapon specialist", "the leader", "help them", "think it through", "call the police", "make a plan", "blue", "yellow", "red", "black", };
            public QuizViewModel()
            {
                Question = "";
            }
            public string Question
            {
                protected set
                {
                    OnPropertyChanged("Question");
                }
                get
                {
                    return Questions[i];
                }
            }
            public string Answer
            {

                protected set
                {
                    OnPropertyChanged("Answer");
                    if(Answer.Equals(Answers[0]) || Answer.Equals(Answers[4]) || Answer.Equals(Answers[11]) || Answer.Equals(Answers[12]) || Answer.Equals(Answers[18]))
                    {
                        bCount++;
                    }
                    else if (Answer.Equals(Answers[1]) || Answer.Equals(Answers[7]) || Answer.Equals(Answers[9]) || Answer.Equals(Answers[14]) || Answer.Equals(Answers[17]))
                    {
                        iCount++;
                    }
                    else if (Answer.Equals(Answers[2]) || Answer.Equals(Answers[6]) || Answer.Equals(Answers[10]) || Answer.Equals(Answers[13]) || Answer.Equals(Answers[19]))
                    {
                        cCount++;
                    }
                    else
                    {
                        kCount++;
                    }


                }
                get
                {
                    return Answers[i];
                }
            }
            string name = "";
            int age = 0;

            public event PropertyChangedEventHandler PropertyChanged;

            void OnPropertyChanged([CallerMemberName] string name = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }


            public string Name
            {
                get { return name; }
                set
                {
                    name = value;

                    OnPropertyChanged();

                    OnPropertyChanged(nameof(DisplayMessage));
                }
            }

            public int Age
            {
                get { return age; }
                set
                {
                    age = value;

                    OnPropertyChanged();

                    OnPropertyChanged(nameof(DisplayMessage));
                }
            }


            public string DisplayMessage
            {
                get
                {
                    return $"Your new friend is named {Name}";
                }
            }


        int bCount = 0;
        int cCount = 0;
        int kCount = 0;
        int iCount = 0;
        public QuizViewModel()
        {
            Calculate();
        }

        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }

        public int Age
        {
            get { return Age; }
            set { Age = value; }
        }


        public class Answers
        {
            public string Superpower { get; set; }
            public string Hobby { get; set; }
        }
        public string Calculate()
        {
            if (Name.ToLower().Contains("b") || Age <= 20)
            {
                bCount++;
            }
            if (Name.ToLower().Contains("c") || (Age > 20 && Age < 25))
            {
                cCount++;
            }
            if (Name.ToLower().Contains("k") || Age > 30)
            {
                kCount++;
            }
            if (Name.ToLower().Contains("i") || (Age >= 25 && Age <=30))
            {
                iCount++;
            }
            Answers a = new Answers();
            if (a.Hobby.Equals("Reading a good book") || a.Hobby.Equals("Math equations on a whiteboard")) {bCount++;}
            else if(a.Hobby.Equals("Curing cancer")) { kCount++;}
            else if(a.Hobby.Equals("Writing news stories")) { iCount++; }
            if (a.Superpower.Equals("Speed")) { bCount++; }
            else if (a.Superpower.Equals("Teleportation")) { cCount++; }
            else if (a.Superpower.Equals("Giving 'The Chills'")) { kCount++; }
            else if (a.Superpower.Equals("The most ordinary power possible")) { iCount++; }
           return GetCharacter();
        }
        public string GetCharacter()
        {
            var character = "";
            var Characters = new List<string>(4);
            Characters.Add("Barry Allen aka The Flash");
            Characters.Add("Cisco Ramon aka Vibe");
            Characters.Add("Kailtlyn Snow aka Killer Frost");
            Characters.Add("Iris West-Allen aka Reporter");
            if (bCount > cCount && bCount > iCount && bCount > kCount) { character = "Barry Allen aka The Flash"; }
            else if (cCount > bCount && cCount > iCount && cCount > kCount) { character = "Cisco Ramon aka Vibe"; }
            else if (kCount > bCount && kCount > iCount && kCount > cCount) { character = "Kailtlyn Snow aka Killer Frost"; }
            else if (iCount > bCount && iCount > cCount && iCount > kCount) { character = "Iris West-Allen aka Reporter"; }

            switch (character)
            {
                case "Barry Allen aka The Flash":
                   // image.Source = "barry.png";
                    break;
                case "Cisco Ramon aka Vibe":
                   // image.Source = "cisco.png";
                    break;
                case "Kailtlyn Snow aka Killer Frost":
                   // image.Source = "kaitlyn.png";
                    break;
                case "Iris West-Allen aka Central City Reporter":
                    //image.Source = "iris.png";
                    break;
            }


            return character;
        }

    */

    

