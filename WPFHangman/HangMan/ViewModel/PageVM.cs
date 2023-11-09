using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Vazby.ViewModel;

namespace HangMan.ViewModel
{
    internal class PageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyProperty([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<string> _letters;
        private string _word;
        private string _wordno;
        private bool _win;
        private string _winColor;
        private int _badguesses;

        public ParametrizedRelayCommand<string> Click { get; set; }
        public RelayCommand Start { get; set; }
        public PageVM()
        {
            Win = false;
            WinColor = "Red";
            _letters = new ObservableCollection<string>();
            Click = new ParametrizedRelayCommand<string>(
                (value) =>
                {
                    _letters.Add(value);
                    NotifyProperty("WordNo");
                    Click.RaiseCanExecuteChanged();

                    if (!(Word.Contains(value.ToLower()) || Word.Contains(value.ToUpper())))
                    {
                        Badguesses++;
                    }
                    if (WordNo == Word)
                    {
                        Win = true;
                        WinColor = "Green";
                    }
                    NotifyProperty("Win");
                },
                (value) =>
                {
                    if (_letters.Contains(value))
                    {
                        return false;
                    }
                    return true;
                }
                );
            Start = new RelayCommand(
                () =>
                {
                    _letters.Clear();
                    Badguesses = 0;
                    Win = false;
                    WinColor = "Red";
                    NotifyProperty("WordNo");
                    Click.RaiseCanExecuteChanged();
                },
                () =>
                {
                    return true;
                }
                
                );
            Word = "TeST";
            
        }
        
        public ObservableCollection<string> Letters
        {
            get 
            {
                return _letters;
            }
            set 
            {
                _letters = value;
                NotifyProperty();
            }
        }
        public string Word
        {
            get { return _word; }
            set { _word = value; NotifyProperty("WordNo"); NotifyProperty(); } 
        }
        public string WinColor
        {
            get { return _winColor; }
            set { _winColor = value; NotifyProperty(); }
        }
        public string WordNo
        {
            get 
            {
                string result = "";
                foreach (var l in Word)
                {
                    if (Letters.Contains(l.ToString().ToUpper()))
                    {
                        result += l;
                    }
                    else
                    {
                        result += "*";
                    }
                }
                return result;
            }
            set { _wordno = value; NotifyProperty(); }
        }
        public int Badguesses
        {
            get { return _badguesses; }
            set { _badguesses = value; NotifyProperty(); }
        }
        public bool Win
        {
            get { return _win; }
            set { _win = value; NotifyProperty(); }
        }

    }
}
