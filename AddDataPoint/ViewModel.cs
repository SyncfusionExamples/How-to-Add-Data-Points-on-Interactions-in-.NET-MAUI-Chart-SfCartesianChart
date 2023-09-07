using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AddDataPoint
{
    public class ViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ViewModel()
        {
            Data = new ObservableCollection<Model>() {
                new Model(1, 5),
                new Model(2, 8),
                new Model(3, 6),
                new Model(4, 8),
                new Model(5, 7.5)

            };
        }

        private ObservableCollection<Model> _items = new ObservableCollection<Model>();
        public ObservableCollection<Model> Data
        {
            get { return _items; }
            set
            {
                _items = value;

                OnPropertyChanged("Data");
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
