using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vazby.ViewModel;
using WpfRPS.Models;

namespace WpfRPS.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Random _random = new Random();
        private Figure _player;
        private Figure _computer;
        private bool _running;
        private int _playerScore;
        private int _computerScore;
        public RelayCommand StartCommand { get; set; }
        public ParametrizedRelayCommand<string> ChooseCommnad { get; set; }
        public MainViewModel()
        {
            Player = Figure.Nothing;
            Computer = Figure.Nothing;
            PlayerScore = 0;
            ComputerScore = 0;
            Running = false;

            StartCommand = new RelayCommand(
                () =>
                {
                    Running = true;
                    PlayerScore = 0;
                    ComputerScore = 0;
                    Computer = Figure.Nothing;
                    Player = Figure.Nothing;
                    NotifyPropertyChanged();
                    StartCommand.RaiseCanExecuteChanged();
                    ChooseCommnad.RaiseCanExecuteChanged();
                },
                () =>
                {
                    if (Running)
                    {
                        return false;
                    }
                    return true;
                    
                }
                );
            ChooseCommnad = new ParametrizedRelayCommand<string>(
                (value) =>
                {
                    var num = _random.Next(1, 4);
                    Computer = (Figure)num;
                    NotifyPropertyChanged("Computer");
                    int t = int.Parse(value);
                    Player = (Figure)t;
                    NotifyPropertyChanged("Player");
                    

                    if (Player == Figure.Rock && Computer == Figure.Paper)
                    {
                        ComputerScore++;
                    }
                    else if (Player == Figure.Rock && Computer == Figure.Scissors)
                    {
                        PlayerScore++;
                    }
                    if (Player == Figure.Paper && Computer == Figure.Scissors)
                    {
                        ComputerScore++;
                    }
                    else if (Player == Figure.Paper && Computer == Figure.Rock)
                    {
                        PlayerScore++;
                    }
                    if (Player == Figure.Scissors && Computer == Figure.Rock)
                    {
                        ComputerScore++;
                    }
                    else if (Player == Figure.Scissors && Computer == Figure.Paper)
                    {
                        PlayerScore++;
                    }
                    
                    NotifyPropertyChanged("PlayerScore");
                    NotifyPropertyChanged("ComputerScore");
                    
                    if (PlayerScore == 3 || ComputerScore == 3)
                    {
                        Running = false;
                        StartCommand.RaiseCanExecuteChanged();
                        ChooseCommnad.RaiseCanExecuteChanged();
                    }
                    NotifyPropertyChanged("Running");
                },
                (parametr) =>
                {
                    if(Running)
                    {
                        return true;
                        ChooseCommnad.RaiseCanExecuteChanged();
                    }
                    return false;

                }
                );
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Figure Player { get { return _player; } set { _player = value; NotifyPropertyChanged(); } }
        public int PlayerScore { get { return _playerScore; } set { _playerScore = value; NotifyPropertyChanged(); } }
        public Figure Computer { get { return _computer; } set { _computer = value; NotifyPropertyChanged(); } }
        public int ComputerScore { get { return _computerScore; } set { _computerScore = value; NotifyPropertyChanged(); } }
        public bool Running { get { return _running; } set { _running = value; NotifyPropertyChanged(); } }
    }
}
