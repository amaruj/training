using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace training.wpf
{
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly IInstrumentRepository _instrumentRepository;
        private readonly Pricer _pricer;

        public ObservableCollection<InstrumentViewModel> Instruments { get; private set; }

        public ICommand StartCommand { get; private set; }

        public ICommand StopCommand { get; private set; }

        public ICommand RestartCommand { get; private set; }

        public ViewModel()
        {
            _instrumentRepository = new MyInstrumentRepository();
            _instrumentRepository.Init(50);
            Instruments =
                new ObservableCollection<InstrumentViewModel>(
                    _instrumentRepository.GetInstruments().Select(instrument => new InstrumentViewModel(instrument)));
            _pricer = new Pricer(_instrumentRepository, 1);
            
            StartCommand = new RelayCommand(o => { _pricer.Price(); }, o => true);
            StopCommand = new RelayCommand(o => { _pricer.StopPrice(); }, o => true);
            RestartCommand = new RelayCommand(o => { _pricer.Restart(); }, o => true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
