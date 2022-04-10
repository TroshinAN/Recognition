using System;
using System.ComponentModel;

namespace RecognitionWPF.Models
{
    public class RecognitionDataGrid : INotifyPropertyChanged
    {
        private DateTime time;
        public DateTime Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        private string number = String.Empty;
        public string Number
        {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private double confidence;
        public double Confidence
        {
            get => confidence;
            set
            {
                confidence = value;
                OnPropertyChanged(nameof(Confidence));
            }
        }


        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
