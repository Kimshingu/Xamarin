using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calc
{
    class CalcViewModel : INotifyPropertyChanged
    {
        string inputString = "";
        string displayText = "";
        public string Op { get; set; }
        public double Op1 { get; set; }
        public double Op2 { get; set; }

        public ICommand AddCharCommand { get; set; }
        public ICommand DeleteCharCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand OperationCommand { get; set; }
        public ICommand CalcCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CalcViewModel() {

            this.AddCharCommand = new Command<string>((key) =>
            {
                this.InputString += key;
            });

            this.DeleteCharCommand = new Command<string>((nothing) =>
            {
                this.InputString = this.InputString.Substring(0, this.InputString.Length - 1);
            }, (nothing) =>
            {
                return this.InputString.Length > 0;
            });

            this.ClearCommand = new Command((nothing) =>
            {
                this.InputString = "";
            });

            this.OperationCommand = new Command<string>((key) =>
            {
                this.Op = key;
                this.Op1 = Convert.ToDouble(this.InputString);
                this.InputString = "";
            });

            this.CalcCommand = new Command<string>((nothing) =>
            {
                this.Op2 = Convert.ToDouble(this.InputString);

                switch (this.Op) {
                    case "+": this.InputString = (this.Op1 + this.Op2).ToString(); break;
                    case "*": this.InputString = (this.Op1 * this.Op2).ToString(); break;
                    case "-": this.InputString = (this.Op1 - this.Op2).ToString(); break;
                    case "/": this.InputString = (this.Op1 / this.Op2).ToString(); break;
                }
            });
        }

        public string InputString
        {
            get { return inputString; }

            protected set {
                if (inputString != value) {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    this.DisplayText = inputString;

                    ((Command)this.DeleteCharCommand).ChangeCanExecute();
                }
            } 
        }

        public string DisplayText
        {
            get { return displayText; }
            protected set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
