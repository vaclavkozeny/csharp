using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfRectangleBinding.VM
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Sirka = 20;
            Vyska = 20;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyProperty([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private double _vyska;
        private double _sirka;
        private double _obvod;
        private double _obash;

        public double Vyska
        {
            get { return _vyska; }
            set { _vyska = value;
                Obsah = _vyska * _sirka;
                Obvod = 2 * _sirka + 2 * _vyska;
                NotifyProperty(); }
        }
        public double Sirka
        {
            get { return _sirka; }
            set 
            { 
                _sirka = value;
                Obsah = _vyska * _sirka;
                Obvod = 2*_sirka + 2*_vyska;
                NotifyProperty(); 
            }
        }
        public double Obvod
        {
            get {  return _obvod; }
            set { _obvod =value; NotifyProperty(); }
        }
        public double Obsah
        {
            get { return _obash; }
            set { _obash = value; NotifyProperty(); }
        }
    }
}
